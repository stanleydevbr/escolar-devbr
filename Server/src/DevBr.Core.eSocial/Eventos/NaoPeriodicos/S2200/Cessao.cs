using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Cessao : EntityType<Cessao>, IDisposable
    {
        public DateTime? DtIniCessao { get; set; }
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

            XElement element = new XElement(ns + nameof(Cessao));
            element.Add(new XElement(ns + nameof(DtIniCessao), DtIniCessao?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
