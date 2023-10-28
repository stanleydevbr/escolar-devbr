using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class IdeEstabLot : EntityType<IdeEstabLot>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public string? CodLotacao { get; set; }
        public List<DetVerbas>? Verbas { get; set; }
        public InfoAgNocivo? InfoAgNocivo { get; set; }
        public InfoSimples? InfoSimples { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeEstabLot));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(new XElement(ns + nameof(CodLotacao), CodLotacao));
            Verbas?.ForEach(verb => element.Add(verb.GetXmlElements(ns)));
            element.Add(InfoAgNocivo?.GetXmlElements(ns));
            element.Add(InfoSimples?.GetXmlElements(ns));
            return element;

        }
    }
}
