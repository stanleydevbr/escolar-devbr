using DevBr.Core.eSocial.Eventos.S1005;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1020
{
    public class EvtTabLotacao : IdeEvento<EvtTabLotacao>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public InfoLotacao? InfoLotacao { get; set; }
        public EvtTabLotacao(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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
            XElement element = new XElement(ns + nameof(EvtTabLotacao));
            element.Add(GetXmlEvento(ns));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(InfoLotacao?.GetXmlElements(ns));
            return element;
        }
    }

    public class InfoLotacao : EntityType<InfoLotacao>, IDisposable
    {
        public InclusaoLotacao? Inclusao { get; set; }
        public AlteracaoLotacao? Alteracao { get; set; }
        public ExclusaoLotacao? Exclusao { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoLotacao));
            element.Add(Inclusao?.GetXmlElements(ns));
            element.Add(Alteracao?.GetXmlElements(ns));
            element.Add(Exclusao?.GetXmlElements(ns));
            return element;
        }
    }

    public class ExclusaoLotacao : EntityType<ExclusaoLotacao>, IDisposable
    {
        public IdeLotacao? IdeLotacao { get; set; }
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

            XElement element = new XElement(ns + "Exclusao");
            element.Add(IdeLotacao?.GetXmlElements(ns));
            return element;

        }
    }

    public class AlteracaoLotacao : EntityType<AlteracaoLotacao>, IDisposable
    {
        public IdeLotacao? IdeLotacao { get; set; }
        public NovaValidade? NovaValidade { get; set; }
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

            XElement element = new XElement(ns + "Alteracao");
            element.Add(IdeLotacao?.GetXmlElements(ns));
            element.Add(NovaValidade?.GetXmlElements(ns));
            return element;

        }
    }

    public class InclusaoLotacao : EntityType<InclusaoLotacao>, IDisposable
    {
        public IdeLotacao? IdeLotacao { get; set; }
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

            XElement element = new XElement(ns + "Inclusao");
            element.Add(IdeLotacao?.GetXmlElements(ns));
            return element;

        }
    }

    public class IdeLotacao : EntityType<IdeLotacao>, IDisposable
    {
        public string? CodLotacao { get; set; }
        public DateTime? IniValid { get; set; }
        public DateTime? FimValid { get; set; }

        public DadosLotacao? DadosLotacao { get; set; }

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
            XElement element = new XElement(ns + nameof(IdeLotacao));
            element.Add(new XElement(ns + nameof(CodLotacao), CodLotacao));
            element.Add(new XElement(ns + nameof(IniValid), IniValid?.ToString("yyyy-MM")));
            element.Add(new XElement(ns + nameof(FimValid), FimValid?.ToString("yyyy-MM")));
            return element;
        }
    }

    public class DadosLotacao : EntityType<DadosLotacao>, IDisposable
    {
        public string? TpLotacao { get; set; }
        public byte? TpInsc { get; set; }
        public string? NrInsc { get; set; }

        public FpasLotacao? FpasLotacao { get; set; }
        public InfoEmprParcial? InfoEmprParcial { get; set; }
        public DadosOpPort? DadosOpPort { get; set; }

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
            XElement element = new XElement(ns + nameof(DadosLotacao));
            element.Add(new XElement(ns + nameof(TpLotacao), TpLotacao));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(FpasLotacao?.GetXmlElements(ns));
            element.Add(InfoEmprParcial?.GetXmlElements(ns));
            element.Add(DadosOpPort?.GetXmlElements(ns));
            return element;
        }
    }

    public class DadosOpPort : EntityType<DadosOpPort>, IDisposable
    {
        public byte AliqRat { get; set; }
        public double Fap { get; set; }
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
            XElement element = new XElement(ns + nameof(DadosOpPort));
            element.Add(new XElement(ns + nameof(AliqRat), AliqRat));
            element.Add(new XElement(ns + nameof(Fap), Fap));
            return element;

        }
    }

    public class InfoEmprParcial : EntityType<InfoEmprParcial>, IDisposable
    {
        public byte? TpInscContrat { get; set; }
        public string? NrInscContrat { get; set; }
        public byte TpInscProp { get; set; }
        public ulong? NrInscProp { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoEmprParcial));
            element.Add(new XElement(ns + nameof(TpInscContrat), TpInscContrat));
            element.Add(new XElement(ns + nameof(NrInscContrat), NrInscContrat));
            element.Add(new XElement(ns + nameof(TpInscProp), TpInscProp));
            element.Add(new XElement(ns + nameof(NrInscProp), NrInscProp));
            return element;
        }
    }

    public class FpasLotacao : EntityType<FpasLotacao>, IDisposable
    {
        public uint? Fpas { get; set; }
        public string? CodTercs { get; set; }
        public string? CodTercsSusp { get; set; }

        public List<InfoProcJudTerceiros>? InfoProcJudTerceiros { get; set; }

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
            XElement element = new XElement(ns + nameof(FpasLotacao));
            element.Add(new XElement(ns + nameof(Fpas), Fpas));
            element.Add(new XElement(ns + nameof(CodTercs), CodTercs));
            element.Add(new XElement(ns + nameof(CodTercsSusp), CodTercsSusp));
            if (InfoProcJudTerceiros != null)
            {
                XElement aux = new XElement(ns + nameof(InfoProcJudTerceiros));
                InfoProcJudTerceiros.ForEach(x => aux.Add(x.GetXmlElements(ns)));
                element.Add(aux);
            }
            return element;
        }
    }

    public class InfoProcJudTerceiros : EntityType<InfoProcJudTerceiros>, IDisposable
    {
        public ProcJudTerceiro? ProcJudTerceiro { get; set; }
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
            if (ProcJudTerceiro != null)
            {
                XElement element = new XElement(ProcJudTerceiro?.GetXmlElements(ns));
                return element;
            }
            return null;

        }
    }

    public class ProcJudTerceiro : EntityType<ProcJudTerceiro>, IDisposable
    {
        public string? CodTerc { get; set; }
        public string? NrProcJud { get; set; }
        public ulong? CodSusp { get; set; }
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
            XElement element = new XElement(ns + nameof(ProcJudTerceiro));
            element.Add(new XElement(ns + nameof(CodTerc), CodTerc));
            element.Add(new XElement(ns + nameof(NrProcJud), NrProcJud));
            element.Add(new XElement(ns + nameof(CodSusp), CodSusp));
            return element;
        }
    }
}
