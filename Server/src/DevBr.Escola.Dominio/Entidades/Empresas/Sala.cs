using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Empresas
{
    public class Sala : Entity<Sala>
    {
        public Sala()
        {
            Id = Guid.NewGuid();
        }
        public string Descricao { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public List<Recurso> Recursos { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição da sala precisa ser informada")
                .Length(3, 20)
                .WithMessage("A descrição da sala precisa ter entre 3 a 20 caracteres");

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