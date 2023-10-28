using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Totalizadores.S5002
{
    public class EvtIrrfBenef : IdeEvento<EvtIrrfBenef>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeTrabalhadorIrrf? IdeTrabalhador { get; set; }
        public EvtIrrfBenef(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtIrrfBenef));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeTrabalhador?.GetXmlElements(ns));
            return element;

        }
    }

    public class IdeTrabalhadorIrrf : EntityType<IdeTrabalhadorIrrf>, IDisposable
    {
        public string? CpfBenef { get; set; }
        public List<DmDevIrrf>? Demonstrativos { get; set; }
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
            element.Add(new XElement(ns + nameof(CpfBenef), CpfBenef));
            Demonstrativos?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class DmDevIrrf : EntityType<DmDevIrrf>, IDisposable
    {
        public List<InfoIR>? Deducoes { get; set; }
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

            XElement element = new XElement(ns + "DmDev");
            Deducoes?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoIR : EntityType<InfoIR>, IDisposable
    {
        public uint? TpInfoIR { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoIR));
            element.Add(new XElement(ns + nameof(TpInfoIR), TpInfoIR));
            element.Add(new XElement(ns + nameof(Valor), Valor));
            return element;

        }
    }
}
