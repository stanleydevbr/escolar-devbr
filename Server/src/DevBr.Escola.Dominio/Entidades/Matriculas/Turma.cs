using DevBr.Core.Dominio.Entidades;
using DevBr.Escola.Dominio.ComplexTypes;
using DevBr.Escola.Dominio.Entidades.Alunos;
using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Entidades.Empresas;
using DevBr.Escola.Dominio.Entidades.Funcionarios;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.Entidades.Matriculas
{
    public class Turma : Entity<Turma>
    {
        public Turma()
        {
            Id = Guid.NewGuid();
        }
        public string Descricao { get; set; }
        public Turno Turno { get; set; }
        public List<Funcionario> Professores { get; set; }
        public Curso Curso { get; set; }
        public Sala Sala { get; set; }
        public List<Aluno> Alunos { get; set; }

        public override bool EhValido()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição da turma precisa ser informada")
                .Length(3, 60)
                .WithMessage("A descrição da turma precisa ter entre 3 a 60 caracteres");

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