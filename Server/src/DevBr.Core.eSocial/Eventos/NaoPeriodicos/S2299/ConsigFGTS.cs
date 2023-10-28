using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class ConsigFGTS : EntityType<ConsigFGTS>, IDisposable
    {
        public string? InsConsig { get; set; }
        public string? NrContr { get; set; }
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

            XElement element = new XElement(ns + nameof(ConsigFGTS));
            element.Add(new XElement(ns + nameof(InsConsig), InsConsig));
            element.Add(new XElement(ns + nameof(NrContr), NrContr));
            return element;

        }
    }
}
