using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2220
{
    public class RespMonit : EntityType<RespMonit>, IDisposable
    {
        public string? CpfResp { get; set; }
        public string? NmResp { get; set; }
        public string? NrCRM { get; set; }
        public string? UfCRM { get; set; }
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

            XElement element = new XElement(ns + nameof(RespMonit));
            element.Add(new XElement(ns + nameof(CpfResp), CpfResp));
            element.Add(new XElement(ns + nameof(NmResp), NmResp));
            element.Add(new XElement(ns + nameof(NrCRM), NrCRM));
            element.Add(new XElement(ns + nameof(UfCRM), UfCRM));
            return element;

        }
    }
}
