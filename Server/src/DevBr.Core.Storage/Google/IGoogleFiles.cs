using Microsoft.AspNetCore.Http;

namespace DevBr.Core.Storage.Google
{
    public interface IGoogleFiles
    {
        Task<bool> DeleteAsync(string filename);
        Task<byte[]?> DonwloadAsync(string filename);
        Task<List<global::Google.Apis.Storage.v1.Data.Object>> GetAllAsync();
        Task<bool> IsFileExists(string fileName);
        Task<bool> TransferAsync(List<IFormFile> files);
        Task<bool> UploadAsync(IFormFile files);
    }
}