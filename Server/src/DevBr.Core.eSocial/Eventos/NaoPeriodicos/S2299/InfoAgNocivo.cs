using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class InfoAgNocivo : EntityType<InfoAgNocivo>, IDisposable
    {
        public uint? GrauExp { get; set; }

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

            XElement element = new XElement(ns + nameof(InfoAgNocivo));
            element.Add(new XElement(ns + nameof(GrauExp), GrauExp));
            return element;

        }
    }
}
