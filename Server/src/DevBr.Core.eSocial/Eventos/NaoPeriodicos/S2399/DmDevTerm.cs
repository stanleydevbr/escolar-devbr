using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2399
{
    public class DmDevTerm : EntityType<DmDevTerm>, IDisposable
    {
        public string? IdeDmDev { get; set; }
        public List<IdeEstabLot>? Estabelecimentos { get; set; }
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

            XElement element = new XElement(ns + "DmDev");
            element.Add(new XElement(ns + nameof(IdeDmDev), IdeDmDev));
            Estabelecimentos?.ForEach(estab => element.Add(estab?.GetXmlElements(ns)));
            return element;

        }
    }

}
