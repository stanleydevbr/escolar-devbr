using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class ItensRemun : EntityType<ItensRemun>, IDisposable
    {
        public string? CodRubr { get; set; }
        public string? IdeTabRubr { get; set; }
        public double? QtdRubr { get; set; }
        public double? FatorRubr { get; set; }
        public double? VrRubr { get; set; }
        public uint? IndApurIR { get; set; }
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

            XElement element = new XElement(ns + nameof(ItensRemun));
            element.Add(new XElement(ns + nameof(CodRubr), CodRubr));
            element.Add(new XElement(ns + nameof(IdeTabRubr), IdeTabRubr));
            element.Add(new XElement(ns + nameof(QtdRubr), QtdRubr));
            element.Add(new XElement(ns + nameof(FatorRubr), FatorRubr));
            element.Add(new XElement(ns + nameof(VrRubr), VrRubr));
            element.Add(new XElement(ns + nameof(IndApurIR), IndApurIR));
            return element;

        }
    }
}
