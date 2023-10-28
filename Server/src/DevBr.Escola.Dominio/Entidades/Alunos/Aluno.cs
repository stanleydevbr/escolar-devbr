using DevBr.Core.Dominio.Entidades;
using DevBr.Escola.Dominio.Entidades.ComplexTypes;
using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Entidades.Matriculas;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Alunos
{
    public class Aluno : Entity<Aluno>
    {
        public Aluno()
        {
            Id = Guid.NewGuid();
        }
        public Matricula Matricula { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Identidade { get; set; }
        public string CPF { get; set; }
        public string NomeDoPai { get; set; }
        public string NomeDaMae { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string EscolaOrigem { get; set; }
        public ICollection<Curso> Cursos { get; set; }
        public Guid CursoId { get; set; }
        public Endereco Endereco { get; set; }
        public Guid EnderecoId { get; set; }
        public FichaMedica FichaMedica { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome precisa ser informado")
                .Length(4, 60)
                .WithMessage("O nome precisa ter entre 4 a 60 caracteres");

            RuleFor(x => x.SobreNome)
                .NotEmpty()
                .WithMessage("O sobre nome precisa ser informado")
                .Length(3, 60)
                .WithMessage("O sobre nome precisa ter entre 3 a 60 caracteres");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("A data de nascimento precisa ser preenchida")
                .GreaterThan(DateTime.Now.Date)
                .WithMessage("A data de nascimento não pode ser maior que a data atual");

            RuleFor(x => x.Genero)
                .NotEmpty()
                .WithMessage("O genero precisa ser informado");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("O CPF precisa ser informado");

            RuleFor(x => x.NomeDaMae)
                .NotEmpty()
                .WithMessage("O nome da mãe precisa ser informado");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("O número de telefone precisa ser informado");

            RuleFor(x => x.Celular)
                .NotEmpty()
                .WithMessage("O número de celular precisa ser informado");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail precisa ser informado")
                .Length(3, 60)
                .WithMessage("O e-mail precisa ter entre 11 a 100 caracteres");

            RuleFor(x => x.UsuarioCriacao)
                .NotEmpty()
                .WithMessage("O usuário de de cadastro precisa ser informado");

            RuleFor(x => x.DataCriacao)
                .NotEmpty()
                .WithMessage("A data de cadastro precisa ser informada");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
