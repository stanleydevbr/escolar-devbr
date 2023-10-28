using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2400
{
    public class EvtCdBenefIn : IdeEvento<EvtCdBenefIn>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public Beneficiario? Beneficiario { get; set; }
        public EvtCdBenefIn(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtCdBenefIn));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(Beneficiario?.GetXmlElements(ns));
            return element;

        }
    }
}
