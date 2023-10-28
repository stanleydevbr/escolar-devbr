using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Matriculas;

namespace DevBr.Escola.Dominio.Interfaces.Repositories.Matriculas
{
    public interface IMatriculaRepository : IRepositoryCore<Matricula>
    {
        public IRepositoryCore<Periodo> Periodo { get; set; }
        public IRepositoryCore<Turma> Turma { get; set; }
    }
}
