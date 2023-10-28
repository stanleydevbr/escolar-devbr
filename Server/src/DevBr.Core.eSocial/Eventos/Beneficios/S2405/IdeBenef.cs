using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2405
{
    public class IdeBenef : EntityType<IdeBenef>, IDisposable
    {
        public string? CpfBenef { get; set; }
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
            XElement element = new XElement(ns + nameof(IdeBenef));
            element.Add(new XElement(ns + nameof(CpfBenef), CpfBenef));
            return element;
        }
    }
}
