using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Dominio.Services;
using DevBr.Escola.Dominio.Entidades.Matriculas;
using DevBr.Escola.Dominio.Interfaces.Repositories.Matriculas;
using DevBr.Escola.Dominio.Interfaces.Services.Matriculas;

namespace DevBr.Escola.Dominio.Services.Matriculas
{
    public class MatriculaService : ServiceCore<Matricula>, IMatriculaService
    {
        public IServiceCore<Periodo> PeriodoService { get; set; }
        public IServiceCore<Turma> TurmaService { get; set; }
        public MatriculaService(IMatriculaRepository repository) : base(repository)
        {
        }
    }

}
