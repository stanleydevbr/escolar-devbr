using DevBr.Core.Repository.MongoDb.Interfaces;
using MongoDB.Driver;
using ServiceStack;

namespace DevBr.Core.Repository.MongoDb
{
    public abstract class RepositoryCore<TEntity> : IRepositoryCore<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected readonly IMongoCollection<TEntity> DbSet;

        public RepositoryCore(IMongoContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual TEntity Adicionar(TEntity entity)
        {
            Context.AddCommand(async () => await DbSet.InsertOneAsync(entity));
            return entity;
        }

        public virtual TEntity Atualizar(TEntity entity)
        {
            Context.AddCommand(async () => await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity));
            return entity;
        }

        public virtual void Dispose()
        {
            Context?.Dispose();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            var result = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return result.ToList();
        }

        public virtual bool Remover(Guid id)
        {
            Context.AddCommand(async () => await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
            return true;
        }
    }
}
