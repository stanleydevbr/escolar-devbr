using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;

namespace DevBr.Core.Storage.Amazon
{
    public interface IAWSFiles
    {
        Task DeleteAsync(string fileName, string version);
        Task<byte[]?> DonwloadAsync(string filename);
        Task<ListObjectsResponse?> GetAllAsync();
        bool IsFileExists(string fileName, string version);
        Task TransferAsync(List<IFormFile> files);
        Task UploadAsync(IFormFile fileName);
    }
}