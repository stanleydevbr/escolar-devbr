using System.Linq.Expressions;

namespace DevBr.Core.SqlServer
{
    public class RepositoryCore<TEntity, TKeyType> : IRepositoryCore<TEntity>
    {
        public RepositoryCore()
        {

        }
        public Task<TEntity> AdicionarAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity AtualizarAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> BuscarAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> BuscarAsync(FilterParms<TEntity> filterParms)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> BuscarTodosAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAsync(Expression<Func<TEntity, bool>>? filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
