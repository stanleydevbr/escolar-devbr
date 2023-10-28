using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Interfaces.Roots;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1010
{
    public class EvtTabRubrica : IdeEvento<EvtTabRubrica>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; }
        public InfoRubrica? InfoRubrica { get; set; }
        public EvtTabRubrica(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version) { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.IdeEmpregador)
                .NotNull()
                .WithMessage($"{IdeEmpregador} - É necessário informar os dados do empregador");

            RuleFor(x => x.InfoRubrica)
                .NotNull()
                .WithMessage($"{InfoRubrica} - É necessário informar os dados da rubrica");

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
            var elements = new XElement(ns + nameof(EvtTabRubrica), new XAttribute(nameof(Id), GerarNovoId(IdeEmpregador?.TpInsc?.ToString(), IdeEmpregador?.NrInsc)));
            elements.Add(GetXmlEvento(ns));
            elements.Add(IdeEmpregador?.GetXmlElements(ns));
            elements.Add(InfoRubrica?.GetXmlElements(ns));
            return elements;
        }
    }
}
