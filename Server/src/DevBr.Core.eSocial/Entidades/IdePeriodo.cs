using DevBr.Core.eSocial.Events.Bases;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class IdePeriodo : EntityType<IdePeriodo>, IDisposable
    {
        public DateTime? IniValid { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.IniValid)
                .NotEmpty()
                .WithMessage("E necessário informar o início de validade.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            XElement element = new XElement(ns + nameof(IdePeriodo));
            element.Add(new XElement(ns + nameof(IniValid), IniValid?.ToString("yyyy-MM")));
            return element;
        }


    }
}
