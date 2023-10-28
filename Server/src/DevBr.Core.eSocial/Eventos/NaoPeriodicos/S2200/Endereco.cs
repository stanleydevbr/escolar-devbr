using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Endereco : EntityType<Endereco>, IDisposable
    {
        public Brasil? Brasil { get; set; }
        public Exterior? Exterior { get; set; }
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

            XElement element = new XElement(ns + nameof(Endereco));
            element.Add(Brasil?.GetXmlElements(ns));
            element.Add(Exterior?.GetXmlElements(ns));
            return element;

        }
    }
}
