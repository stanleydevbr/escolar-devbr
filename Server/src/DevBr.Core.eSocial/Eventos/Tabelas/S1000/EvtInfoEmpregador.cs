using DevBr.Core.eSocial.Interfaces.Roots;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class EvtInfoEmpregador : IdeEvento<EvtInfoEmpregador>, IeSocialAggregate
    {
        public IdeEmpregador? IdeEmpregador { get; set; } = null;
        public InfoEmpregador? InfoEmpregador { get; set; } = null;
        public EvtInfoEmpregador(string evento, string version) : base(evento, version) { }
        public EvtInfoEmpregador(uint tpAmb, uint procEmi, uint verProc, string evento, string version) : base(tpAmb, procEmi, verProc, evento, version) { }

        public XDocument GetXmlDocument()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "UTF-8", "no"),
                new XElement(ns + "eSocial",
                    new XAttribute("xmlns", ns),
                        GetXmlElements(ns)));
            return doc; //.SginXDocument(certificate, ns);
        }

        protected override XElement? GetXmlElements(XNamespace ns)
        {
            var elements = new XElement(ns + nameof(EvtInfoEmpregador), new XAttribute(nameof(Id), GerarNovoId(IdeEmpregador?.TpInsc?.ToString(), IdeEmpregador?.NrInsc)));
            elements.Add(GetXmlEvento(ns));
            elements.Add(IdeEmpregador?.GetXmlElements(ns));
            elements.Add(InfoEmpregador?.GetXmlElements(ns));
            return elements;
        }

        public override bool EhValido()
        {
            RuleFor(x => x.IdeEmpregador)
                .NotNull()
                .WithMessage("É necessário informar os dados de identificação do empregador.");

            RuleFor(x => x.InfoEmpregador)
                .NotNull()
                .WithMessage("É necessário informar os dados do empregador.");

            RuleFor(x => x.IdeEmpregador)
                .Must(IdeEmpregador => IdeEmpregador.EhValido())
                .WithMessage($"{nameof(IdeEmpregador)} - valores informados inconsistêntes");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
