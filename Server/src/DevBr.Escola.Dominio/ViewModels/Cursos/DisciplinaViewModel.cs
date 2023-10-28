using DevBr.Core.Dominio.ViewModels;

namespace DevBr.Escola.Dominio.ViewModels.Cursos
{
    public class DisciplinaViewModel : ViewModelCore
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public decimal? Media { get; set; }
    }
}
