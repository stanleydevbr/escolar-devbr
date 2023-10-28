using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1;
using Google.Apis.Storage.v1.Data;
using Microsoft.Extensions.Configuration;

namespace DevBr.Core.Storage.Google
{
    public class GoogleContainer
    {
        private readonly IConfiguration Configuration;
        private readonly GoogleCredentials GoogleConfig;
        private readonly ClientSecrets ClientSecrets;
        private readonly StorageService Service;
        private readonly UserCredential userCredential;
        public GoogleContainer()
        {
            GoogleConfig = (GoogleCredentials)Configuration.GetSection("Google");
            ClientSecrets = new ClientSecrets();
            ClientSecrets.ClientId = GoogleConfig.ClientId;
            ClientSecrets.ClientSecret = GoogleConfig.ClientSecret;
            var scopes = new[] { @"https://www.googleapis.com/auth/devstorage.full_control" };

            var cts = new CancellationTokenSource();
            userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(ClientSecrets, scopes, GoogleConfig.Email, cts.Token).Result;

            Service = new StorageService();
        }

        public void CreateContainer(string containerName)
        {
            var newBucket = new Bucket()
            {
                Name = containerName,
            };
            var newBucketQuery = Service.Buckets.Insert(newBucket, "projectName");
            newBucketQuery.OauthToken = userCredential.Token.AccessToken;
            newBucketQuery.Execute();
        }

        public Buckets GetAllContainer()
        {
            var bucketsQuery = Service.Buckets.List("projectName");
            bucketsQuery.OauthToken = userCredential.Token.AccessToken;
            var buckets = bucketsQuery.Execute();
            return buckets;
        }
    }
}
