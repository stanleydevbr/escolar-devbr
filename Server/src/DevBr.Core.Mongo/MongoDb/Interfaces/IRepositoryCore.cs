namespace DevBr.Core.Repository.MongoDb.Interfaces
{
    public interface IRepositoryCore<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        TEntity Atualizar(TEntity entity);
        bool Remover(Guid id);
    }
}
