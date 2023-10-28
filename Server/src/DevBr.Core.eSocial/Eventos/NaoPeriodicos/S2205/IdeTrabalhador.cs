using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2205
{
    public class IdeTrabalhador : EntityType<IdeTrabalhador>, IDisposable
    {
        public string? CpfTrab { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeTrabalhador));
            element.Add(new XElement(ns + nameof(CpfTrab), CpfTrab));
            return element;

        }
    }
}
