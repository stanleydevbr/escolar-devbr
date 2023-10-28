using DevBr.Core.Dominio.Services;
using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Interfaces.Repositories.Cursos;
using DevBr.Escola.Dominio.Interfaces.Services.Cursos;

namespace DevBr.Escola.Dominio.Services.Cursos
{
    public class CursoService : ServiceCore<Curso>, ICursoService
    {
        private new readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
