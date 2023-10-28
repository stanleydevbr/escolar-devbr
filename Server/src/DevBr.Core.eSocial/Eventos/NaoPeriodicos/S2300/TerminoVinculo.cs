using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class TerminoVinculo : EntityType<TerminoVinculo>, IDisposable
    {
        public DateTime DtTerm { get; set; }
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

            XElement element = new XElement(ns + "Termino");
            element.Add(new XElement(ns + nameof(DtTerm), DtTerm));
            return element;

        }
    }
}
