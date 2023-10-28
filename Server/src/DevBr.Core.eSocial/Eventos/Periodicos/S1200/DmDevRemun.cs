using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class DmDevRemun : EntityType<DmDevRemun>, IDisposable
    {
        public string? IdeDmDev { get; set; }
        public string? CodCateg { get; set; }
        public InfoPerApurRemun? InfoPerApur { get; set; }
        public InfoPerAntRemun? InfoPerAnt { get; set; }
        public InfoComplCont? InfoComplCont { get; set; }
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

            XElement element = new XElement(ns + "DmDev");
            element.Add(new XElement(ns + nameof(IdeDmDev), IdeDmDev));
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            element.Add(InfoPerApur?.GetXmlElements(ns));
            element.Add(InfoPerAnt?.GetXmlElements(ns));
            element.Add(InfoComplCont?.GetXmlElements(ns));
            return element;

        }
    }
}
