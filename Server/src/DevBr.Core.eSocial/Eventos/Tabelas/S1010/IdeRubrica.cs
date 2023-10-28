using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1010
{
    public class IdeRubrica : EntityType<IdeRubrica>, IDisposable
    {
        public string? CodRubr { get; set; }
        public string? IdeTabRubr { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeRubrica));
            element.Add(new XElement(ns + nameof(CodRubr), CodRubr));
            element.Add(new XElement(ns + nameof(IdeTabRubr), IdeTabRubr));
            element.Add(new XElement(ns + nameof(IniValid), IniValid));
            element.Add(new XElement(ns + nameof(FimValid), FimValid));
            return element;
        }
    }
}
