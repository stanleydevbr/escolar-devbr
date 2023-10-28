using DevBr.Core.Dominio.ViewModels;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.ViewModels.Empresas
{
    public class SalaViewModel : ViewModelCore
    {
        public string Descricao { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public List<RecursoViewModel> Recursos { get; set; }
    }
}
