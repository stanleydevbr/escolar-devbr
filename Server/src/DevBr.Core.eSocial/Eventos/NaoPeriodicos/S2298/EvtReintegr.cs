using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2206;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2298
{
    public class EvtReintegr : IdeEvento<EvtReintegr>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeVinculo? IdeVinculo { get; set; }
        public InfoReintegr? InfoReintegr { get; set; }
        public EvtReintegr(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtReintegr));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeVinculo?.GetXmlElements(ns));
            element.Add(InfoReintegr?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoReintegr : EntityType<InfoReintegr>, IDisposable
    {
        public uint? TpReint { get; set; }
        public string? NrProcJud { get; set; }
        public string? NrLeiAnistia { get; set; }
        public DateTime? DtEfetRetorno { get; set; }
        public DateTime? DtEfeito { get; set; }

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
            XElement element = new XElement(ns + nameof(InfoReintegr));
            element.Add(new XElement(ns + nameof(TpReint), TpReint));
            element.Add(new XElement(ns + nameof(NrProcJud), NrProcJud));
            element.Add(new XElement(ns + nameof(NrLeiAnistia), NrLeiAnistia));
            element.Add(new XElement(ns + nameof(DtEfetRetorno), DtEfetRetorno?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DtEfeito), DtEfeito?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
