using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InfoTrab : EntityType<InfoTrab>, IDisposable
    {
        public InfoApr? InfoApr { get; set; }
        public InfoPcd? InfoPcd { get; set; }
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
            var element = new XElement(ns + nameof(InfoTrab));
            element.Add(InfoApr?.GetXmlElements(ns));
            element.Add(InfoPcd?.GetXmlElements(ns));
            return element;
        }
    }
}
