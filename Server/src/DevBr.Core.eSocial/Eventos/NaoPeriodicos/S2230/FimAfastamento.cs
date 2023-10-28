using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2230
{
    public class FimAfastamento : EntityType<FimAfastamento>, IDisposable
    {
        public DateTime? DtTermAfast { get; set; }
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

            XElement element = new XElement(ns + nameof(FimAfastamento));
            element.Add(new XElement(ns + nameof(DtTermAfast), DtTermAfast));
            return element;

        }
    }
}
