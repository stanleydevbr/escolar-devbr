using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2405
{
    public class EvtCdBenefAlt : IdeEvento<EvtCdBenefAlt>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeBenef? IdeBenef { get; set; }
        public AlteracaoBenef? Alteracao { get; set; }
        public EvtCdBenefAlt(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtCdBenefAlt));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeBenef?.GetXmlElements(ns));
            element.Add(Alteracao?.GetXmlElements(ns));
            return element;

        }
    }
}
