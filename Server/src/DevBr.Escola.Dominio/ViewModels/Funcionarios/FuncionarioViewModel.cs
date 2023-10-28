using DevBr.Core.Dominio.ViewModels;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.ViewModels.Funcionarios
{
    public class FuncionarioViewModel : ViewModelCore
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Identidade { get; set; }
        public string Cpf { get; set; }
        public decimal Salario { get; set; }
        public CargoViewModel Cargo { get; set; }
        public List<AtividadeViewModel> Atividades { get; set; }
    }
}
