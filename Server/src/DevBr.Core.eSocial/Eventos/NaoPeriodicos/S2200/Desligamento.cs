using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Desligamento : EntityType<Desligamento>, IDisposable
    {
        public DateTime? DtDeslig { get; set; }
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

            XElement element = new XElement(ns + nameof(Desligamento));
            element.Add(new XElement(ns + nameof(DtDeslig), DtDeslig));
            return element;

        }
    }
}
