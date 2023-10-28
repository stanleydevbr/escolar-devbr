using AutoMapper;
using DevBr.Core.Aplicacao.Services;
using DevBr.Escola.Aplicacao.Interfaces.Cursos;
using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Interfaces.Services.Cursos;
using DevBr.Escola.Dominio.ViewModels.Cursos;

namespace DevBr.Escola.Aplicacao.AppServices.Cursos
{
    public class DisciplinaApp : AppServiceCore<DisciplinaViewModel, Disciplina>, IDisciplinaApp
    {
        private readonly new IDisciplinaService _service;
        public DisciplinaApp(IDisciplinaService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }


}
