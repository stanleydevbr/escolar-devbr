using DevBr.Core.Dominio.Entidades;
using DevBr.Core.Dominio.Notificacoes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBr.Core.Dominio.Interfaces
{
    public interface IServiceCore<TEntity>
    {
        Task<Notificacao<TEntity>> AdicionarAsync(TEntity entity);
        Task<Notificacao<TEntity>> EditarAsync(TEntity entity);
        Task<Notificacao<bool>> ExcluirAsync(Guid id);
        Task<Notificacao<TEntity>> ConsultarAsync(Guid id);
        Task<Notificacao<List<TEntity>>> ListarAsync();
        Task<Notificacao<ResultList<TEntity>>> ListarAsync(FilterList filtro);
        Notificacao<TEntity> Adicionar(TEntity entity);
        Notificacao<TEntity> Editar(TEntity entity);
        Notificacao<bool> Excluir(Guid id);
        Notificacao<TEntity> Consultar(Guid id);
        Notificacao<List<TEntity>> Listar();
        Notificacao<ResultList<TEntity>> Listar(FilterList filtro);

    }
}
