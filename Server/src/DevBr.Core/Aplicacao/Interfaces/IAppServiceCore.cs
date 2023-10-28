using DevBr.Core.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBr.Core.Aplicacao.Interfaces
{
    public interface IAppServiceCore<TViewModel>
    {
        TViewModel Adicionar(TViewModel viewModel);
        Task<TViewModel> AdicionarAsync(TViewModel viewModel);
        TViewModel Editar(TViewModel viewModel);
        Task<TViewModel> EditarAsync(TViewModel viewModel);
        bool Excluir(Guid id);
        Task<bool> ExcluirAsync(Guid id);
        TViewModel Consultar(Guid id);
        Task<TViewModel> ConsultarAsync(Guid id);
        List<TViewModel> Listar();
        Task<List<TViewModel>> ListarAsync();
        Task<ResultList<TViewModel>> ListarAsync(FilterList filtro);
    }
}
