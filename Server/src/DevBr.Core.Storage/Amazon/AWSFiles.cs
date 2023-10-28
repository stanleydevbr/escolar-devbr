using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace DevBr.Core.Storage.Amazon
{
    public class AWSFiles : IAWSFiles
    {
        private readonly IConfiguration Configuration;
        private readonly IAmazonS3 S3Client;
        private readonly AWSCredentials config;
        public AWSFiles(IAmazonS3 S3Client)
        {
            config = (AWSCredentials)Configuration.GetSection("AWS");
            this.S3Client = S3Client;
        }

        public async Task UploadAsync(IFormFile filename)
        {
            using (var ms = new MemoryStream())
            {
                filename.CopyTo(ms);
                var request = new TransferUtilityUploadRequest
                {
                    InputStream = ms,
                    Key = filename.FileName,
                    BucketName = config.BucketName,
                    ContentType = filename.ContentType
                };

                var fileTransferUtility = new TransferUtility(S3Client);
                await fileTransferUtility.UploadAsync(request);
            }
        }

        public Task TransferAsync(List<IFormFile> files)
        {
            files.AsParallel().Select(async file => await UploadAsync(file));
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(string fileName, string version)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = config.BucketName,
                Key = fileName
            };
            if (!string.IsNullOrEmpty(version))
                request.VersionId = version;
            await S3Client.DeleteObjectAsync(request);
        }

        public async Task<byte[]?> DonwloadAsync(string filename)
        {
            MemoryStream? ms = null;

            var request = new GetObjectRequest
            {
                BucketName = config.BucketName,
                Key = filename
            };

            using (var response = await S3Client.GetObjectAsync(request))
            {
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    using (ms = new MemoryStream())
                    {
                        await response.ResponseStream.CopyToAsync(ms);
                    }
                }
            }

            if (ms is null || ms.ToArray().Length < 1)
                return null;

            return ms.ToArray();
        }

        public bool IsFileExists(string fileName, string version)
        {
            try
            {
                var request = new GetObjectMetadataRequest
                {
                    BucketName = config.BucketName,
                    Key = fileName,
                    VersionId = version
                };
                var response = S3Client.GetObjectMetadataAsync(request).Result;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ListObjectsResponse?> GetAllAsync()
        {
            var request = new ListObjectsRequest
            {
                BucketName = config.BucketName,
                Prefix = config.SecretKey
            };
            var response = await S3Client.ListObjectsAsync(request);
            return response;
        }
    }
}
