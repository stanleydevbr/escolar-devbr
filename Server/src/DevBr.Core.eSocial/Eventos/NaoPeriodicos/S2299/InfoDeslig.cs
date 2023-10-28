using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class InfoDeslig : EntityType<InfoDeslig>, IDisposable
    {
        public string? MtvDeslig { get; set; }
        public DateTime? DtDeslig { get; set; }
        public DateTime? DtAvPrv { get; set; }
        public char? IndPagtoAPI { get; set; }
        public DateTime? DtProjFimAPI { get; set; }
        public uint? PensAlim { get; set; }
        public double? PercAliment { get; set; }
        public double? VrAlim { get; set; }
        public string? NrProcTrab { get; set; }
        public List<InfoInterm>? InfoIterms { get; set; }
        public List<Observacoes>? Observacoes { get; set; }
        public SucessaoVincDeslg? SucessaoVinc { get; set; }
        public TransfTit? TransfTit { get; set; }
        public MudancaCPF? MudancaCPF { get; set; }
        public VerbasResc? VerbasResc { get; set; }
        public Quarentena? Quarentena { get; set; }
        public ConsigFGTS? ConsigFGTS { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoDeslig));
            element.Add(new XElement(ns + nameof(MtvDeslig), MtvDeslig));
            element.Add(new XElement(ns + nameof(DtDeslig), DtDeslig?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DtAvPrv), DtAvPrv?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(IndPagtoAPI), IndPagtoAPI));
            element.Add(new XElement(ns + nameof(DtProjFimAPI), DtProjFimAPI?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(PensAlim), PensAlim));
            element.Add(new XElement(ns + nameof(PercAliment), PercAliment));
            element.Add(new XElement(ns + nameof(VrAlim), VrAlim));
            element.Add(new XElement(ns + nameof(NrProcTrab), NrProcTrab));
            InfoIterms?.ForEach(info => element.Add(info?.GetXmlElements(ns)));
            Observacoes?.ForEach(obs => element.Add(obs?.GetXmlElements(ns)));
            element.Add(SucessaoVinc?.GetXmlElements(ns));
            element.Add(TransfTit?.GetXmlElements(ns));
            element.Add(MudancaCPF?.GetXmlElements(ns));
            element.Add(VerbasResc?.GetXmlElements(ns));
            element.Add(Quarentena?.GetXmlElements(ns));
            element.Add(ConsigFGTS?.GetXmlElements(ns));
            return element;

        }
    }
}
