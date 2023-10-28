using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class IdeADC : EntityType<IdeADC>, IDisposable
    {
        public DateTime? DtAcConv { get; set; }
        public char? TpAcConv { get; set; }
        public string? Dsc { get; set; }
        public List<IdePeriodoDeslg>? IdeADCs { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeADC));
            element.Add(new XElement(ns + nameof(DtAcConv), DtAcConv?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(TpAcConv), TpAcConv));
            element.Add(new XElement(ns + nameof(Dsc), Dsc));
            IdeADCs?.ForEach(s => element.Add(s.GetXmlElements(ns)));
            return element;

        }
    }
}
