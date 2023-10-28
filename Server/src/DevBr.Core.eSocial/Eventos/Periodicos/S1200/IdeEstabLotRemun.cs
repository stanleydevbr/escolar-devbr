using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class IdeEstabLotRemun : EntityType<IdeEstabLotRemun>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public string? CodLotacao { get; set; }
        public uint? QtdDiasAv { get; set; }
        public List<RemunPerApur>? RemunPerApur { get; set; }
        public List<RemunPerAnt>? RemunPerAnt { get; set; }
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

            XElement element = new XElement(ns + "IdeEstabLog");
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(new XElement(ns + nameof(CodLotacao), CodLotacao));
            element.Add(new XElement(ns + nameof(QtdDiasAv), QtdDiasAv));
            RemunPerApur?.ForEach(rem => element.Add(rem?.GetXmlElements(ns)));
            RemunPerAnt?.ForEach(rem => element.Add(rem?.GetXmlElements(ns)));
            return element;

        }
    }
}
