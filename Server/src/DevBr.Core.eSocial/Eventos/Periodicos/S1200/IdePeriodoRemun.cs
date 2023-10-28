using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class IdePeriodoRemun : EntityType<IdePeriodoRemun>, IDisposable
    {
        public DateTime? PerRef { get; set; }
        public List<IdeEstabLotRemun>? IdeEstabLot { get; set; }
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
            IdeEstabLot?.ForEach(lot => element.Add(lot?.GetXmlElements(ns)));
            return element;

        }
    }
}
