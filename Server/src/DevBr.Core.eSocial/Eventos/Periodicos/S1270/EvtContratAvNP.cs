using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1270
{
    public class EvtContratAvNP : IdeEvento<EvtContratAvNP>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public List<RemunAvNP>? Remuneracoes { get; set; }
        public EvtContratAvNP(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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
            XElement element = new XElement(ns + nameof(EvtContratAvNP));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            Remuneracoes?.ForEach(remun => element.Add(remun?.GetXmlElements(ns)));
            return element;
        }
    }

    public class RemunAvNP : EntityType<RemunAvNP>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public string? CodLotacao { get; set; }
        public double? VrBcCP00 { get; set; }
        public double? VrBcCP15 { get; set; }
        public double? VrBcCp20 { get; set; }
        public double? VrBcCp25 { get; set; }
        public double? VrBcCp13 { get; set; }
        public double? VrBcFgts { get; set; }
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

            XElement element = new XElement(ns + nameof(RemunAvNP));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(new XElement(ns + nameof(CodLotacao), CodLotacao));
            element.Add(new XElement(ns + nameof(VrBcCP00), VrBcCP00));
            element.Add(new XElement(ns + nameof(VrBcCP15), VrBcCP15));
            element.Add(new XElement(ns + nameof(VrBcCp20), VrBcCp20));
            element.Add(new XElement(ns + nameof(VrBcCp25), VrBcCp25));
            element.Add(new XElement(ns + nameof(VrBcCp13), VrBcCp13));
            element.Add(new XElement(ns + nameof(VrBcFgts), VrBcFgts));
            element.Add(new XElement(ns + nameof(VrDescCP), VrDescCP));
            return element;

        }
    }
}
