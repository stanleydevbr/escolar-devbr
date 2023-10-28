using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class TransfDom : EntityType<TransfDom>, IDisposable
    {
        public string? CpfSubstituido { get; set; }
        public string? MatricAnt { get; set; }
        public DateTime? DtTransf { get; set; }
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

            XElement element = new XElement(ns + nameof(TransfDom));
            element.Add(new XElement(ns + nameof(CpfSubstituido), CpfSubstituido));
            element.Add(new XElement(ns + nameof(MatricAnt), MatricAnt));
            element.Add(new XElement(ns + nameof(DtTransf), DtTransf?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
