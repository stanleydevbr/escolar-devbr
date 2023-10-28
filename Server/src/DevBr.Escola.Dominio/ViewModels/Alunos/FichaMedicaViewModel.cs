using DevBr.Core.Dominio.ViewModels;
using System;
using System.Collections.Generic;

namespace DevBr.Escola.Dominio.ViewModels.Alunos
{
    public class FichaMedicaViewModel : ViewModelCore
    {
        public string TipoSanguineo { get; set; }
        public Guid MedicoId { get; set; }
        public Guid HospitalId { get; set; }
        public string Observacao { get; set; }
        public List<DoencaViewModel> Doencas { get; set; }
        public List<MedicacaoViewModel> Medicacoes { get; set; }
    }
}
