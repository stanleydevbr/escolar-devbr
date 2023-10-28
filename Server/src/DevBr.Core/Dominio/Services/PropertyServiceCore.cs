using DevBr.Core.Dominio.Interfaces;

namespace DevBr.Core.Dominio.Services
{
    public class PropertyServiceCore<TEntity> : ServiceCore<TEntity>
    {
        public PropertyServiceCore(IRepositoryCore<TEntity> repository) : base(repository)
        {

        }
    }
}
