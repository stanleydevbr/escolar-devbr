using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2206
{
    public class AltContratual : EntityType<AltContratual>, IDisposable
    {
        public DateTime? DtAlteracao { get; set; }
        public DateTime? DtEf { get; set; }
        public string? DscAlt { get; set; }
        public Vinculo? Vinculo { get; set; }
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
            XElement element = new XElement(ns + nameof(AltContratual));
            element.Add(new XElement(ns + nameof(DtAlteracao), DtAlteracao));
            element.Add(new XElement(ns + nameof(DtEf), DtEf?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DscAlt), DscAlt));
            element.Add(Vinculo?.GetXmlElements(ns));
            return element;

        }
    }
}
