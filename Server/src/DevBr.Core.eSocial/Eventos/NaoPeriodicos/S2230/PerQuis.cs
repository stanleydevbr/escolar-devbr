using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2230
{
    public class PerQuis : EntityType<PerQuis>, IDisposable
    {
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }
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

            XElement element = new XElement(ns + nameof(PerQuis));
            element.Add(new XElement(ns + nameof(DtInicio), DtInicio?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DtFim), DtFim?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
