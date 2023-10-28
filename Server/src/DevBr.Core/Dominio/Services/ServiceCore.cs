using DevBr.Core.Dominio.Entidades;
using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Dominio.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBr.Core.Dominio.Services
{
    public class ServiceCore<TEntity> : IServiceCore<TEntity>
    {
        public readonly IRepositoryCore<TEntity> _repository;

        public ServiceCore(IRepositoryCore<TEntity> repository)
        {
            this._repository = repository;
        }

        public virtual Notificacao<TEntity> Adicionar(TEntity entity)
        {
            return new Notificacao<TEntity>().TrateResultado(_repository.Adicionar(entity));
        }

        public virtual async Task<Notificacao<TEntity>> AdicionarAsync(TEntity entity)
        {
            return new Notificacao<TEntity>().TrateResultado(await _repository.AdicionarAsync(entity));
        }

        public virtual Notificacao<TEntity> Consultar(Guid id)
        {
            return new Notificacao<TEntity>().TrateResultado(_repository.ObterPorId(id));
        }

        public virtual async Task<Notificacao<TEntity>> ConsultarAsync(Guid id)
        {
            return new Notificacao<TEntity>().TrateResultado(await _repository.ObterPorIdAsync(id));
        }

        public virtual Notificacao<TEntity> Editar(TEntity entity)
        {
            //Type type = typeof(TEntity);
            //PropertyInfo property = type.GetProperty("DataAlteracao");
            //property.SetValue(entity, DateTime.Now);
            return new Notificacao<TEntity>().TrateResultado(_repository.Atualizar(entity));
        }

        public virtual async Task<Notificacao<TEntity>> EditarAsync(TEntity entity)
        {
            //Type type = typeof(TEntity);
            //PropertyInfo property = type.GetProperty("DataAlteracao");
            //property.SetValue(entity, DateTime.Now);
            return new Notificacao<TEntity>().TrateResultado(await _repository.AtualizarAsync(entity));
        }

        public virtual Notificacao<bool> Excluir(Guid id)
        {
            return new Notificacao<bool>().TrateResultado(_repository.Remover(id));
        }

        public virtual async Task<Notificacao<bool>> ExcluirAsync(Guid id)
        {
            return new Notificacao<bool>().TrateResultado(await _repository.RemoverAsync(id));
        }

        public virtual Notificacao<List<TEntity>> Listar()
        {
            return new Notificacao<List<TEntity>>().TrateResultado(_repository.ObterTodos().ToList());
        }

        public virtual Notificacao<ResultList<TEntity>> Listar(FilterList filtro)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Notificacao<List<TEntity>>> ListarAsync()
        {
            return new Notificacao<List<TEntity>>().TrateResultado(await _repository.ObterTodosAsync() as List<TEntity>);
        }

        public virtual Task<Notificacao<ResultList<TEntity>>> ListarAsync(FilterList filtro)
        {
            throw new NotImplementedException();
        }
    }
}
