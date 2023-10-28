using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1010
{
    public class DadosRubrica : EntityType<DadosRubrica>, IDisposable
    {
        public string? DscRubr { get; set; }
        public ulong? NatRubr { get; set; }
        public byte? TpRubr { get; set; }
        public string? CodIncCP { get; set; }
        public string? CodIncIRRF { get; set; }
        public string? CodIncFGTS { get; set; }
        public string? CodIncCPRP { get; set; }
        public char? TetoRemun { get; set; }
        public string? Observacao { get; set; }
        public List<IdeProcessoCP>? IdeProcessoCP { get; set; } = new List<IdeProcessoCP>();
        public List<IdeProcessoIRRF>? IdeProcessoIRRF { get; set; } = new List<IdeProcessoIRRF>();
        public List<IdeProcessoFGTS>? IdeProcessoFGTS { get; set; } = new List<IdeProcessoFGTS>();

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

            XElement element = new XElement(ns + nameof(DadosRubrica));
            element.Add(new XElement(ns + nameof(DscRubr), DscRubr));
            element.Add(new XElement(ns + nameof(NatRubr), NatRubr));
            element.Add(new XElement(ns + nameof(TpRubr), TpRubr));
            element.Add(new XElement(ns + nameof(CodIncCP), CodIncCP));
            element.Add(new XElement(ns + nameof(CodIncIRRF), CodIncIRRF));
            element.Add(new XElement(ns + nameof(CodIncFGTS), CodIncFGTS));
            element.Add(new XElement(ns + nameof(CodIncCPRP), CodIncCPRP));
            element.Add(new XElement(ns + nameof(TetoRemun), TetoRemun));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            //TODO: ajustar GetXmlElements ForEach
            IdeProcessoCP?.ForEach(x => element.Add(x.GetXmlElements(ns)));
            IdeProcessoIRRF?.ForEach(x => element.Add(x.GetXmlElements(ns)));
            IdeProcessoFGTS?.ForEach(x => element.Add(x.GetXmlElements(ns)));
            return element;

        }
    }
}
