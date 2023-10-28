using DevBr.Core.Dominio.Interfaces;
using DevBr.Escola.Dominio.Entidades.Alunos;

namespace DevBr.Escola.Dominio.Interfaces.Services.Alunos
{
    public interface IAlunoService : IServiceCore<Aluno>
    {
        public IServiceCore<Doenca> DoencaService { get; }
        public IServiceCore<FichaMedica> FichaMedicaService { get; }
        public IServiceCore<Hospital> HospitalService { get; }
        public IServiceCore<Medicacao> MedicacaoService { get; }
        public IServiceCore<Medico> MedicoService { get; }

    }

}
