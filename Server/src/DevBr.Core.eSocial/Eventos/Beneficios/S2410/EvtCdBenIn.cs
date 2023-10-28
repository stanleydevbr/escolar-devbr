using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2410
{
    public class EvtCdBenIn : IdeEvento<EvtCdBenIn>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public BeneficiarioS2410? Beneficiario { get; set; }
        public InfoBenInicio? InfoBenInicio { get; set; }
        public EvtCdBenIn(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtCdBenIn));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(Beneficiario?.GetXmlElements(ns));
            element.Add(InfoBenInicio?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoBenInicio : EntityType<InfoBenInicio>, IDisposable
    {
        public char? CadIni { get; set; }
        public uint? IndSitBenef { get; set; }
        public string? NrBeneficio { get; set; }
        public DateTime? DtIniBeneficio { get; set; }
        public DateTime? DtPublic { get; set; }
        public DadosBeneficio? DadosBeneficio { get; set; }
        public SucessaoBenef? SucessaoBenef { get; set; }
        public MudancaCPFS2410? MudancaCPF { get; set; }
        public InfoBenTermino? InfoBenTermino { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoBenInicio));
            element.Add(new XElement(ns + nameof(CadIni), CadIni));
            element.Add(new XElement(ns + nameof(IndSitBenef), IndSitBenef));
            element.Add(new XElement(ns + nameof(NrBeneficio), NrBeneficio));
            element.Add(new XElement(ns + nameof(DtIniBeneficio), DtIniBeneficio?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DtPublic), DtPublic?.ToString("dd-MM-yyyy")));
            element.Add(DadosBeneficio?.GetXmlElements(ns));
            element.Add(SucessaoBenef?.GetXmlElements(ns));
            element.Add(MudancaCPF?.GetXmlElements(ns));
            element.Add(InfoBenTermino?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoBenTermino : EntityType<InfoBenTermino>, IDisposable
    {
        public DateTime? DtTermBeneficio { get; set; }
        public string? MtvTermino { get; set; }
        public string? CnpjOrgaoSuc { get; set; }
        public string? NovoCPF { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoBenTermino));
            element.Add(new XElement(ns + nameof(DtTermBeneficio), DtTermBeneficio?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(MtvTermino), MtvTermino));
            if (string.IsNullOrEmpty(CnpjOrgaoSuc))
                element.Add(new XElement(ns + nameof(CnpjOrgaoSuc), CnpjOrgaoSuc));
            if (string.IsNullOrEmpty(NovoCPF))
                element.Add(new XElement(ns + nameof(NovoCPF), NovoCPF));
            return element;

        }
    }

    public class MudancaCPFS2410 : EntityType<MudancaCPFS2410>, IDisposable
    {
        public string? CpfAnt { get; set; }
        public string? NrBeneficioAnt { get; set; }
        public DateTime? DtAltCPF { get; set; }
        public string? Observacao { get; set; }
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

            XElement element = new XElement(ns + "MudancaCPF");
            element.Add(new XElement(ns + nameof(CpfAnt), CpfAnt));
            element.Add(new XElement(ns + nameof(NrBeneficioAnt), NrBeneficioAnt));
            element.Add(new XElement(ns + nameof(DtAltCPF), DtAltCPF?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            return element;

        }
    }

    public class SucessaoBenef : EntityType<SucessaoBenef>, IDisposable
    {
        public string? CnpjOrgaoAnt { get; set; }
        public string? NrBeneficioAnt { get; set; }
        public DateTime? DtTransf { get; set; }
        public string? Observacao { get; set; }
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

            XElement element = new XElement(ns + nameof(SucessaoBenef));
            element.Add(new XElement(ns + nameof(CnpjOrgaoAnt), CnpjOrgaoAnt));
            element.Add(new XElement(ns + nameof(NrBeneficioAnt), NrBeneficioAnt));
            element.Add(new XElement(ns + nameof(DtTransf), DtTransf?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            return element;

        }
    }

    public class DadosBeneficio : EntityType<DadosBeneficio>, IDisposable
    {
        public uint? TpBeneficio { get; set; }
        public uint? TpPlanRP { get; set; }
        public string? Dsc { get; set; }
        public char? IndDecJud { get; set; }
        public InfoPenMorte? InfoPenMorte { get; set; }
        public Suspensao? Suspensao { get; set; }
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

            XElement element = new XElement(ns + nameof(DadosBeneficio));
            element.Add(new XElement(ns + nameof(TpBeneficio), TpBeneficio));
            element.Add(new XElement(ns + nameof(TpPlanRP), TpPlanRP));
            element.Add(new XElement(ns + nameof(Dsc), Dsc));
            element.Add(new XElement(ns + nameof(IndDecJud), IndDecJud));
            if (InfoPenMorte != null)
                element.Add(InfoPenMorte?.GetXmlElements(ns));
            if (Suspensao != null)
                element.Add(Suspensao?.GetXmlElements(ns));
            return element;

        }
    }

    public class Suspensao : EntityType<Suspensao>, IDisposable
    {
        public string? MtvSuspensao { get; set; }
        public string? DscSuspensao { get; set; }
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

            XElement element = new XElement(ns + nameof(Suspensao));
            element.Add(new XElement(ns + nameof(MtvSuspensao), MtvSuspensao));
            element.Add(new XElement(ns + nameof(DscSuspensao), DscSuspensao));
            return element;

        }
    }

    public class InfoPenMorte : EntityType<InfoPenMorte>, IDisposable
    {
        public uint? TpPenMorte { get; set; }
        public InstPenMorte? InstPenMorte { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoPenMorte));
            element.Add(new XElement(ns + nameof(TpPenMorte), TpPenMorte));
            element.Add(InstPenMorte?.GetXmlElements(ns));
            return element;

        }
    }

    public class InstPenMorte : EntityType<InstPenMorte>, IDisposable
    {
        public string? CpfInst { get; set; }
        public DateTime? DtInst { get; set; }
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

            XElement element = new XElement(ns + nameof(InstPenMorte));
            element.Add(new XElement(ns + nameof(CpfInst), CpfInst));
            element.Add(new XElement(ns + nameof(DtInst), DtInst?.ToString("dd-MM-yyyy")));
            return element;

        }
    }

    public class BeneficiarioS2410 : EntityType<BeneficiarioS2410>, IDisposable
    {
        public string? CpfBenef { get; set; }
        public string? Matricula { get; set; }
        public string? CnpjOrigem { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            throw new NotImplementedException();
        }
    }
}
