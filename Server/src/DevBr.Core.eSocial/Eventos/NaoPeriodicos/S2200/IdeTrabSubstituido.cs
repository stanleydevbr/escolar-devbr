using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class IdeTrabSubstituido : EntityType<IdeTrabSubstituido>, IDisposable
    {
        public string? CpfTrabSubst { get; set; }

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
            XElement element = new XElement(ns + nameof(IdeTrabSubstituido));
            element.Add(new XElement(ns + nameof(CpfTrabSubst), CpfTrabSubst));
            return element;
        }
    }
}
