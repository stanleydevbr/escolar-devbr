using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class TransfTit : EntityType<TransfTit>, IDisposable
    {
        public string? CpfSubstituto { get; set; }
        public DateTime? DtNascto { get; set; }
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
            XElement element = new XElement(ns + nameof(TransfTit));
            element.Add(new XElement(ns + nameof(CpfSubstituto), CpfSubstituto));
            element.Add(new XElement(ns + nameof(DtNascto), DtNascto?.ToString("dd-MM-yyyy")));
            return element;
        }
    }
}
