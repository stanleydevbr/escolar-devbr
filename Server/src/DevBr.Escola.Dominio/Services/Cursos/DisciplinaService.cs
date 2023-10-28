using DevBr.Core.Dominio.Services;
using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Interfaces.Repositories.Cursos;
using DevBr.Escola.Dominio.Interfaces.Services.Cursos;

namespace DevBr.Escola.Dominio.Services.Cursos
{
    public class DisciplinaService : ServiceCore<Disciplina>, IDisciplinaService
    {
        private new readonly IDisciplinaRepository _repository;
        public DisciplinaService(IDisciplinaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
