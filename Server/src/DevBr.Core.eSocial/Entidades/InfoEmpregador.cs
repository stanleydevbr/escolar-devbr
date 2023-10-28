using DevBr.Core.eSocial.Events.Bases;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{

    public class InfoEmpregador : EntityType<InfoEmpregador>, IDisposable
    {
        public Inclusao? Inclusao { get; set; } = null;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.Inclusao)
                .NotNull()
                .WithMessage($"{nameof(Inclusao)} - Informe os dados de inclusão");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            var elements = new XElement(ns + nameof(InfoEmpregador));
            elements.Add(Inclusao?.GetXmlElements(ns));
            return elements;
        }

    }
}
