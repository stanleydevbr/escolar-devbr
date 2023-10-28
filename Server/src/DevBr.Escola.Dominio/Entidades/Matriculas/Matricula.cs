using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Matriculas
{
    public class Matricula : Entity<Matricula>
    {
        public Matricula()
        {
            Id = Guid.NewGuid();
        }
        public List<Periodo> Periodos { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Periodos)
                .NotNull()
                .WithMessage("O periodo precisa ser informado");

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
