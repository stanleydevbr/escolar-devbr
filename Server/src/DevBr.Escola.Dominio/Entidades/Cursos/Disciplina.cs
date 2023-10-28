using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;

namespace DevBr.Escola.Dominio.Entidades.Cursos
{
    public class Disciplina : Entity<Disciplina>
    {
        public Disciplina()
        {
            Id = Guid.NewGuid();
        }
        public string Nome { get; set; }
        public decimal? Media { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da disciplina precisa ser informada")
                .MaximumLength(100)
                .WithMessage("O nome da disciplina não pode ter mais que 100 caracteres");

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