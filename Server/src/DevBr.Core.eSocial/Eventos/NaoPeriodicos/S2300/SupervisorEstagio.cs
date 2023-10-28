using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class SupervisorEstagio : EntityType<SupervisorEstagio>, IDisposable
    {
        public string? CpfSupervisor { get; set; }
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

            XElement element = new XElement(ns + nameof(SupervisorEstagio));
            element.Add(new XElement(ns + nameof(CpfSupervisor), CpfSupervisor));
            return element;

        }
    }
}
