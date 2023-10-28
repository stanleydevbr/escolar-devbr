using DevBr.Core.Dominio.ViewModels;
using System;

namespace DevBr.Escola.Dominio.ViewModels.Alunos
{
    public class AlunoViewModel : ViewModelCore
    {
        public AlunoViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid MatriculaId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Identidade { get; set; }
        public string CPF { get; set; }
        public string NomeDoPai { get; set; }
        public string NomeDaMae { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string EscolaOrigem { get; set; }
        public Guid EnderecoId { get; set; }
        public Guid FichaMedicaId { get; set; }
    }
    public class EnderecoViewModel
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}
