using AutoMapper;
using DevBr.Core.Aplicacao.Services;
using DevBr.Escola.Aplicacao.Interfaces.Matriculas;
using DevBr.Escola.Dominio.Entidades.Matriculas;
using DevBr.Escola.Dominio.Interfaces.Services.Matriculas;
using DevBr.Escola.Dominio.ViewModels.Matriculas;

namespace DevBr.Escola.Aplicacao.AppServices.Matriculas
{
    public class MatriculaApp : AppServiceCore<MatriculaViewModel, Matricula>, IMatriculaApp
    {
        private readonly new IMatriculaService _service;
        public MatriculaApp(IMatriculaService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
