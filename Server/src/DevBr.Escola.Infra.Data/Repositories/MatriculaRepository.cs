using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Matriculas;
using DevBr.Escola.Dominio.Interfaces.Repositories.Matriculas;
using DevBr.Escola.Infra.Data.Context;
using DevBr.Escola.Infra.Data.Repositories.Base;

namespace DevBr.Escola.Infra.Data.Repositories
{
    public class MatriculaRepository : BaseRepository<Matricula>, IMatriculaRepository
    {
        public IRepositoryCore<Periodo> Periodo { get; set; }
        public IRepositoryCore<Turma> Turma { get; set; }
        public MatriculaRepository(EscolaContext context) : base(context)
        {
        }
    }
}
