using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class NovaValidade : EntityType<NovaValidade>, IDisposable
    {
        public DateTime? IniValid { get; set; }
        public DateTime? FimValid { get; set; }
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

            XElement element = new XElement(ns + nameof(NovaValidade));
            element.Add(new XElement(ns + nameof(IniValid), IniValid?.ToString("yyyy-MM")));
            element.Add(new XElement(ns + nameof(FimValid), FimValid?.ToString("yyyy-MM")));
            return element;

        }
    }
}
