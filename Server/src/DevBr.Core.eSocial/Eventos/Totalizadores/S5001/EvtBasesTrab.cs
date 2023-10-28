using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Eventos.Periodicos.S1200;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Totalizadores.S5001
{
    public class EvtBasesTrab : IdeEvento<EvtBasesTrab>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public Periodicos.S1200.IdeTrabalhador? IdeTrabalhador { get; set; }
        public InfoCompl? InfoCompl { get; set; }
        public InfoCpCalc? InfoCpCalc { get; set; }
        public InfoCp? InfoCp { get; set; }
        public EvtBasesTrab(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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
            XElement element = new XElement(ns + nameof(EvtBasesTrab));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeTrabalhador?.GetXmlElements(ns));
            element.Add(InfoCompl?.GetXmlElements(ns));
            element.Add(InfoCpCalc?.GetXmlElements(ns));
            element.Add(InfoCp?.GetXmlElements(ns));
            return element;
        }
    }

    public class InfoCp : EntityType<InfoCp>, IDisposable
    {
        public string? ClassTrib { get; set; }
        public List<IdeEstabLotBase>? IdeEstabLot { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoCp));
            element.Add(new XElement(ns + nameof(ClassTrib), ClassTrib));
            IdeEstabLot?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdeEstabLotBase : EntityType<IdeEstabLotBase>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public string? CodLotacao { get; set; }
        public List<InfoCategIncid>? InfoCategIncid { get; set; }

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

            XElement element = new XElement(ns + "IdeEstabLot");
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(new XElement(ns + nameof(CodLotacao), CodLotacao));
            InfoCategIncid?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoCategIncid : EntityType<InfoCategIncid>, IDisposable
    {
        public string? Matricula { get; set; }
        public uint? CodCateg { get; set; }
        public uint? IndSimples { get; set; }
        public List<InfoBaseCS>? InfoBaseCS { get; set; }
        public List<CalcTer>? CalcTer { get; set; }
        public List<InfoPerRef>? InfoPerRef { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoCategIncid));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            element.Add(new XElement(ns + nameof(IndSimples), IndSimples));
            InfoBaseCS?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            CalcTer?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            InfoPerRef?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;
        }
    }

    public class InfoPerRef : EntityType<InfoPerRef>, IDisposable
    {
        public DateTime? PerRef { get; set; }
        public List<IdeADCBase>? IdeADC { get; set; }
        public List<DetInfoPerRef>? DetInfoPerRef { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoPerRef));
            IdeADC?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            DetInfoPerRef?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class DetInfoPerRef : EntityType<DetInfoPerRef>, IDisposable
    {
        public uint? Ind13 { get; set; }
        public uint? TpVrPerRef { get; set; }
        public double? VrPerRef { get; set; }

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

            XElement element = new XElement(ns + nameof(DetInfoPerRef));
            element.Add(new XElement(ns + nameof(Ind13), Ind13));
            element.Add(new XElement(ns + nameof(TpVrPerRef), TpVrPerRef));
            element.Add(new XElement(ns + nameof(VrPerRef), VrPerRef));

            return element;

        }
    }

    public class IdeADCBase : EntityType<IdeADCBase>, IDisposable
    {
        public DateTime? DtAcConv { get; set; }
        public char? TpAcConv { get; set; }
        public string? Dsc { get; set; }
        public char? RemunSuc { get; set; }
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

            XElement element = new XElement(ns + "IdeADC");
            element.Add(new XElement(ns + nameof(DtAcConv), DtAcConv?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(TpAcConv), TpAcConv));
            element.Add(new XElement(ns + nameof(Dsc), Dsc));
            element.Add(new XElement(ns + nameof(RemunSuc), RemunSuc));
            return element;

        }
    }

    public class CalcTer : EntityType<CalcTer>, IDisposable
    {
        public ulong? TpCR { get; set; }
        public double? VrCsSegTerc { get; set; }
        public double? VrDescTerc { get; set; }
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

            XElement element = new XElement(ns + nameof(CalcTer));
            element.Add(new XElement(ns + nameof(TpCR), TpCR));
            element.Add(new XElement(ns + nameof(VrCsSegTerc), VrCsSegTerc));
            element.Add(new XElement(ns + nameof(VrDescTerc), VrDescTerc));
            return element;

        }
    }

    public class InfoBaseCS : EntityType<InfoBaseCS>, IDisposable
    {
        public uint? Ind13 { get; set; }
        public uint? TpValor { get; set; }
        public double? Valor { get; set; }

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

            XElement element = new XElement(ns + nameof(InfoBaseCS));
            element.Add(new XElement(ns + nameof(Ind13), Ind13));
            element.Add(new XElement(ns + nameof(TpValor), TpValor));
            element.Add(new XElement(ns + nameof(Valor), Valor));
            return element;

        }
    }

    public class InfoCpCalc : EntityType<InfoCpCalc>, IDisposable
    {
        public uint? TpCR { get; set; }
        public double? VrCpSeg { get; set; }
        public double? VrDescSeg { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoCpCalc));
            element.Add(new XElement(ns + nameof(TpCR), TpCR));
            element.Add(new XElement(ns + nameof(VrCpSeg), VrCpSeg));
            element.Add(new XElement(ns + nameof(VrDescSeg), VrDescSeg));
            return element;

        }
    }

    public class InfoCompl : EntityType<InfoCompl>, IDisposable
    {
        public SucessaoVinc? SucessaoVinc { get; set; }
        public List<InfoInterm>? InfoInterm { get; set; }
        public List<InfoComplCont>? InfoComplCont { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoCompl));
            element.Add(SucessaoVinc?.GetXmlElements(ns));
            InfoInterm?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            InfoComplCont?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }
}
