using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InfoCaepf : EntityType<InfoCaepf>, IDisposable
    {
        public byte TpCaepf { get; set; }
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
            var element = new XElement(ns + nameof(InfoCaepf));
            element.Add(new XElement(ns + nameof(TpCaepf), TpCaepf));
            return element;
        }
    }
}
