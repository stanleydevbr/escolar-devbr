using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class SituacaoPj : EntityType<SituacaoPj>, IDisposable
    {
        public int IndSitPJ { get; set; }

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
            var elements = new XElement(ns + nameof(IndSitPJ), IndSitPJ);
            return elements;
        }
    }
}
