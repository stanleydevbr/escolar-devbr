using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Dominio.Services;
using DevBr.Escola.Dominio.Entidades.Empresas;
using DevBr.Escola.Dominio.Interfaces.Repositories.Empresas;
using DevBr.Escola.Dominio.Interfaces.Services.Empresas;

namespace DevBr.Escola.Dominio.Services.Empresas
{
    public class EmpresaService : ServiceCore<Empresa>, IEmpresaService
    {
        public IServiceCore<Recurso> RecursoService { get; set; }
        public IServiceCore<Sala> SalaService { get; set; }
        public EmpresaService(IEmpresaRepository repository) : base(repository)
        {

        }
    }

}
