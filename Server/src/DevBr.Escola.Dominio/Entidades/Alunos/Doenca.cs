using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;

namespace DevBr.Escola.Dominio.Entidades.Alunos
{
    public class Doenca : Entity<Doenca>
    {
        public Doenca()
        {
            Id = Guid.NewGuid();
        }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da doença precisa ser informado")
                .Length(3, 60)
                .WithMessage("O nome da doença precisa ter entre 3 a 60 caracteres");

            RuleFor(x => x.Observacao)
                .MaximumLength(500)
                .WithMessage("A observação não pode ter mais que 500 caracteres");

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