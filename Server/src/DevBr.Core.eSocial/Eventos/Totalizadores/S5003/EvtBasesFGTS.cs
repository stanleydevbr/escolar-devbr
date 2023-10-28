using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Eventos.Periodicos.S1200;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Totalizadores.S5003
{
    public class EvtBasesFGTS : IdeEvento<EvtBasesFGTS>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeTrabalhadorFGTS? IdeTrabalhador { get; set; }
        public EvtBasesFGTS(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtBasesFGTS));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeTrabalhador?.GetXmlElements(ns));
            return element;

        }
    }

    public class IdeTrabalhadorFGTS : EntityType<IdeTrabalhadorFGTS>, IDisposable
    {
        public string? CpfTrab { get; set; }
        public InfoFGTS? InfoFGTS { get; set; }
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
            XElement element = new XElement(ns + "IdeTrabalhador");
            element.Add(new XElement(ns + nameof(CpfTrab), CpfTrab));
            element.Add(InfoFGTS?.GetXmlElements(ns));
            return element;
        }
    }

    public class InfoFGTS : EntityType<InfoFGTS>, IDisposable
    {
        public DateTime? DtVenc { get; set; }
        public string? ClassTrib { get; set; }
        public List<IdeEstabFGTS>? Estabelecimentos { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoFGTS));
            element.Add(new XElement(ns + nameof(DtVenc), DtVenc?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(ClassTrib), ClassTrib));
            Estabelecimentos?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdeEstabFGTS : EntityType<IdeEstabFGTS>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public List<IdeLotacaoFGTS>? Lotacoes { get; set; }
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

            XElement element = new XElement(ns + "IdeEstab");
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            Lotacoes?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdeLotacaoFGTS : EntityType<IdeLotacaoFGTS>, IDisposable
    {
        public string? CodLotacao { get; set; }
        public string? TpLotacao { get; set; }
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public List<InfoTrabFGTS>? InfoTrabFGTS { get; set; }
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
            element.Add(new XElement(ns + nameof(TpLotacao), TpLotacao));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            InfoTrabFGTS?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoTrabFGTS : EntityType<InfoTrabFGTS>, IDisposable
    {
        public string? Matricula { get; set; }
        public uint? CodCateg { get; set; }
        public uint? CategOrig { get; set; }
        public uint? TpRegTrab { get; set; }
        public char? RemunSuc { get; set; }
        public DateTime? DtDeslig { get; set; }
        public string? MtvDeslig { get; set; }
        public DateTime? DtTerm { get; set; }
        public string? MtvDesligTSV { get; set; }
        public SucessaoVinc? SucessaoVinc { get; set; }
        public InfoBaseFGTS? InfoBaseFGTS { get; set; }
        public ProcCS? ProcCS { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoTrabFGTS));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            element.Add(new XElement(ns + nameof(CategOrig), CategOrig));
            element.Add(new XElement(ns + nameof(TpRegTrab), TpRegTrab));
            element.Add(new XElement(ns + nameof(RemunSuc), RemunSuc));
            element.Add(new XElement(ns + nameof(DtDeslig), DtDeslig?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(MtvDeslig), MtvDeslig));
            element.Add(new XElement(ns + nameof(DtTerm), DtTerm));
            element.Add(new XElement(ns + nameof(MtvDesligTSV), MtvDesligTSV));
            element.Add(SucessaoVinc?.GetXmlElements(ns));
            element.Add(InfoBaseFGTS?.GetXmlElements(ns));
            element.Add(ProcCS?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoBaseFGTS : EntityType<InfoBaseFGTS>, IDisposable
    {
        public List<BasePerApur>? BasePerApur { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoBaseFGTS));
            BasePerApur?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;
        }
    }

    public class BasePerApur : EntityType<BasePerApur>, IDisposable
    {
        public uint? TpValor { get; set; }
        public uint? IndIncid { get; set; }
        public double? RemFGTS { get; set; }
        public double? DpsFGTS { get; set; }
        public List<DetRubrSusp>? Rubricas { get; set; }
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

            XElement element = new XElement(ns + nameof(BasePerApur));
            element.Add(new XElement(ns + nameof(TpValor), TpValor));
            element.Add(new XElement(ns + nameof(IndIncid), IndIncid));
            element.Add(new XElement(ns + nameof(RemFGTS), RemFGTS));
            element.Add(new XElement(ns + nameof(DpsFGTS), DpsFGTS));
            Rubricas?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class DetRubrSusp : EntityType<DetRubrSusp>, IDisposable
    {
        public string? CodRubr { get; set; }
        public string? IdeTabRubr { get; set; }
        public double? VrRubr { get; set; }
        public List<IdeProcFGTS>? Processos { get; set; }
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

            XElement element = new XElement(ns + nameof(DetRubrSusp));
            element.Add(new XElement(ns + nameof(CodRubr), CodRubr));
            element.Add(new XElement(ns + nameof(IdeTabRubr), IdeTabRubr));
            element.Add(new XElement(ns + nameof(VrRubr), VrRubr));
            Processos?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdeProcFGTS : EntityType<IdeProcFGTS>, IDisposable
    {
        public string? NrProc { get; set; }
        public List<InfoBasePerAntE>? BaseCalAnteriores { get; set; }
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

            XElement element = new XElement(ns + "IdeProcessoFGTS");
            element.Add(new XElement(ns + nameof(NrProc), NrProc));
            BaseCalAnteriores?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoBasePerAntE : EntityType<InfoBasePerAntE>, IDisposable
    {
        public DateTime? PerRef { get; set; }
        public char? TpAcConv { get; set; }
        public List<BasePerAntE>? BasesAnteriores { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoBasePerAntE));
            element.Add(new XElement(ns + nameof(PerRef), PerRef?.ToString("yyyy-MM")));
            element.Add(new XElement(ns + nameof(TpAcConv), TpAcConv));
            BasesAnteriores?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class BasePerAntE : EntityType<BasePerAntE>, IDisposable
    {
        public uint? TpValorE { get; set; }
        public uint? IndIncidE { get; set; }
        public double? RemFGTSE { get; set; }
        public double? DpsFGTSE { get; set; }
        public List<DetRubrSusp>? DetRubricas { get; set; }
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

            XElement element = new XElement(ns + nameof(BasePerAntE));
            element.Add(new XElement(ns + nameof(TpValorE), TpValorE));
            element.Add(new XElement(ns + nameof(IndIncidE), IndIncidE));
            element.Add(new XElement(ns + nameof(RemFGTSE), RemFGTSE));
            element.Add(new XElement(ns + nameof(DpsFGTSE), DpsFGTSE));
            DetRubricas?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }
}
