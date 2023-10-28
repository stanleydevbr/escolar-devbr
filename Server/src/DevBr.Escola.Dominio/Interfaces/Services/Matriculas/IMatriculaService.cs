using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Matriculas;

namespace DevBr.Escola.Dominio.Interfaces.Services.Matriculas
{
    public interface IMatriculaService : IServiceCore<Matricula>
    {
        public IServiceCore<Periodo> PeriodoService { get; set; }
        public IServiceCore<Turma> TurmaService { get; set; }
    }
}
