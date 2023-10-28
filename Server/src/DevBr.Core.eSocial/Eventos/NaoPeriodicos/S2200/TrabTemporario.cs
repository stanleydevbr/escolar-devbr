using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class TrabTemporario : EntityType<TrabTemporario>, IDisposable
    {
        public byte? HipLeg { get; set; }
        public string? JustContr { get; set; }
        public IdeEstabVinc? IdeEstabVinc { get; set; }
        public List<IdeTrabSubstituido>? IdeTrabSubstituidos { get; set; }
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

            XElement element = new XElement(ns + nameof(TrabTemporario));
            element.Add(new XElement(ns + nameof(HipLeg), HipLeg));
            element.Add(new XElement(ns + nameof(JustContr), JustContr));
            element.Add(IdeEstabVinc?.GetXmlElements(ns));
            IdeTrabSubstituidos?.ForEach(trab => element.Add(trab.GetXmlElements(ns)));
            return element;
        }
    }
}
