using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Totalizadores.S5011
{
    public class EvtCS : IdeEvento<EvtCS>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public InfoCS? InfoCS { get; set; }
        public EvtCS(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtCS));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(InfoCS?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoCS : EntityType<InfoCS>, IDisposable
    {
        public string? NrRecArqBase { get; set; }
        public uint? IndExistInfo { get; set; }
        public InfoCPSeg? InfoCPSeg { get; set; }
        public InfoContrib? InfoContrib { get; set; }
        public List<IdeEstabCS>? Estabelecimentos { get; set; }
        public List<InfoCRContrib>? InfoCRContrib { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoCS));
            element.Add(new XElement(ns + nameof(NrRecArqBase), NrRecArqBase));
            element.Add(new XElement(ns + nameof(IndExistInfo), IndExistInfo));
            element.Add(InfoCPSeg?.GetXmlElements(ns));
            element.Add(InfoContrib?.GetXmlElements(ns));
            Estabelecimentos?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            InfoCRContrib?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoCRContrib : EntityType<InfoCRContrib>, IDisposable
    {
        public ulong? TpCR { get; set; }
        public double? VrCR { get; set; }
        public double? VrCRSusp { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoCRContrib));
            element.Add(new XElement(ns + nameof(TpCR), TpCR));
            element.Add(new XElement(ns + nameof(VrCR), VrCR));
            element.Add(new XElement(ns + nameof(VrCRSusp), VrCRSusp));
            return element;

        }
    }

    public class IdeEstabCS : EntityType<IdeEstabCS>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public InfoEstabCS? InfoEstab { get; set; }
        public List<IdeLotacaoCS>? Lotacoes { get; set; }
        public List<BasesComerc>? BasesComerc { get; set; }
        public List<InfoCREstab>? InfoCREstab { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeEstabCS));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(InfoEstab?.GetXmlElements(ns));
            Lotacoes?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            BasesComerc?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            InfoCREstab?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoCREstab : EntityType<InfoCREstab>, IDisposable
    {
        public ulong? TpCR { get; set; }
        public double? VrCR { get; set; }
        public double? VrSuspCR { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoCREstab));
            element.Add(new XElement(ns + nameof(TpCR), TpCR));
            element.Add(new XElement(ns + nameof(VrCR), VrCR));
            element.Add(new XElement(ns + nameof(VrSuspCR), VrSuspCR));
            return element;

        }
    }

    public class BasesComerc : EntityType<BasesComerc>, IDisposable
    {
        public uint? IndComerc { get; set; }
        public double? VrBcComPR { get; set; }
        public double? VrCPSusp { get; set; }
        public double? VrRatSusp { get; set; }
        public double? VrSenarSusp { get; set; }
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
            XElement element = new XElement(ns + nameof(BasesComerc));
            element.Add(new XElement(ns + nameof(IndComerc), IndComerc));
            element.Add(new XElement(ns + nameof(VrBcComPR), VrBcComPR));
            element.Add(new XElement(ns + nameof(VrCPSusp), VrCPSusp));
            element.Add(new XElement(ns + nameof(VrRatSusp), VrRatSusp));
            element.Add(new XElement(ns + nameof(VrSenarSusp), VrSenarSusp));
            return element;

        }
    }

    public class IdeLotacaoCS : EntityType<IdeLotacaoCS>, IDisposable
    {
        public string? CodLotacao { get; set; }
        public uint? Fpas { get; set; }
        public string? CodTercs { get; set; }
        public string? CodTercSusp { get; set; }
        public List<InfoTercSusp>? InfoTercSusp { get; set; }
        public InfoEmprParcialCS? InfoEmprParcial { get; set; }
        public DadosOpPortCS? DadosOpPort { get; set; }
        public List<BasesRemun>? BasesRemun { get; set; }
        public BasesAvNPort? BasesAvNPort { get; set; }
        public InfoSubstPatrOpPortCs? InfoSubstPatrOpPort { get; set; }
        public List<BasesAquis>? BasesAquis { get; set; }
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
            XElement element = new XElement(ns + "IdeLotacao");
            element.Add(new XElement(ns + nameof(CodLotacao), CodLotacao));
            element.Add(new XElement(ns + nameof(Fpas), Fpas));
            element.Add(new XElement(ns + nameof(CodTercs), CodTercs));
            element.Add(new XElement(ns + nameof(CodTercSusp), CodTercSusp));
            InfoTercSusp?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            element.Add(InfoEmprParcial?.GetXmlElements(ns));
            element.Add(DadosOpPort?.GetXmlElements(ns));
            BasesRemun?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            element.Add(BasesAvNPort?.GetXmlElements(ns));
            element.Add(InfoSubstPatrOpPort?.GetXmlElements(ns));
            BasesAquis?.ForEach(x => element.Add(x?.GetXmlElements(ns)));

            return element;

        }
    }

    public class BasesAquis : EntityType<BasesAquis>, IDisposable
    {
        public uint? IndAquis { get; set; }
        public double? VlrAquis { get; set; }
        public double? VrCPDescPR { get; set; }
        public double? VrCPNRet { get; set; }
        public double? VrRatNRet { get; set; }
        public double? VrSenarNRet { get; set; }
        public double? VrCPCalcPR { get; set; }
        public double? VrRatDescPR { get; set; }
        public double? VrRatCalcPR { get; set; }
        public double? VrSenarDesc { get; set; }
        public double? VrSenarCalc { get; set; }
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

            XElement element = new XElement(ns + nameof(BasesAquis));
            element.Add(new XElement(ns + nameof(IndAquis), IndAquis));
            element.Add(new XElement(ns + nameof(VlrAquis), VlrAquis));
            element.Add(new XElement(ns + nameof(VrCPDescPR), VrCPDescPR));
            element.Add(new XElement(ns + nameof(VrCPNRet), VrCPNRet));
            element.Add(new XElement(ns + nameof(VrRatNRet), VrRatNRet));
            element.Add(new XElement(ns + nameof(VrSenarNRet), VrSenarNRet));
            element.Add(new XElement(ns + nameof(VrCPCalcPR), VrCPCalcPR));
            element.Add(new XElement(ns + nameof(VrRatDescPR), VrRatDescPR));
            element.Add(new XElement(ns + nameof(VrRatCalcPR), VrRatCalcPR));
            element.Add(new XElement(ns + nameof(VrSenarDesc), VrSenarDesc));
            element.Add(new XElement(ns + nameof(VrSenarCalc), VrSenarCalc));
            return element;

        }
    }

    public class InfoSubstPatrOpPortCs : EntityType<InfoSubstPatrOpPortCs>, IDisposable
    {
        public string? CnpjOpPortuario { get; set; }
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

            XElement element = new XElement(ns + "InfoSubstPatrOpPort");
            element.Add(new XElement(ns + nameof(CnpjOpPortuario), CnpjOpPortuario));
            return element;

        }
    }

    public class BasesAvNPort : EntityType<BasesAvNPort>, IDisposable
    {
        public double? VrBcCp00 { get; set; }
        public double? VrBcCp15 { get; set; }
        public double? VrBcCp20 { get; set; }
        public double? VrBcCp25 { get; set; }
        public double? VrBcCp13 { get; set; }
        public double? VrDescCP { get; set; }
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

            XElement element = new XElement(ns + "BasesAvNPort");
            element.Add(new XElement(ns + nameof(VrBcCp00), VrBcCp00));
            element.Add(new XElement(ns + nameof(VrBcCp15), VrBcCp15));
            element.Add(new XElement(ns + nameof(VrBcCp20), VrBcCp20));
            element.Add(new XElement(ns + nameof(VrBcCp25), VrBcCp25));
            element.Add(new XElement(ns + nameof(VrBcCp13), VrBcCp13));
            element.Add(new XElement(ns + nameof(VrDescCP), VrDescCP));
            return element;

        }
    }

    public class BasesRemun : EntityType<BasesRemun>, IDisposable
    {
        public uint? IndIncid { get; set; }
        public uint? CodCateg { get; set; }
        public BasesCp? BasesCp { get; set; }
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

            XElement element = new XElement(ns + "BasesRemun");
            element.Add(new XElement(ns + nameof(IndIncid), IndIncid));
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            element.Add(BasesCp?.GetXmlElements(ns));

            return element;

        }
    }

    public class BasesCp : EntityType<BasesCp>, IDisposable
    {
        public double? VrBcCP00 { get; set; }
        public double? VrBcCp15 { get; set; }
        public double? VrBcCp20 { get; set; }
        public double? VrBcCp25 { get; set; }
        public double? VrSuspBcCp00 { get; set; }
        public double? VrSuspBcCp15 { get; set; }
        public double? VrSuspBcCp20 { get; set; }
        public double? VrSuspBcCp25 { get; set; }
        public double? VrBcCp00VA { get; set; }
        public double? VrBcCp15VA { get; set; }
        public double? VrBcCp20VA { get; set; }
        public double? VrBcCp25VA { get; set; }
        public double? VrSuspBcCp00VA { get; set; }
        public double? VrSuspBcCp15VA { get; set; }
        public double? VrSuspBcCp20VA { get; set; }
        public double? VrSuspBcCp25VA { get; set; }
        public double? VrDescSest { get; set; }
        public double? VrCalcSest { get; set; }
        public double? VrDescSenat { get; set; }
        public double? VrCalcSenat { get; set; }
        public double? VrSalFam { get; set; }
        public double? VrSalMat { get; set; }
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

            XElement element = new XElement(ns + "BasesCp");
            element.Add(new XElement(ns + nameof(VrBcCP00), VrBcCP00));
            element.Add(new XElement(ns + nameof(VrBcCp15), VrBcCp15));
            element.Add(new XElement(ns + nameof(VrBcCp20), VrBcCp20));
            element.Add(new XElement(ns + nameof(VrBcCp25), VrBcCp25));
            element.Add(new XElement(ns + nameof(VrSuspBcCp00), VrSuspBcCp00));
            element.Add(new XElement(ns + nameof(VrSuspBcCp15), VrSuspBcCp15));
            element.Add(new XElement(ns + nameof(VrSuspBcCp20), VrSuspBcCp20));
            element.Add(new XElement(ns + nameof(VrSuspBcCp25), VrSuspBcCp25));
            element.Add(new XElement(ns + nameof(VrBcCp00VA), VrBcCp00VA));
            element.Add(new XElement(ns + nameof(VrBcCp15VA), VrBcCp15VA));
            element.Add(new XElement(ns + nameof(VrBcCp20VA), VrBcCp20VA));
            element.Add(new XElement(ns + nameof(VrBcCp25VA), VrBcCp25VA));
            element.Add(new XElement(ns + nameof(VrSuspBcCp00VA), VrSuspBcCp00VA));
            element.Add(new XElement(ns + nameof(VrSuspBcCp15VA), VrSuspBcCp15VA));
            element.Add(new XElement(ns + nameof(VrSuspBcCp20VA), VrSuspBcCp20VA));
            element.Add(new XElement(ns + nameof(VrSuspBcCp25VA), VrSuspBcCp25VA));
            element.Add(new XElement(ns + nameof(VrDescSest), VrDescSest));
            element.Add(new XElement(ns + nameof(VrCalcSest), VrCalcSest));
            element.Add(new XElement(ns + nameof(VrDescSenat), VrDescSenat));
            element.Add(new XElement(ns + nameof(VrCalcSenat), VrCalcSenat));
            element.Add(new XElement(ns + nameof(VrSalFam), VrSalFam));
            element.Add(new XElement(ns + nameof(VrSalMat), VrSalMat));


            return element;

        }
    }

    public class DadosOpPortCS : EntityType<DadosOpPortCS>, IDisposable
    {
        public string? CnpjOpPortuario { get; set; }
        public uint? AliqRat { get; set; }
        public double? Fap { get; set; }
        public double? AliqRatAjust { get; set; }
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

            XElement element = new XElement(ns + "DadosOpPort");
            element.Add(new XElement(ns + nameof(CnpjOpPortuario), CnpjOpPortuario));
            element.Add(new XElement(ns + nameof(AliqRat), AliqRat));
            element.Add(new XElement(ns + nameof(Fap), Fap));
            element.Add(new XElement(ns + nameof(AliqRatAjust), AliqRatAjust));
            return element;

        }
    }

    public class InfoEmprParcialCS : EntityType<InfoEmprParcialCS>, IDisposable
    {
        public uint? TpInscContrat { get; set; }
        public string? NrInscContrat { get; set; }
        public uint? TpInscProp { get; set; }
        public string? NrInscProp { get; set; }
        public string? CnoObra { get; set; }
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

            XElement element = new XElement(ns + "InfoEmprParcial");
            element.Add(new XElement(ns + nameof(TpInscContrat), TpInscContrat));
            element.Add(new XElement(ns + nameof(NrInscContrat), NrInscContrat));
            element.Add(new XElement(ns + nameof(TpInscProp), TpInscProp));
            element.Add(new XElement(ns + nameof(NrInscProp), NrInscProp));
            element.Add(new XElement(ns + nameof(CnoObra), CnoObra));
            return element;

        }
    }

    public class InfoTercSusp : EntityType<InfoTercSusp>, IDisposable
    {
        public string? CodTerc { get; set; }

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

            XElement element = new XElement(ns + nameof(InfoTercSusp));
            element.Add(new XElement(ns + nameof(CodTerc), CodTerc));
            return element;

        }
    }

    public class InfoEstabCS : EntityType<InfoEstabCS>, IDisposable
    {
        public ulong? CnaePrep { get; set; }
        public string? CnpjResp { get; set; }
        public uint? AliqRat { get; set; }
        public double? Fap { get; set; }
        public double? AliqRatAjust { get; set; }
        public InfoEstabRef? InfoEstabRef { get; set; }
        public InfoComplObra? InfoComplObra { get; set; }
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

            XElement element = new XElement(ns + "InfoEstab");
            element.Add(new XElement(ns + nameof(CnaePrep), CnaePrep));
            element.Add(new XElement(ns + nameof(CnpjResp), CnpjResp));
            element.Add(new XElement(ns + nameof(AliqRat), AliqRat));
            element.Add(new XElement(ns + nameof(Fap), Fap));
            element.Add(new XElement(ns + nameof(AliqRatAjust), AliqRatAjust));
            element.Add(InfoEstabRef?.GetXmlElements(ns));
            element.Add(InfoComplObra?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoComplObra : EntityType<InfoComplObra>, IDisposable
    {
        public uint? IdeSubstPatrObra { get; set; }

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

            XElement element = new XElement(ns + nameof(InfoComplObra));
            element.Add(new XElement(ns + nameof(IdeSubstPatrObra), IdeSubstPatrObra));
            return element;

        }
    }

    public class InfoEstabRef : EntityType<InfoEstabRef>, IDisposable
    {
        public uint? AliqRat { get; set; }
        public double? Fap { get; set; }
        public double? AliqRatAjust { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoEstabRef));
            element.Add(new XElement(ns + nameof(AliqRat), AliqRat));
            element.Add(new XElement(ns + nameof(Fap), Fap));
            element.Add(new XElement(ns + nameof(AliqRatAjust), AliqRatAjust));
            return element;

        }
    }

    public class InfoContrib : EntityType<InfoContrib>, IDisposable
    {
        public string? ClassTrib { get; set; }
        public InfoPJ? InfoPJ { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoContrib));
            element.Add(new XElement(ns + nameof(ClassTrib), ClassTrib));
            element.Add(InfoPJ?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoPJ : EntityType<InfoPJ>, IDisposable
    {
        public uint? IndCoop { get; set; }
        public uint? IndConstr { get; set; }
        public uint? IndSubstPatr { get; set; }
        public double? PerRedContrib { get; set; }
        public uint? PerTransf { get; set; }
        public InfoAtConc? InfoAtConc { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoPJ));
            element.Add(new XElement(ns + nameof(IndCoop), IndCoop));
            element.Add(new XElement(ns + nameof(IndConstr), IndConstr));
            element.Add(new XElement(ns + nameof(IndSubstPatr), IndSubstPatr));
            element.Add(new XElement(ns + nameof(PerRedContrib), PerRedContrib));
            element.Add(new XElement(ns + nameof(PerTransf), PerTransf));
            element.Add(InfoAtConc?.GetXmlElements(ns));

            return element;

        }
    }

    public class InfoAtConc : EntityType<InfoAtConc>, IDisposable
    {
        public double? FatorMes { get; set; }
        public double? Fator13 { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoAtConc));
            element.Add(new XElement(ns + nameof(FatorMes), FatorMes));
            element.Add(new XElement(ns + nameof(Fator13), Fator13));
            return element;
        }
    }

    public class InfoCPSeg : EntityType<InfoCPSeg>, IDisposable
    {
        public double? VrDescCP { get; set; }
        public double? VrCpSeg { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoCPSeg));
            element.Add(new XElement(ns + nameof(VrDescCP), VrDescCP));
            element.Add(new XElement(ns + nameof(VrCpSeg), VrCpSeg));
            return element;
        }
    }
}
