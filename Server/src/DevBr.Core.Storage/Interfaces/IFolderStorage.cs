namespace DevBr.Core.Storage.Interfaces
{
    public interface IFolderStorage
    {
        void CreateNewFolder(string folderName);
        void DeleteFolder(string folderName);
        List<string> GetFolders();
    }
}
