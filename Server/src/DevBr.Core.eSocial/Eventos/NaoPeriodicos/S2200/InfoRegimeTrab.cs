using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class InfoRegimeTrab : EntityType<InfoRegimeTrab>, IDisposable
    {
        public InfoCeletista? InfoCeletista { get; set; }
        public InfoEstatutario? InfoEstatutario { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoRegimeTrab));
            element.Add(InfoCeletista?.GetXmlElements(ns));
            element.Add(InfoEstatutario?.GetXmlElements(ns));
            return element;

        }
    }
}
