using DevBr.Core.eSocial.Eventos.Beneficios.S2405;
using DevBr.Core.eSocial.Eventos.Periodicos.S1200;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1207
{
    public class EvtBenPrRP : IdeEvento<EvtBenPrRP>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeBenef? IdeBenef { get; set; }
        public List<DmDevRP>? DmDev { get; set; }
        public EvtBenPrRP(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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
            XElement element = new XElement(ns + nameof(EvtBenPrRP));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeBenef?.GetXmlElements(ns));
            DmDev?.ForEach(item => element.Add(item?.GetXmlElements(ns)));
            return element;


        }
    }

    public class DmDevRP : EntityType<DmDevRP>, IDisposable
    {
        public string? IdeDmDev { get; set; }
        public string? NrBeneficio { get; set; }
        public InfoPerApurRP? InfoPerApur { get; set; }
        public InfoPerAntRP? InfoPerAnt { get; set; }
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
            element.Add(new XElement(ns + nameof(IdeDmDev), IdeDmDev));
            element.Add(new XElement(ns + nameof(NrBeneficio), NrBeneficio));
            element.Add(InfoPerApur?.GetXmlElements(ns));
            element.Add(InfoPerAnt?.GetXmlElements(ns));

            return element;

        }
    }

    public class InfoPerAntRP : EntityType<InfoPerAntRP>, IDisposable
    {
        public List<IdePeriodoRP>? IdePeriodo { get; set; }
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

            XElement element = new XElement(ns + "InfoPerAnt");
            IdePeriodo?.ForEach(p => element.Add(p?.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdePeriodoRP : EntityType<IdePeriodoRP>, IDisposable
    {
        public DateTime? PerRef { get; set; }
        public List<IdeEstabRP>? Estabelecimentos { get; set; }
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

            XElement element = new XElement(ns + "IdePeriodo");
            element.Add(new XElement(ns + nameof(PerRef), PerRef?.ToString("yyyy-MM")));
            Estabelecimentos?.ForEach(estab => element.Add(estab?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoPerApurRP : EntityType<InfoPerApurRP>, IDisposable
    {
        public List<IdeEstabRP>? Estabelecimentos { get; set; }
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

            XElement element = new XElement(ns + "InfoPerApur");
            Estabelecimentos?.ForEach(estab => element.Add(estab.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdeEstabRP : EntityType<IdeEstabRP>, IDisposable
    {
        public List<ItensRemun>? ItensRemun { get; set; }
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
            ItensRemun?.ForEach(item => element.Add(item?.GetXmlElements(ns)));
            return element;

        }
    }
}
