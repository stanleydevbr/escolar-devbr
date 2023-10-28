using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Nascimento : EntityType<Nascimento>, IDisposable
    {
        public DateTime? DtNascto { get; set; }
        public string? PaisNascto { get; set; }
        public string? PaisNac { get; set; }
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
            XElement element = new XElement(ns + nameof(Nascimento));
            element.Add(new XElement(ns + nameof(DtNascto), DtNascto));
            element.Add(new XElement(ns + nameof(PaisNascto), PaisNascto));
            element.Add(new XElement(ns + nameof(PaisNac), PaisNac));
            return element;

        }
    }
}
