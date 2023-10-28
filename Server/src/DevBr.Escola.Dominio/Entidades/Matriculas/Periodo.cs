using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Matriculas
{
    public class Periodo : Entity<Periodo>
    {
        public Periodo()
        {
            Id = Guid.NewGuid();
        }
        public List<Turma> Turmas { get; set; }
        public int AnoLetivo { get; set; }
        public DateTime InicioMatricula { get; set; }
        public DateTime TerminoMatricula { get; set; }
        public DateTime InicioAnoLetivo { get; set; }
        public DateTime TerminoAnoLetivo { get; set; }

        public override bool EhValido()
        {

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