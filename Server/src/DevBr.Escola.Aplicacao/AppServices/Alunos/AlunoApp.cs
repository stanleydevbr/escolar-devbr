using AutoMapper;
using DevBr.Core.Aplicacao.Services;
using DevBr.Escola.Aplicacao.Interfaces.Alunos;
using DevBr.Escola.Dominio.Entidades.Alunos;
using DevBr.Escola.Dominio.Interfaces.Services.Alunos;
using DevBr.Escola.Dominio.ViewModels.Alunos;

namespace DevBr.Escola.Aplicacao.AppServices.Alunos
{
    public class AlunoApp : AppServiceCore<AlunoViewModel, Aluno>, IAlunoApp
    {
        private readonly new IAlunoService _service;
        public AlunoApp(IAlunoService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
