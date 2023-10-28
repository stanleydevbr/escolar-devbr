using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2220
{
    public class ExMedOcup : EntityType<ExMedOcup>, IDisposable
    {
        public uint? TpExameOcup { get; set; }
        public Aso? Aso { get; set; }
        public RespMonit? RespMonit { get; set; }
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
            XElement element = new XElement(ns + nameof(ExMedOcup));
            element.Add(new XElement(ns + nameof(TpExameOcup), TpExameOcup));
            element.Add(Aso?.GetXmlElements(ns));
            element.Add(RespMonit?.GetXmlElements(ns));
            return element;

        }
    }
}
