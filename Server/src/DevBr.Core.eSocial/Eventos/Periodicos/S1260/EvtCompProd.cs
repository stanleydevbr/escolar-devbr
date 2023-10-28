using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1260
{
    public class EvtCompProd : IdeEvento<EvtCompProd>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public InfoCompProd? InfoCompProd { get; set; }
        public EvtCompProd(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtCompProd));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(InfoCompProd?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoCompProd : EntityType<InfoCompProd>, IDisposable
    {
        public IdeEstabel? IdeEstabel { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoCompProd));
            element.Add(IdeEstabel?.GetXmlElements(ns));
            return element;

        }
    }

    public class IdeEstabel : EntityType<IdeEstabel>, IDisposable
    {
        public string? NrInscEstabRural { get; set; }
        public TpComerc? TpComerc { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeEstabel));
            element.Add(new XElement(ns + nameof(NrInscEstabRural), NrInscEstabRural));
            element.Add(TpComerc?.GetXmlElements(ns));
            return element;

        }
    }

    public class TpComerc : EntityType<TpComerc>, IDisposable
    {
        public uint? IndComerc { get; set; }
        public double? VrTotCom { get; set; }
        public List<IdeAdquir>? IdeAdquir { get; set; }
        public List<InfoProcJud>? InfoProcJud { get; set; }
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

            XElement element = new XElement(ns + nameof(TpComerc));
            element.Add(new XElement(ns + nameof(IndComerc), IndComerc));
            element.Add(new XElement(ns + nameof(VrTotCom), VrTotCom));
            IdeAdquir?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            InfoProcJud?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoProcJud : EntityType<InfoProcJud>, IDisposable
    {
        public uint? TpProc { get; set; }
        public string? NrProc { get; set; }
        public ulong? CodSusp { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoProcJud));
            element.Add(new XElement(ns + nameof(TpProc), TpProc));
            element.Add(new XElement(ns + nameof(NrProc), NrProc));
            element.Add(new XElement(ns + nameof(CodSusp), CodSusp));
            element.Add(new XElement(ns + nameof(VrCPSusp), VrCPSusp));
            element.Add(new XElement(ns + nameof(VrRatSusp), VrRatSusp));
            element.Add(new XElement(ns + nameof(VrSenarSusp), VrSenarSusp));
            return element;

        }
    }

    public class IdeAdquir : EntityType<IdeAdquir>, IDisposable
    {
        public uint TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public double? VrComerc { get; set; }
        public List<Nfs>? Nfs { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeAdquir));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(new XElement(ns + nameof(VrComerc), VrComerc));
            Nfs?.ForEach(n => element.Add(n?.GetXmlElements(ns)));

            return element;

        }
    }

    public class Nfs : EntityType<Nfs>, IDisposable
    {
        public string? Serie { get; set; }
        public string? NrDocto { get; set; }
        public DateTime? DtEmisNF { get; set; }
        public double? VlrBruto { get; set; }
        public double? VrCPDescPR { get; set; }
        public double? VrRatDescPR { get; set; }
        public double? VrSenarDesc { get; set; }

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

            XElement element = new XElement(ns + nameof(Nfs));
            element.Add(new XElement(ns + nameof(Serie), Serie));
            element.Add(new XElement(ns + nameof(NrDocto), NrDocto));
            element.Add(new XElement(ns + nameof(DtEmisNF), DtEmisNF?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(VlrBruto), VlrBruto));
            element.Add(new XElement(ns + nameof(VrCPDescPR), VrCPDescPR));
            element.Add(new XElement(ns + nameof(VrRatDescPR), VrRatDescPR));
            element.Add(new XElement(ns + nameof(VrSenarDesc), VrSenarDesc));
            return element;

        }
    }
}
