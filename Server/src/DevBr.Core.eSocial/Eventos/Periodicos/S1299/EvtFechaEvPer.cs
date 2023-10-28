using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1299
{
    public class EvtFechaEvPer : IdeEvento<EvtFechaEvPer>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public InfoFech? InfoFech { get; set; }
        public EvtFechaEvPer(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtFechaEvPer));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoFech : EntityType<InfoFech>, IDisposable
    {
        public char? EvtRemun { get; set; }
        public char? EvtComProd { get; set; }
        public char? EvtContratAvNP { get; set; }
        public char? EvtInfoComplPer { get; set; }
        public char? IndExcApur1250 { get; set; }
        public char? TransDCTFWeb { get; set; }
        public char? NaoValid { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoFech));
            element.Add(new XElement(ns + nameof(EvtRemun), EvtRemun));
            element.Add(new XElement(ns + nameof(EvtComProd), EvtComProd));
            element.Add(new XElement(ns + nameof(EvtContratAvNP), EvtContratAvNP));
            element.Add(new XElement(ns + nameof(EvtInfoComplPer), EvtInfoComplPer));
            element.Add(new XElement(ns + nameof(IndExcApur1250), IndExcApur1250));
            element.Add(new XElement(ns + nameof(TransDCTFWeb), TransDCTFWeb));
            element.Add(new XElement(ns + nameof(NaoValid), NaoValid));
            return element;

        }
    }
}
