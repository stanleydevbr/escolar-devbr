using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Funcionarios
{
    public class Funcionario : Entity<Funcionario>
    {
        public Funcionario()
        {
            Id = Guid.NewGuid();
        }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Identidade { get; set; }
        public string Cpf { get; set; }
        public decimal Salario { get; set; }
        public Cargo Cargo { get; set; }
        public List<Atividade> Atividades { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do funcionário precisa ser informado")
                .Length(3, 60)
                .WithMessage("O nome do funcionário precisa ter entre 3 a 60 caracteres");

            RuleFor(x => x.SobreNome)
                .NotEmpty()
                .WithMessage("O sobrenome do funcionário precisa ser informado")
                .Length(3, 60)
                .WithMessage("O sobrenome do funcionário precisa ter entre 3 a 60 caracteres");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("A data de nascimento do funcionário precisa ser informada");

            RuleFor(x => x.Celular)
                .NotEmpty()
                .WithMessage("O celular do funcionário precisa ser informado");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do funcionário precisa ser informado");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O CPF do funcionário precisa ser informado");

            RuleFor(x => x.DataCriacao)
                .NotEmpty()
                .WithMessage("A data de cadatro precisa ser informada");

            RuleFor(x => x.UsuarioCriacao)
                .NotEmpty()
                .WithMessage("O usuário de cadastro precisa ser informado");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;

        }
    }
}
