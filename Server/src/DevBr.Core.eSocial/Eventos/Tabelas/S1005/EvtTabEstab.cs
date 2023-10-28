using DevBr.Core.eSocial.Enumeradores;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Interfaces.Roots;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class EvtTabEstab : IdeEvento<EvtTabEstab>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public InfoEstab? InfoEstab { get; set; }

        public EvtTabEstab(string evento, string version) : base(evento, version) { }
        public EvtTabEstab(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version) { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.TpAmb)
                .Must(c => TipoAmbiente.ToCodigos().Contains(c.Value))
                .WithMessage($"Informe um valor valido, valores validos: {TipoAmbiente.ToValores}");

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
            var elements = new XElement(ns + nameof(EvtTabEstab), new XAttribute(nameof(Id), GerarNovoId(IdeEmpregador?.TpInsc?.ToString(), IdeEmpregador?.NrInsc)));
            elements.Add(GetXmlEvento(ns));
            elements.Add(IdeEmpregador?.GetXmlElements(ns));
            elements.Add(InfoEstab?.GetXmlElements(ns));
            return elements;
        }
    }
}
