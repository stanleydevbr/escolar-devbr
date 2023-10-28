using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Afastamento : EntityType<Afastamento>, IDisposable
    {
        public DateTime? DtIniAfast { get; set; }
        public string? CodMotAfast { get; set; }
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

            XElement element = new XElement(ns + nameof(Afastamento));
            element.Add(new XElement(ns + nameof(DtIniAfast), DtIniAfast));
            element.Add(new XElement(ns + nameof(CodMotAfast), CodMotAfast));
            return element;

        }
    }
}
