using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2306
{
    public class InfoMandEletAlt : EntityType<InfoMandEletAlt>, IDisposable
    {
        public char? IndRemunCargo { get; set; }
        public uint? TpRegPrev { get; set; }
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

            XElement element = new XElement(ns + "InfoMandElet");
            element.Add(new XElement(ns + nameof(IndRemunCargo), IndRemunCargo));
            element.Add(new XElement(ns + nameof(TpRegPrev), TpRegPrev));
            return element;

        }
    }
}
