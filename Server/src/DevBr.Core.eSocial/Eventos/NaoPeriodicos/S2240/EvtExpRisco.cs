using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2206;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2240
{
    public class EvtExpRisco : IdeEvento<EvtExpRisco>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeVinculo? IdeVinculo { get; set; }
        public InfoExpRisco? InfoExpRisco { get; set; }
        public EvtExpRisco(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;

        }

        public XDocument GetXmlDocument()
        {

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "UTF-8", "no"),
                new XElement(ns + "eSocial",
                    new XAttribute("xmlns", ns),
                        GetXmlElements(ns)));
            return doc;

        }

        protected override XElement? GetXmlElements(XNamespace ns)
        {

            XElement element = new XElement(ns + nameof(EvtExpRisco));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeVinculo?.GetXmlElements(ns));
            element.Add(InfoExpRisco?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoExpRisco : EntityType<InfoExpRisco>, IDisposable
    {
        public DateTime? DtIniCondicao { get; set; }
        public InfoAmb? InfoAmb { get; set; }
        public InfoAtiv? InfoAtiv { get; set; }
        public List<AgNoc>? AgsNocivos { get; set; }
        public List<RespReg>? RespRegistros { get; set; }
        public Obs? Obs { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoExpRisco));
            element.Add(new XElement(ns + nameof(DtIniCondicao), DtIniCondicao?.ToString("dd-MM-yyyy")));
            element.Add(InfoAmb?.GetXmlElements(ns));
            element.Add(InfoAtiv?.GetXmlElements(ns));
            AgsNocivos?.ForEach(ag => element.Add(ag.GetXmlElements(ns)));
            RespRegistros?.ForEach(resp => element.Add(resp.GetXmlElements(ns)));
            element.Add(Obs?.GetXmlElements(ns));
            return element;

        }
    }

    public class Obs : EntityType<Obs>, IDisposable
    {
        public string? ObsCompl { get; set; }
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

            XElement element = new XElement(ns + nameof(Obs));
            element.Add(new XElement(ns + nameof(ObsCompl), ObsCompl));
            return element;

        }
    }

    public class RespReg : EntityType<RespReg>, IDisposable
    {
        public string? CpfResp { get; set; }
        public uint IdeOC { get; set; }
        public string? DscOC { get; set; }
        public string? NrOC { get; set; }
        public string? UfOC { get; set; }
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
            XElement element = new XElement(ns + nameof(RespReg));
            element.Add(new XElement(ns + nameof(CpfResp), CpfResp));
            element.Add(new XElement(ns + nameof(IdeOC), IdeOC));
            element.Add(new XElement(ns + nameof(DscOC), DscOC));
            element.Add(new XElement(ns + nameof(NrOC), NrOC));
            element.Add(new XElement(ns + nameof(UfOC), UfOC));
            return element;

        }
    }

    public class AgNoc : EntityType<AgNoc>, IDisposable
    {
        public string? CodAgNoc { get; set; }
        public string? DscAgNoc { get; set; }
        public uint? TpAval { get; set; }
        public uint? IntConc { get; set; }
        public uint? LimTol { get; set; }
        public uint? UnMed { get; set; }
        public string? TecMedicao { get; set; }
        public EpcEpi? EpcEpi { get; set; }
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

            XElement element = new XElement(ns + nameof(AgNoc));
            element.Add(new XElement(ns + nameof(CodAgNoc), CodAgNoc));
            element.Add(new XElement(ns + nameof(DscAgNoc), DscAgNoc));
            element.Add(new XElement(ns + nameof(TpAval), TpAval));
            element.Add(new XElement(ns + nameof(IntConc), IntConc));
            element.Add(new XElement(ns + nameof(LimTol), LimTol));
            element.Add(new XElement(ns + nameof(UnMed), UnMed));
            element.Add(new XElement(ns + nameof(TecMedicao), TecMedicao));
            return element;

        }
    }

    public class EpcEpi : EntityType<EpcEpi>, IDisposable
    {
        public uint? UtilizEPC { get; set; }
        public char? EficEpc { get; set; }
        public uint? UtilizEPI { get; set; }
        public char? EficEpi { get; set; }
        public List<Epi>? Epis { get; set; }
        public EpiCompl? EpiCompl { get; set; }
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
            XElement element = new XElement(ns + nameof(EpcEpi));
            element.Add(new XElement(ns + nameof(UtilizEPC), UtilizEPC));
            element.Add(new XElement(ns + nameof(EficEpc), EficEpc));
            element.Add(new XElement(ns + nameof(UtilizEPI), UtilizEPI));
            element.Add(new XElement(ns + nameof(EficEpi), EficEpi));
            Epis?.ForEach(epi => element.Add(epi.GetXmlElements(ns)));
            return element;

        }
    }

    public class EpiCompl : EntityType<EpiCompl>, IDisposable
    {
        public char? MedProtecao { get; set; }
        public char? CondFuncto { get; set; }
        public char? UsoInint { get; set; }
        public char? PrzValid { get; set; }
        public char? PeriodicTroca { get; set; }
        public char? Higienizacao { get; set; }

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

            XElement element = new XElement(ns + nameof(EpiCompl));
            element.Add(new XElement(ns + nameof(MedProtecao), MedProtecao));
            element.Add(new XElement(ns + nameof(CondFuncto), CondFuncto));
            element.Add(new XElement(ns + nameof(UsoInint), UsoInint));
            element.Add(new XElement(ns + nameof(PrzValid), PrzValid));
            element.Add(new XElement(ns + nameof(PeriodicTroca), PeriodicTroca));
            element.Add(new XElement(ns + nameof(Higienizacao), Higienizacao));
            return element;

        }
    }

    public class Epi : EntityType<Epi>, IDisposable
    {
        public string? DocAval { get; set; }
        public string? DscEPI { get; set; }
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

            XElement element = new XElement(ns + nameof(Epi));
            element.Add(new XElement(ns + nameof(DocAval), DocAval));
            element.Add(new XElement(ns + nameof(DscEPI), DscEPI));
            return element;

        }
    }

    public class InfoAtiv : EntityType<InfoAtiv>, IDisposable
    {
        public string? DscAtivDes { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoAtiv));
            element.Add(new XElement(ns + nameof(DscAtivDes), DscAtivDes));
            return element;

        }
    }

    public class InfoAmb : EntityType<InfoAmb>, IDisposable
    {
        public uint? LocalAmb { get; set; }
        public string? DscSetor { get; set; }
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoAmb));
            element.Add(new XElement(ns + nameof(LocalAmb), LocalAmb));
            element.Add(new XElement(ns + nameof(DscSetor), DscSetor));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            return element;

        }
    }
}
