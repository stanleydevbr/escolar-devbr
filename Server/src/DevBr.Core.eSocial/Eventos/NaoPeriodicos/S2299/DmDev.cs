using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class DmDev : EntityType<DmDev>, IDisposable
    {
        public string? IdeDmDev { get; set; }
        public InfoPerApur? InfoPerApur { get; set; }
        public InfoPerAnt? InfoPerAnt { get; set; }

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
            XElement element = new XElement(ns + nameof(DmDev));
            element.Add(new XElement(ns + nameof(IdeDmDev), IdeDmDev));
            element.Add(InfoPerApur?.GetXmlElements(ns));
            element.Add(InfoPerAnt?.GetXmlElements(ns));
            return element;

        }
    }
}
