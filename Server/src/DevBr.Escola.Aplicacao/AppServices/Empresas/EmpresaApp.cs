using AutoMapper;
using DevBr.Core.Aplicacao.Services;
using DevBr.Escola.Aplicacao.Interfaces.Empresas;
using DevBr.Escola.Dominio.Entidades.Empresas;
using DevBr.Escola.Dominio.Interfaces.Services.Empresas;
using DevBr.Escola.Dominio.ViewModels.Empresas;

namespace DevBr.Escola.Aplicacao.AppServices.Empresas
{
    public class EmpresaApp : AppServiceCore<EmpresaViewModel, Empresa>, IEmpresaApp
    {
        private readonly new IEmpresaService _service;
        public EmpresaApp(IEmpresaService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
