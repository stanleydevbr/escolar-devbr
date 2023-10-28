namespace DevBr.Core.Storage.Interfaces
{
    public interface IFileStorage
    {
        Task<string> Upload(Stream file, string fileName);
        Task<Stream> Download(string fileName);
        Task<bool> Remove(string path, string fileName);
        Task<Stream> GetFile(string path);
        Task<List<Stream>> GetAllFiles(string path);

    }
}
