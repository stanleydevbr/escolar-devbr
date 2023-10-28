using System.Threading.Tasks;

namespace DevBr.Core.Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task<bool> Commit();
    }
}
