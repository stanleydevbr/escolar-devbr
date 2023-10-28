using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2230
{
    public class InfoMandElet : EntityType<InfoMandElet>, IDisposable
    {
        public string? CnpjMandElet { get; set; }
        public char? IndRemunCargo { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoMandElet));
            element.Add(new XElement(ns + nameof(CnpjMandElet), CnpjMandElet));
            element.Add(new XElement(ns + nameof(IndRemunCargo), IndRemunCargo));
            return element;

        }
    }
}
