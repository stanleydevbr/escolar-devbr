using DevBr.Core.Dominio.Entidades;
using DevBr.Escola.Dominio.Entidades.ComplexTypes;
using FluentValidation;

namespace DevBr.Escola.Dominio.Entidades.Alunos
{
    public class Hospital : Entity<Hospital>
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do hospital precisa ser informado")
                .Length(3, 100)
                .WithMessage("O nome do hospital precisa ter entre 3 a 100 caracteres");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("O número de telefone precisa ser informado");

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