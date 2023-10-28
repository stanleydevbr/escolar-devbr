using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class AlteracaoTabEstab : EntityType<AlteracaoTabEstab>, IDisposable
    {
        public IdeEstab? IdeEstab { get; set; }
        public DadosEstab? DadosEstab { get; set; }
        public NovaValidade? NovaValidade { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            throw new NotImplementedException();
        }
    }
}
