using DevBr.Core.eSocial.Eventos.Beneficios.S2405;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1210
{
    public class EvtPgtos : IdeEvento<EvtPgtos>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public IdeBenef? IdeBenef { get; set; }
        public List<InfoPgto>? InfoPgto { get; set; }
        public EvtPgtos(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtPgtos));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(IdeBenef?.GetXmlElements(ns));
            InfoPgto?.ForEach(item => element.Add(item?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoPgto : EntityType<InfoPgto>, IDisposable
    {
        public DateTime? DtPgto { get; set; }
        public uint? TpPgto { get; set; }
        public string? PerRef { get; set; }
        public string? IdeDmDev { get; set; }
        public double? VrLiq { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoPgto));
            element.Add(new XElement(ns + nameof(DtPgto), DtPgto?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(TpPgto), TpPgto));
            element.Add(new XElement(ns + nameof(PerRef), PerRef));
            element.Add(new XElement(ns + nameof(IdeDmDev), IdeDmDev));
            element.Add(new XElement(ns + nameof(VrLiq), VrLiq));
            return element;

        }
    }
}
