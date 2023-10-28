using DevBr.Core.Dominio.Entidades;

namespace DevBr.Escola.Dominio.Entidades.ComplexTypes
{
    public class Endereco : Entity<Endereco>
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}