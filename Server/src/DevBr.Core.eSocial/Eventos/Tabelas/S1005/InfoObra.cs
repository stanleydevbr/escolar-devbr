using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InfoObra : EntityType<InfoObra>, IDisposable
    {
        public byte IndSubstPatrObra { get; set; }
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
            var element = new XElement(ns + nameof(InfoObra));
            element.Add(new XElement(ns + nameof(IndSubstPatrObra), IndSubstPatrObra));
            return element;
        }
    }
}
