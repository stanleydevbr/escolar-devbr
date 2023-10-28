using DevBr.Core.Dominio.Entidades;
using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevBr.Escola.Infra.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IRepositoryCore<TEntity> where TEntity : Entity<TEntity>
    {
        protected EscolaContext Db;
        protected DbSet<TEntity> dbSet;
        public BaseRepository(EscolaContext context)
        {
            Db = context;
            dbSet = Db.Set<TEntity>();
        }
        public virtual async Task<TEntity> AdicionarAsync(TEntity obj)
        {
            await dbSet.AddAsync(obj);
            await Db.CommitAsync();
            return obj;
        }

        public virtual async Task<TEntity> AtualizarAsync(TEntity obj)
        {
            dbSet.Update(obj);
            await Db.CommitAsync();
            return obj;
        }

        public virtual async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<bool> RemoverAsync(Guid id)
        {
            dbSet.Remove(dbSet.Find(id));
            return await Db.CommitAsync();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            dbSet.Add(obj);
            Db.Commit();
            return obj;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            dbSet.Update(obj);
            Db.Commit();
            return obj;
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return dbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return dbSet.ToList();

        }

        public virtual bool Remover(Guid id)
        {
            dbSet.Remove(dbSet.Find(id));
            return Db.Commit();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
