using AutoMapper;
using DevBr.Core.Aplicacao.Services;
using DevBr.Escola.Aplicacao.Interfaces.Cursos;
using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Interfaces.Services.Cursos;
using DevBr.Escola.Dominio.ViewModels.Cursos;

namespace DevBr.Escola.Aplicacao.AppServices.Cursos
{
    public class CursoApp : AppServiceCore<CursoViewModel, Curso>, ICursoApp
    {
        private readonly new ICursoService _service;
        public CursoApp(ICursoService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }


}
