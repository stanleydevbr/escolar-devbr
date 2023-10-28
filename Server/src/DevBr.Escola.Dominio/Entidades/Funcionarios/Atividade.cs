using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;

namespace DevBr.Escola.Dominio.Entidades.Funcionarios
{
    public class Atividade : Entity<Atividade>
    {
        public Atividade()
        {
            Id = Guid.NewGuid();
        }
        public string Descricao { get; set; }
        public string Frequencia { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição da atividade precisa ser informada");

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