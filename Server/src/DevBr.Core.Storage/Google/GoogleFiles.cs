using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Object = Google.Apis.Storage.v1.Data.Object;

namespace DevBr.Core.Storage.Google
{
    public class GoogleFiles : IGoogleFiles
    {
        private readonly IConfiguration Configuration;
        private readonly GoogleCredentials GoogleConfig;
        private readonly ClientSecrets ClientSecrets;
        private readonly StorageService Service;
        private readonly UserCredential UserCredential;
        public GoogleFiles()
        {
            GoogleConfig = (GoogleCredentials)Configuration.GetSection("Google");
            ClientSecrets = new ClientSecrets();
            ClientSecrets.ClientId = GoogleConfig.ClientId;
            ClientSecrets.ClientSecret = GoogleConfig.ClientSecret;
            var scopes = new[] { @"https://www.googleapis.com/auth/devstorage.full_control" };

            var cts = new CancellationTokenSource();
            UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(ClientSecrets, scopes, GoogleConfig.Email, cts.Token).Result;

            Service = new StorageService();

        }
        public async Task<bool> DeleteAsync(string filename)
        {
            var storageClient = StorageClient.Create();
            var newObject = new Object()
            {
                Bucket = GoogleConfig.ContainerName,
                Name = filename
            };
            try
            {
                await storageClient.DeleteObjectAsync(newObject);
                return true;
            }
            finally
            {
                storageClient.Dispose();
            }
        }

        public async Task<byte[]?> DonwloadAsync(string filename)
        {
            var newObject = new Object()
            {
                Bucket = GoogleConfig.ContainerName,
                Name = filename
            };
            var storageClient = StorageClient.Create();
            try
            {
                using (var ms = new MemoryStream())
                {
                    await storageClient.DownloadObjectAsync(newObject, ms);
                    return ms.ToArray();
                }
            }
            finally
            {
                storageClient.Dispose();
            }
        }

        public async Task<List<Object>> GetAllAsync()
        {
            var storageClient = StorageClient.Create();
            var results = storageClient.ListObjects(GoogleConfig.ContainerName);
            return results.ToList();
        }

        public Task<bool> IsFileExists(string fileName)
        {
            var storageClient = StorageClient.Create();
            throw new NotImplementedException();
        }

        public async Task<bool> TransferAsync(List<IFormFile> files)
        {
            files.ForEach(async f => await UploadAsync(f));
            return true;
        }

        public async Task<bool> UploadAsync(IFormFile files)
        {
            var newObject = new Object()
            {
                Bucket = GoogleConfig.ContainerName,
                Name = files.FileName
            };

            FileStream fileStream = null;
            try
            {
                var dir = Directory.GetCurrentDirectory();
                var path = Path.Combine(dir, files.FileName);
                fileStream = new FileStream(path, FileMode.Open);
                var uploadRequest = new ObjectsResource.InsertMediaUpload(Service, newObject, GoogleConfig.ContainerName, fileStream, "image/png");
                uploadRequest.OauthToken = UserCredential.Token.AccessToken;
                await uploadRequest.UploadAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }
    }


}
