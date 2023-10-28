using DevBr.Core.eSocial.Events.Bases;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class Inclusao : EntityType<Inclusao>, IDisposable
    {
        public IdePeriodo? IdePeriodo { get; set; }
        public InfoCadastro? InfoCadastro { get; set; }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            var elements = new XElement(ns + nameof(Inclusao));
            elements.Add(IdePeriodo?.GetXmlElements(ns));
            elements.Add(InfoCadastro?.GetXmlElements(ns));
            return elements;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.IdePeriodo)
                .NotNull()
                .WithMessage($"{nameof(IdePeriodo)} - Informe os dados do período");

            RuleFor(x => x.InfoCadastro)
                .NotNull()
                .WithMessage($"{nameof(InfoCadastro)} - Informe os dados de cadastro");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
