namespace DevBr.Core.Mongo.MongoDb.Configuration
{
    public class MongoDbSettings
    {
        public List<DataBase> MongoDb { get; set; }
    }

    public class DataBase
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public List<Credentials> Credentials { get; set; }
        public bool IsAuthenticated => Credentials.Count > 0 && ExisteUsuarioSenha(Credentials);

        bool ExisteUsuarioSenha(List<Credentials> credentials)
        {
            bool status = true;
            foreach (Credentials cred in credentials)
                status = status && !string.IsNullOrEmpty(cred.Username) && !string.IsNullOrEmpty(cred.Password);
            return status;
        }
    }

    public class Credentials
    {
        public List<string> DatabaseNames { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mechanism { get; set; }
    }
}
