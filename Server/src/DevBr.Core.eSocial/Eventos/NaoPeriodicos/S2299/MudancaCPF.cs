using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class MudancaCPF : EntityType<MudancaCPF>, IDisposable
    {
        public string? NovoCPF { get; set; }
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

            XElement element = new XElement(ns + nameof(MudancaCPF));
            element.Add(new XElement(ns + nameof(NovoCPF), NovoCPF));
            return element;

        }
    }
}
