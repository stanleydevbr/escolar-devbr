using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class AgeIntegracao : EntityType<AgeIntegracao>, IDisposable
    {
        public string? CnpjAgntInteg { get; set; }
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

            XElement element = new XElement(ns + nameof(AgeIntegracao));
            element.Add(new XElement(ns + nameof(CnpjAgntInteg), CnpjAgntInteg));
            return element;

        }
    }
}
