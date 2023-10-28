using AutoMapper;
using DevBr.Core.Aplicacao.Services;
using DevBr.Escola.Aplicacao.Interfaces.Funcionarios;
using DevBr.Escola.Dominio.Entidades.Funcionarios;
using DevBr.Escola.Dominio.Interfaces.Services.Funcionarios;
using DevBr.Escola.Dominio.ViewModels.Funcionarios;

namespace DevBr.Escola.Aplicacao.AppServices.Funcionarios
{
    public class FuncionarioApp : AppServiceCore<FuncionarioViewModel, Funcionario>, IFuncionarioApp
    {
        private readonly new IFuncionarioService _service;
        public FuncionarioApp(IFuncionarioService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
