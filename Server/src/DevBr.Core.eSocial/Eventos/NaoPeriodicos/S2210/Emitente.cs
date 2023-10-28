using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2210
{
    public class Emitente : EntityType<Emitente>, IDisposable
    {
        public string? NmEmit { get; set; }
        public uint? IdeOC { get; set; }
        public string? NrOC { get; set; }
        public string? UfOC { get; set; }
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
            XElement element = new XElement(ns + nameof(Emitente));
            element.Add(new XElement(ns + nameof(NmEmit), NmEmit));
            element.Add(new XElement(ns + nameof(IdeOC), IdeOC));
            element.Add(new XElement(ns + nameof(NrOC), NrOC));
            element.Add(new XElement(ns + nameof(UfOC), UfOC));
            return element;
        }
    }
}

