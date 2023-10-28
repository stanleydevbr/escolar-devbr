using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class InfoContrato : EntityType<InfoContrato>, IDisposable
    {
        public string? NmCargo { get; set; }
        public string? CBOCargo { get; set; }
        public DateTime? DtIngrCargo { get; set; }
        public string? NmFuncao { get; set; }
        public string? CBOFuncao { get; set; }
        public char? AcumCargo { get; set; }
        public uint? CodCateg { get; set; }
        public Remuneracao? Remuneracao { get; set; }
        public Duracao? Duracao { get; set; }
        public LocalTrabalho? LocalTrabalho { get; set; }
        public HorContratual? HorContratual { get; set; }
        public AlvaraJudicial? AlvaraJudicial { get; set; }
        public List<string>? Observacoes { get; set; }
        public List<ulong>? TreiCaps { get; set; }


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

            XElement element = new XElement(ns + nameof(InfoContrato));
            element.Add(new XElement(ns + nameof(NmCargo), NmCargo));
            element.Add(new XElement(ns + nameof(CBOCargo), CBOCargo));
            element.Add(new XElement(ns + nameof(DtIngrCargo), DtIngrCargo));
            element.Add(new XElement(ns + nameof(NmFuncao), NmFuncao));
            element.Add(new XElement(ns + nameof(CBOFuncao), CBOFuncao));
            element.Add(new XElement(ns + nameof(AcumCargo), AcumCargo));
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            element.Add(Remuneracao?.GetXmlElements(ns));
            element.Add(Duracao?.GetXmlElements(ns));
            element.Add(LocalTrabalho?.GetXmlElements(ns));
            element.Add(HorContratual?.GetXmlElements(ns));
            element.Add(AlvaraJudicial?.GetXmlElements(ns));
            if (Observacoes?.Count() > 0)
            {
                element.Add(new XElement(ns + "Observacoes"));
                Observacoes?.ForEach(obs => element.Add(new XElement(ns + "Observacao", obs)));
            }
            if (TreiCaps?.Count() > 0)
            {
                element.Add(new XElement(ns + "TreiCap"));
                TreiCaps.ForEach(caps => element.Add(new XElement(ns + "CodTreiCap", caps)));
            }
            return element;

        }
    }
}
