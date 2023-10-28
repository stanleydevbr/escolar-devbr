using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class InfoDeficiencia : EntityType<InfoDeficiencia>, IDisposable
    {
        public char? DefFisica { get; set; }
        public char? DefVisual { get; set; }
        public char? DefAuditiva { get; set; }
        public char? DefMental { get; set; }
        public char? DefIntelectual { get; set; }
        public char? ReabReadap { get; set; }
        public char? InfoCota { get; set; }
        public string? Observacao { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoDeficiencia));
            element.Add(new XElement(ns + nameof(DefFisica), DefFisica));
            element.Add(new XElement(ns + nameof(DefVisual), DefVisual));
            element.Add(new XElement(ns + nameof(DefAuditiva), DefAuditiva));
            element.Add(new XElement(ns + nameof(DefMental), DefMental));
            element.Add(new XElement(ns + nameof(DefIntelectual), DefIntelectual));
            element.Add(new XElement(ns + nameof(ReabReadap), ReabReadap));
            element.Add(new XElement(ns + nameof(InfoCota), InfoCota));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            return element;

        }
    }
}
