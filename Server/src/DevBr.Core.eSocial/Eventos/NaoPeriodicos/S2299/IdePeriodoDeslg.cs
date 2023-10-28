using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class IdePeriodoDeslg : EntityType<IdePeriodoDeslg>, IDisposable
    {
        public DateTime? PerRef { get; set; }
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

            XElement element = new XElement(ns + "IdePeriodo");
            element.Add(new XElement(ns + nameof(PerRef), PerRef?.ToString("yyyy-MM")));
            Estabelecimentos?.ForEach(estab => element.Add(estab?.GetXmlElements(ns)));
            return element;

        }
    }
}
