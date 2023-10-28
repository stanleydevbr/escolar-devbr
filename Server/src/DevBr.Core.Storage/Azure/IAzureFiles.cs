using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DevBr.Core.Storage.Azure
{
    public interface IAzureFiles
    {
        Task<bool> DeleteAsync(string fileName);
        Task<byte[]?> DonwloadAsync(string filename);
        Task<List<IListBlobItem>> GetAllAsync();
        Task<bool> IsFileExists(string fileName);
        Task<bool> TransferAsync(List<IFormFile> files);
        Task<bool> UploadAsync(IFormFile files);
    }
}