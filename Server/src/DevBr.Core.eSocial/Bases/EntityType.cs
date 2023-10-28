using FluentValidation;
using FluentValidation.Results;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events.Bases
{
    public abstract class EntityType<T> : AbstractValidator<T> where T : EntityType<T>
    {
        public string? Id { get; set; }
        public EntityType()
        {
            ValidationResult = new ValidationResult();
        }
        public abstract bool EhValido();
        internal abstract XElement? GetXmlElements(XNamespace ns);
        public ValidationResult? ValidationResult { get; protected set; }
    }
}
