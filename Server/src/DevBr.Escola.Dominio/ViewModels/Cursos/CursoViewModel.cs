using DevBr.Core.Dominio.ViewModels;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.ViewModels.Cursos
{
    public class CursoViewModel : ViewModelCore
    {
        public string Nome { get; set; }
        public List<DisciplinaViewModel> Disciplinas { get; set; }
    }
}
