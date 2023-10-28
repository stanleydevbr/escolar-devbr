using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.eSocial.Interfaces.Roots;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1280
{
    public class EvtInfoComplPer : IdeEvento<EvtInfoComplPer>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public InfoSubstPatr? InfoSubstPatr { get; set; }
        public InfoAtivConcom? InfoAtivConcom { get; set; }
        public InfoPercTransf11096? InfoPercTransf11096 { get; set; }
        public EvtInfoComplPer(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version)
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

            XElement element = new XElement(ns + nameof(EvtInfoComplPer));
            element.Add(IdeEmpregador?.GetXmlElements(ns));
            element.Add(InfoSubstPatr?.GetXmlElements(ns));
            element.Add(InfoAtivConcom?.GetXmlElements(ns));
            element.Add(InfoPercTransf11096?.GetXmlElements(ns));
            return element;

        }
    }

    public class InfoPercTransf11096 : EntityType<InfoPercTransf11096>, IDisposable
    {
        public uint? PercTransf { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoPercTransf11096));
            element.Add(new XElement(ns + nameof(PercTransf), PercTransf));
            return element;

        }
    }

    public class InfoSubstPatr : EntityType<InfoSubstPatr>, IDisposable
    {
        public uint? IndSubstPatr { get; set; }
        public double? PerRedContrib { get; set; }
        public List<InfoSubstPatrOpPort>? InfoSubstPatrOpPort { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoSubstPatr));
            element.Add(new XElement(ns + nameof(IndSubstPatr), IndSubstPatr));
            element.Add(new XElement(ns + nameof(PerRedContrib), PerRedContrib));
            InfoSubstPatrOpPort?.ForEach(inf => element.Add(inf?.GetXmlElements(ns)));
            return element;

        }
    }

    public class InfoSubstPatrOpPort : EntityType<InfoSubstPatrOpPort>, IDisposable
    {
        public string? CodLotacao { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoSubstPatrOpPort));
            element.Add(new XElement(ns + nameof(CodLotacao), CodLotacao));
            return element;

        }
    }

    public class InfoAtivConcom : EntityType<InfoAtivConcom>, IDisposable
    {
        public uint? FatorMes { get; set; }
        public uint? Fator13 { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoAtivConcom));
            element.Add(new XElement(ns + nameof(FatorMes), FatorMes));
            element.Add(new XElement(ns + nameof(Fator13), Fator13));
            return element;

        }
    }
}
