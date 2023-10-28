using AutoMapper;
using DevBr.Core.Aplicacao.Interfaces;
using DevBr.Core.Dominio.Entidades;
using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Dominio.Notificacoes;
using DevBr.Core.Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBr.Core.Aplicacao.Services
{
    public class AppServiceCore<TViewModel, TEntity> : IAppServiceCore<TViewModel>
             where TViewModel : ViewModelCore
    {
        public readonly IServiceCore<TEntity> _service;
        public readonly IMapper _mapper;
        public AppServiceCore(IServiceCore<TEntity> service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public virtual TViewModel Adicionar(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            return TrateRetorno(this._service.Adicionar(entity));
        }

        public virtual async Task<TViewModel> AdicionarAsync(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            return TrateRetorno(await this._service.AdicionarAsync(entity));
        }

        public virtual TViewModel Consultar(Guid id)
        {
            var result = this._service.Consultar(id);
            return _mapper.Map<TViewModel>(result.Resultado);
        }

        public async Task<TViewModel> ConsultarAsync(Guid id)
        {
            var result = await this._service.ConsultarAsync(id);
            return _mapper.Map<TViewModel>(result);
        }

        public virtual TViewModel Editar(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            return TrateRetorno(this._service.Editar(entity));
        }

        public virtual async Task<TViewModel> EditarAsync(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            return TrateRetorno(await this._service.EditarAsync(entity));
        }

        public virtual bool Excluir(Guid id)
        {
            var result = this._service.Excluir(id);
            return result.Resultado;
        }

        public virtual async Task<bool> ExcluirAsync(Guid id)
        {
            var result = await this._service.ExcluirAsync(id);
            return result.Resultado;
        }

        public virtual List<TViewModel> Listar()
        {
            var result = _service.Listar();
            return _mapper.Map<List<TViewModel>>(result.Resultado);
        }

        public virtual async Task<List<TViewModel>> ListarAsync()
        {
            var result = await _service.ListarAsync();
            return _mapper.Map<List<TViewModel>>(result.Resultado);
        }

        public virtual async Task<ResultList<TViewModel>> ListarAsync(FilterList filtro)
        {
            var filtroMapped = _mapper.Map<FilterList>(filtro);
            var result = await this._service.ListarAsync(filtroMapped);
            return _mapper.Map<ResultList<TViewModel>>(result.Resultado);
        }

        protected TViewModel TrateRetorno(Notificacao<TEntity> resultadoNegocio)
        {
            var resultado = _mapper.Map<TViewModel>(resultadoNegocio.Resultado);
            var inconsistencias = new List<string>();
            foreach (var inconsistencia in resultadoNegocio.Mensagens.Values)
            {
                foreach (var mensagem in inconsistencia)
                    inconsistencias.Add(mensagem);
            }

            resultado.Inconsistencias = inconsistencias;

            return resultado;
        }
    }
}
