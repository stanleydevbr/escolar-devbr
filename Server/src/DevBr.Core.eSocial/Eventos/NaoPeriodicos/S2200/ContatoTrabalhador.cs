using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class ContatoTrabalhador : EntityType<ContatoTrabalhador>, IDisposable
    {
        public string? FonePrinc { get; set; }
        public string? EmailPrinc { get; set; }
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

            XElement element = new XElement(ns + "Contato");
            element.Add(new XElement(ns + nameof(FonePrinc), FonePrinc));
            element.Add(new XElement(ns + nameof(EmailPrinc), EmailPrinc));
            return element;

        }
    }
}
