using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;

namespace DevBr.Escola.Dominio.Entidades.Alunos
{
    public class Medico : Entity<Medico>
    {
        public Medico()
        {
            Id = Guid.NewGuid();
        }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public override bool EhValido()
        {

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do médico precisa ser informado")
                .Length(3, 100)
                .WithMessage("O nome do médico precisa ter entre 3 a 100 caracteres");

            RuleFor(x => x.Especialidade)
                .MaximumLength(100)
                .WithMessage("A especialidade não pode ter mas que 100 caracteres");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("O número de telefone precisa ser informado")
                .MaximumLength(13)
                .WithMessage("O número de telefone não pode ter mais que 13 caracteres");

            RuleFor(x => x.Email)
                .MaximumLength(100)
                .WithMessage("O e-mail não pode ter mais que 100 caracteres");

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