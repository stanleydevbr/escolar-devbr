using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2206;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2231
{
    public class EvtCessao : IdeEvento<EvtCessao>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeVinculo? IdeVinculo { get; set; }
        public InfoCessaoS2231? InfoCessao { get; set; }

        public EvtCessao(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtCessao));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeVinculo?.GetXmlElements(ns));
            element.Add(InfoCessao?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoCessaoS2231 : EntityType<InfoCessaoS2231>, IDisposable
    {
        public IniCessao? IniCessao { get; set; }
        public FimCessao? FimCessao { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoCessaoS2231));
            element.Add(IniCessao?.GetXmlElements(ns));
            element.Add(FimCessao?.GetXmlElements(ns));
            return element;
        }
    }

    public class FimCessao : EntityType<FimCessao>, IDisposable
    {
        public DateTime? DtTermCessao { get; set; }
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

            XElement element = new XElement(ns + nameof(FimCessao));
            element.Add(new XElement(ns + nameof(DtTermCessao), DtTermCessao?.ToString("dd-MM-yyyy")));
            return element;

        }
    }

    public class IniCessao : EntityType<IniCessao>, IDisposable
    {
        public DateTime? DtIniCessao { get; set; }
        public string? CnpjCess { get; set; }
        public char RespRemun { get; set; }

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

            XElement element = new XElement(ns + nameof(IniCessao));
            element.Add(new XElement(ns + nameof(DtIniCessao), DtIniCessao?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(CnpjCess), CnpjCess));
            element.Add(new XElement(ns + nameof(RespRemun), RespRemun));
            return element;

        }
    }
}
