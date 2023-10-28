namespace DevBr.Core.Repository.MongoDb.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
