using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2220
{
    public class Medico : EntityType<Medico>, IDisposable
    {
        public string? NmMed { get; set; }
        public string? NrCRM { get; set; }
        public string? UfCRM { get; set; }
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
            XElement element = new XElement(ns + nameof(Medico));
            element.Add(new XElement(ns + nameof(NmMed), NmMed));
            element.Add(new XElement(ns + nameof(NrCRM), NrCRM));
            element.Add(new XElement(ns + nameof(UfCRM), UfCRM));
            return element;
        }
    }
}
