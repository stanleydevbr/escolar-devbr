using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2210
{
    public class Cat : EntityType<Cat>, IDisposable
    {
        public DateTime? DtAcid { get; set; }
        public uint? TpAcid { get; set; }
        public string? HrAcid { get; set; }
        public string? HrsTrabAntesAcid { get; set; }
        public uint? TpCat { get; set; }
        public char? IndCatObito { get; set; }
        public DateTime? DtObito { get; set; }
        public char? IndComunPolicia { get; set; }
        public ulong? CodSitGeradora { get; set; }
        public uint? IniciaCAT { get; set; }
        public string? ObsCAT { get; set; }
        public LocalAcidente? LocalAcidente { get; set; }
        public ParteAtingida? ParteAtingida { get; set; }
        public AgenteCausador? AgenteCausador { get; set; }
        public Atestado? Atestado { get; set; }
        public CatOrigem? CatOrigem { get; set; }

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

            XElement element = new XElement(ns + nameof(Cat));
            element.Add(new XElement(ns + nameof(DtAcid), DtAcid?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(TpAcid), TpAcid));
            element.Add(new XElement(ns + nameof(HrAcid), HrAcid));
            element.Add(new XElement(ns + nameof(HrsTrabAntesAcid), HrsTrabAntesAcid));
            element.Add(new XElement(ns + nameof(TpCat), TpCat));
            element.Add(new XElement(ns + nameof(IndCatObito), IndCatObito));
            element.Add(new XElement(ns + nameof(DtObito), DtObito));
            element.Add(new XElement(ns + nameof(IndComunPolicia), IndComunPolicia));
            element.Add(new XElement(ns + nameof(CodSitGeradora), CodSitGeradora));
            element.Add(new XElement(ns + nameof(IniciaCAT), IniciaCAT));
            element.Add(new XElement(ns + nameof(ObsCAT), ObsCAT));
            element.Add(LocalAcidente?.GetXmlElements(ns));
            element.Add(ParteAtingida?.GetXmlElements(ns));
            element.Add(AgenteCausador?.GetXmlElements(ns));
            element.Add(Atestado?.GetXmlElements(ns));
            element.Add(CatOrigem?.GetXmlElements(ns));
            return element;

        }
    }
}

