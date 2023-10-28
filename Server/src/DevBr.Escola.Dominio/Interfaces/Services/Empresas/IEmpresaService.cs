using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Empresas;

namespace DevBr.Escola.Dominio.Interfaces.Services.Empresas
{
    public interface IEmpresaService : IServiceCore<Empresa>
    {
        public IServiceCore<Recurso> RecursoService { get; set; }
        public IServiceCore<Sala> SalaService { get; set; }
    }

}
