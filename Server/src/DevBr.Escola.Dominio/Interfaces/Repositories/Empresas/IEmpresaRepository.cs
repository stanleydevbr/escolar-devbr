using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Empresas;

namespace DevBr.Escola.Dominio.Interfaces.Repositories.Empresas
{
    public interface IEmpresaRepository : IRepositoryCore<Empresa>
    {
        public IRepositoryCore<Recurso> Recurso { get; set; }
        public IRepositoryCore<Sala> Sala { get; set; }
    }
}
