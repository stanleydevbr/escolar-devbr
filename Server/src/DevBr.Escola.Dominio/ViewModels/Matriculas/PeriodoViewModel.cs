using DevBr.Core.Dominio.ViewModels;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.ViewModels.Matriculas
{
    public class PeriodoViewModel : ViewModelCore
    {
        public List<TurmaViewModel> Turmas { get; set; }
        public int AnoLetivo { get; set; }
        public DateTime InicioMatricula { get; set; }
        public DateTime TerminoMatricula { get; set; }
        public DateTime InicioAnoLetivo { get; set; }
        public DateTime TerminoAnoLetivo { get; set; }
    }
}
