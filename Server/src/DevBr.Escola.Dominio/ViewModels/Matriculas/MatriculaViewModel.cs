using DevBr.Core.Dominio.ViewModels;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.ViewModels.Matriculas
{
    public class MatriculaViewModel : ViewModelCore
    {
        public int Codigo { get; set; }
        public List<PeriodoViewModel> Periodos { get; set; }
    }
}
