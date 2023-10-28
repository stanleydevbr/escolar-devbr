using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1070
{
    public class IdeProcesso : EntityType<IdeProcesso>, IDisposable
    {
        public byte? TpProc { get; set; }
        public string? NrProc { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeProcesso));
            element.Add(new XElement(ns + nameof(TpProc), TpProc));
            element.Add(new XElement(ns + nameof(NrProc), NrProc));
            element.Add(new XElement(ns + nameof(IniValid), IniValid?.ToString("yyyy-MM")));
            element.Add(new XElement(ns + nameof(FimValid), FimValid?.ToString("yyyy-MM")));
            return element;

        }
    }
}
