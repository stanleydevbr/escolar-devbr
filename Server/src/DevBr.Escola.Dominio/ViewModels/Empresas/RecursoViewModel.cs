using DevBr.Core.Dominio.ViewModels;

namespace DevBr.Escola.Dominio.ViewModels.Empresas
{
    public class RecursoViewModel : ViewModelCore
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal? ValorUnitario { get; set; }
        public string Observacao { get; set; }
    }
}
