using DevBr.Core.Infra.Data.UoW;
using DevBr.Escola.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace DevBr.Escola.Infra.Data.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EscolaContext _context;
        private bool _disposed;
        public UnitOfWork(EscolaContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _disposed = false;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
