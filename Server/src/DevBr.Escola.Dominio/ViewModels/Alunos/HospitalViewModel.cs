using DevBr.Core.Dominio.ViewModels;

namespace DevBr.Escola.Dominio.ViewModels.Alunos
{
    public class HospitalViewModel : ViewModelCore
    {
        public string Nome { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
