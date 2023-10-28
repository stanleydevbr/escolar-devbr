using DevBr.Core.Dominio.Entidades;
using FluentValidation;

namespace DevBr.Escola.Dominio.Entidades.Alunos
{
    public class Medicacao : Entity<Medicacao>
    {
        public string Nome { get; set; }
        public string Observacao { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da medicação precisa ser informada");

            RuleFor(x => x.Observacao)
                .MaximumLength(500)
                .WithMessage("A observação não pode ter mais de 500 caracteres");

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