using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Cursos
{
    public class Curso : Entity<Curso>
    {
        public Curso()
        {
            Id = Guid.NewGuid();
        }
        public string Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do curso/série precisa ser informado");

            RuleForEach(x => x.Disciplinas)
                .NotNull()
                .WithMessage("As disciplinas do curso precisa ser informada");

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