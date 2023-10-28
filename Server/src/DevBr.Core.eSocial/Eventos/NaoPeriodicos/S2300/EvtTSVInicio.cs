using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class EvtTSVInicio : IdeEvento<EvtTSVInicio>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public Trabalhador? Trabalhador { get; set; }
        public InfoTSVInicio? InfoTSVInicio { get; set; }
        public EvtTSVInicio(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtTSVInicio));
            element.Add(GetXmlEvento(ns));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(Trabalhador?.GetXmlElements(ns));
            element.Add(InfoTSVInicio?.GetXmlElements(ns));
            return element;

        }
    }
}
