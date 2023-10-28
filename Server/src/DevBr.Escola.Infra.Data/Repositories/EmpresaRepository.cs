using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Empresas;
using DevBr.Escola.Dominio.Interfaces.Repositories.Empresas;
using DevBr.Escola.Infra.Data.Context;
using DevBr.Escola.Infra.Data.Repositories.Base;

namespace DevBr.Escola.Infra.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public IRepositoryCore<Recurso> Recurso { get; set; }
        public IRepositoryCore<Sala> Sala { get; set; }
        public EmpresaRepository(EscolaContext context) : base(context)
        {
        }
    }
}
