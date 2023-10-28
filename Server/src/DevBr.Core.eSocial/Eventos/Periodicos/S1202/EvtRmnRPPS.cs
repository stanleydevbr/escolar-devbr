using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Eventos.Periodicos.S1200;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1202
{
    internal class EvtRmnRPPS : IdeEvento<EvtRmnRPPS>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeTrabalhadorRPPS? IdeTrabalhador { get; set; }
        public List<DmDevRPPS>? DmDev { get; set; }
        public EvtRmnRPPS(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtRmnRPPS));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeTrabalhador?.GetXmlElements(ns));
            DmDev?.ForEach(d => element.Add(d?.GetXmlElements(ns)));
            return element;

        }
    }

    public class DmDevRPPS : EntityType<DmDevRPPS>, IDisposable
    {
        public string? IdeDmDev { get; set; }
        public uint? CodCateg { get; set; }
        public InfoPerApur? InfoPerApur { get; set; }
        public List<IdeEstabRPPS>? Estabelecimentos { get; set; }
        public InfoPerAntRPPS? InfoPerAnt { get; set; }
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
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            element.Add(InfoPerApur?.GetXmlElements(ns));
            Estabelecimentos?.ForEach(estab => element.Add(estab?.GetXmlElements(ns)));
            element.Add(InfoPerAnt?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoPerAntRPPS : EntityType<InfoPerAntRPPS>, IDisposable
    {
        public char? RemunOrgSuc { get; set; }
        public List<IdePeriodoRPPS>? Periodos { get; set; }
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
            element.Add(new XElement(ns + nameof(RemunOrgSuc), RemunOrgSuc));
            Periodos?.ForEach(p => element.Add(p?.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdePeriodoRPPS : EntityType<IdePeriodoRPPS>, IDisposable
    {
        public DateTime? PerRef { get; set; }
        public List<IdeEstabRPPS>? Estabelecimentos { get; set; }
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

    public class IdeEstabRPPS : EntityType<IdeEstabRPPS>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public List<RemunPerApurRPPS>? Remeneracoes { get; set; }

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
            Remeneracoes?.ForEach(rem => element.Add(rem?.GetXmlElements(ns)));
            return element;

        }
    }

    public class RemunPerApurRPPS : EntityType<RemunPerApurRPPS>, IDisposable
    {
        public string? Matricula { get; set; }
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

            XElement element = new XElement(ns + "RemunPerApur");
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            ItensRemun?.ForEach(item => element.Add(item?.GetXmlElements(ns)));
            return element;

        }
    }

    public class IdeTrabalhadorRPPS : EntityType<IdeTrabalhadorRPPS>, IDisposable
    {
        public string? CpfTrab { get; set; }
        public InfoComplemRPPS? InfoComplem { get; set; }
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
            element.Add(InfoComplem?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoComplemRPPS : EntityType<InfoComplemRPPS>, IDisposable
    {
        public string? NmTrab { get; set; }
        public DateTime? DtNascto { get; set; }
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

            XElement element = new XElement(ns + "InfoComplem");
            element.Add(new XElement(ns + nameof(NmTrab), NmTrab));
            element.Add(new XElement(ns + nameof(DtNascto), DtNascto?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
