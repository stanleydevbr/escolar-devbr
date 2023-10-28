using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevBr.Core.SqlServer
{
    public interface IRepositoryCore<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AdicionarAsync(TEntity entity);
        TEntity AtualizarAsync(TEntity entity);
        Task<TEntity> BuscarAsync(object id);
        Task<IEnumerable<TEntity>> BuscarAsync(FilterParms<TEntity> filterParms);
        Task<IEnumerable<TEntity>> BuscarTodosAsync();
        Task<bool> ExcluirAsync(object id);
        Task<bool> ExcluirAsync(Expression<Func<TEntity, bool>>? filterExpression);
        Task<int> SaveChangesAsync();
    }

    public enum TypeOrder
    {
        OrderBy,
        OrderByDescending
    }

    public class FilterParms<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? FiltrarPor { get; set; }
        public TypeOrder? TipoOrdem { get; set; } = TypeOrder.OrderBy;
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public Expression<Func<TEntity, object>>? OrdenarPor { get; set; }
    }
}
