using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;

namespace DevBr.Escola.Dominio.Entidades.Empresas
{
    public class Recurso : Entity<Recurso>
    {
        public Recurso()
        {
            Id = Guid.NewGuid();
        }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal? ValorUnitario { get; set; }
        public string Observacao { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição do recurso precisa ser informada");

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