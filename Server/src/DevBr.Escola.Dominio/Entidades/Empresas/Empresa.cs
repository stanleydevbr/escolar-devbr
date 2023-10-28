using DevBr.Core.Dominio.Entidades;
using DevBr.Escola.Dominio.Entidades.ComplexTypes;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Empresas
{
    public class Empresa : Entity<Empresa>
    {
        public Empresa()
        {
            Id = Guid.NewGuid();
        }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public List<Sala> Salas { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da empresa precisa ser informado")
                .Length(3, 120)
                .WithMessage("O nome da empresa ter entre 3 a 120 caracteres");

            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .WithMessage("O CNPJ da empresa precisa ser informado");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("O número de telefone precisa ser informado");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail da empresa precisa ser informado");

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
