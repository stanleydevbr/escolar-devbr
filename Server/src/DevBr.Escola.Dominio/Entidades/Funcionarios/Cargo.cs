using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;

namespace DevBr.Escola.Dominio.Entidades.Funcionarios
{
    public class Cargo : Entity<Cargo>
    {
        public Cargo()
        {
            Id = Guid.NewGuid();
        }
        public string Descricao { get; set; }
        public string Cbo { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição do cargo precisa ser informada");

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