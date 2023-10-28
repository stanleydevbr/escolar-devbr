using DevBr.Core.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Alunos
{
    public class FichaMedica : Entity<FichaMedica>
    {
        public FichaMedica()
        {
            Id = Guid.NewGuid();
        }
        public string TipoSanguineo { get; set; }
        public Medico Medico { get; set; }
        public Guid MedicoId { get; set; }
        public Hospital Hospital { get; set; }
        public Guid HospitalId { get; set; }
        public string Observacao { get; set; }
        public ICollection<Doenca> Doencas { get; set; }
        public ICollection<Medicacao> Medicacoes { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.TipoSanguineo)
                .NotEmpty()
                .WithMessage("O tipo sanguineo precisa ser informado");

            RuleFor(x => x.Observacao)
                .MaximumLength(500)
                .WithMessage("A observação não pode ter mas que 500 caracteres");

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