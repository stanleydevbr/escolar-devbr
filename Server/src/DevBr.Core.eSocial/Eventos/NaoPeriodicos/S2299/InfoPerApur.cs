using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class InfoPerApur : EntityType<InfoPerApur>, IDisposable
    {
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

            XElement element = new XElement(ns + nameof(InfoPerApur));
            Estabelecimentos?.ForEach(estab => element.Add(estab?.GetXmlElements(ns)));
            return element;

        }
    }
}
