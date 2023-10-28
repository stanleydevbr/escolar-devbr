using System;

namespace DevBr.Core.Dominio.ViewModels
{
    public class ViewModelCore : BaseViewModel
    {
        public Guid Id { get; set; }
        public string UsuarioCriacao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
