using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevBr.Core.Dominio.Interfaces
{
    public interface IRepositoryCore<TEntity> : IDisposable
    {
        Task<TEntity> AdicionarAsync(TEntity obj);
        Task<TEntity> AtualizarAsync(TEntity obj);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<bool> RemoverAsync(Guid id);
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        bool Remover(Guid id);
    }
}
