using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2205;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S3000
{
    public class InfoExclusao : EntityType<InfoExclusao>, IDisposable
    {
        public string? TpEvento { get; set; }
        public string? NrRecEvt { get; set; }
        public IdeTrabalhador? IdeTrabalhador { get; set; }
        public IdeFolhaPagto? IdeFolhaPagto { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoExclusao));
            element.Add(new XElement(ns + nameof(TpEvento), TpEvento));
            element.Add(new XElement(ns + nameof(NrRecEvt), NrRecEvt));
            element.Add(IdeTrabalhador?.GetXmlElements(ns));
            return element;

        }
    }
}
