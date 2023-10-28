using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DevBr.Core.Storage.Azure
{
    public class AzureFiles : IAzureFiles
    {
        private readonly IConfiguration Configuration;
        private readonly AzureCredentials AzureConfig;
        public AzureFiles()
        {
            AzureConfig = (AzureCredentials)Configuration.GetSection("Azure");
        }
        public async Task<bool> DeleteAsync(string fileName)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfig.ConnectionString);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(AzureConfig.ContainerName);
            var blob = cloudBlobContainer.GetBlobReference(fileName);
            await blob.DeleteIfExistsAsync();
            return true;
        }

        public async Task<byte[]?> DonwloadAsync(string filename)
        {
            CloudBlockBlob blockBlob;
            await using (MemoryStream memoryStream = new MemoryStream())
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfig.ConnectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(AzureConfig.ContainerName);
                blockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
                await blockBlob.DownloadToStreamAsync(memoryStream);
            }
            Stream blobStream = blockBlob.OpenReadAsync().Result;
            var bytes = new byte[blobStream.Length];
            blobStream.Seek(0, SeekOrigin.Begin);
            await blobStream.ReadAsync(bytes, 0, bytes.Length);
            blobStream.Dispose();
            return bytes;
        }

        public async Task<List<IListBlobItem>> GetAllAsync()
        {
            BlobContinuationToken continuationToken = null;
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfig.ConnectionString);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(AzureConfig.ContainerName);
            List<IListBlobItem> results = new List<IListBlobItem>();
            do
            {
                bool useFlatBlobListing = true;
                BlobListingDetails blobListingDetails = BlobListingDetails.None;
                int maxBlobsPerRequest = 500;
                var response = await cloudBlobContainer.ListBlobsSegmentedAsync("*", useFlatBlobListing, blobListingDetails, maxBlobsPerRequest, continuationToken, null, null);
                continuationToken = response.ContinuationToken;
                results.AddRange(response.Results);
            }
            while (continuationToken != null);
            return results;
        }

        public async Task<bool> IsFileExists(string fileName)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfig.ConnectionString);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var blob = cloudBlobClient.GetContainerReference(AzureConfig.ContainerName).GetBlockBlobReference(fileName);
            return await blob.ExistsAsync();
        }

        public async Task<bool> TransferAsync(List<IFormFile> files)
        {
            files.AsParallel().Select(async f => await UploadAsync(f));
            return true;
        }

        public async Task<bool> UploadAsync(IFormFile files)
        {

            string systemFileName = files.FileName;
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(AzureConfig.ConnectionString);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(AzureConfig.ContainerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = files.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
            return true;
        }
    }


}
