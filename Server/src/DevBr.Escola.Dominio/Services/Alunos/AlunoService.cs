using DevBr.Core.Dominio.Interfaces;
using DevBr.Core.Dominio.Services;
using DevBr.Escola.Dominio.Entidades.Alunos;
using DevBr.Escola.Dominio.Interfaces.Repositories.Alunos;
using DevBr.Escola.Dominio.Interfaces.Services.Alunos;

namespace DevBr.Escola.Dominio.Services.Alunos
{
    public class AlunoService : ServiceCore<Aluno>, IAlunoService
    {
        public new readonly IAlunoRepository _repository;
        public IServiceCore<Doenca> DoencaService { get; set; }
        public IServiceCore<FichaMedica> FichaMedicaService { get; set; }
        public IServiceCore<Hospital> HospitalService { get; set; }
        public IServiceCore<Medicacao> MedicacaoService { get; set; }
        public IServiceCore<Medico> MedicoService { get; set; }
        public AlunoService(IAlunoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
