using DevBr.Core.Dominio.ViewModels;
using DevBr.Escola.Dominio.ComplexTypes;
using DevBr.Escola.Dominio.ViewModels.Alunos;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.ViewModels.Matriculas
{
    public class TurmaViewModel : ViewModelCore
    {
        public string Descricao { get; set; }
        public Turno Turno { get; set; }
        public Guid CursoId { get; set; }
        public Guid SalaId { get; set; }
        public List<AlunoViewModel> Alunos { get; set; }
    }
}
