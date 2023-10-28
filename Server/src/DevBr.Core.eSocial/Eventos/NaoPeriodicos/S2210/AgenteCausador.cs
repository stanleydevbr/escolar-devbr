using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2210
{
    public class AgenteCausador : EntityType<AgenteCausador>, IDisposable
    {
        public ulong? CodAgntCausador { get; set; }
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

            XElement element = new XElement(ns + nameof(AgenteCausador));
            element.Add(new XElement(ns + nameof(CodAgntCausador), CodAgntCausador));
            return element;

        }
    }
}

