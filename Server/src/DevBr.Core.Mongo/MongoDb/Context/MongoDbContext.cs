using DevBr.Core.Mongo.MongoDb.Configuration;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Security.Authentication;

namespace DevBr.Core.Mongo.MongoDb.Context
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoCollection<T> GetCollection<T>(string collection);
    }
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase Database { get; set; }
        private IClientSessionHandle Session { get; set; }
        private MongoClient MongoClient { get; set; }
        private MongoDbSettings AppSettinsMongo { get; set; }

        public MongoDbContext(IConfiguration configuration, string databasename)
        {
            AppSettinsMongo = (MongoDbSettings)configuration.GetSection(nameof(MongoDbSettings));
            ConfigConnection(databasename);
        }

        private void ConfigConnection(string databasename)
        {
            MongoClientSettings settings = ProtocolConfig();
            List<DataBase> databases = GetAllDatabase(databasename, AppSettinsMongo.MongoDb);
            List<MongoServerAddress> servers = new List<MongoServerAddress>();
            servers = GetAllServers(databasename, settings, databases);
        }

        private List<MongoServerAddress> GetAllServers(string databasename, MongoClientSettings appClientSettings, List<DataBase> databases)
        {
            List<MongoServerAddress> mongoServerAddresses = new List<MongoServerAddress>();
            databases.ForEach(database =>
            {
                var server = new MongoServerAddress(database.Server, database.Port);
                database.Credentials.ForEach(credential =>
                {
                    if (database.IsAuthenticated)
                    {
                        MongoIdentity identity = new MongoInternalIdentity(databasename, credential.Username);
                        MongoIdentityEvidence evidence = new PasswordEvidence(credential.Password);
                        appClientSettings.Credential = new MongoCredential(credential.Mechanism, identity, evidence);
                    }
                    mongoServerAddresses.Add(server);
                });
            });
            return mongoServerAddresses;
        }

        private List<DataBase> GetAllDatabase(string databasename, List<DataBase> mongoDb)
        {
            List<DataBase> dataBases = new List<DataBase>();
            foreach (DataBase db in mongoDb)
            {
                List<Credentials> credentials = new List<Credentials>();
                foreach (Credentials cred in db.Credentials)
                {
                    if (cred.DatabaseNames.Find(database => database == databasename) != null)
                        credentials.Add(cred);
                }
                if (credentials.Count > 0)
                {
                    dataBases.Add(db);
                    dataBases[dataBases.Count - 1].Credentials = credentials;
                }
            }
            return dataBases;
        }

        private MongoClientSettings ProtocolConfig()
        {
            return new MongoClientSettings
            {
                UseSsl = false,
                SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 }
            };
        }

        public IMongoCollection<T> GetCollection<T>(string collection)
        {
            return Database.GetCollection<T>(collection);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
