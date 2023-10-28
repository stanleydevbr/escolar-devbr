using DevBr.Core.Dominio.ViewModels;

namespace DevBr.Escola.Dominio.ViewModels.Alunos
{
    public class MedicoViewModel : ViewModelCore
    {
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
