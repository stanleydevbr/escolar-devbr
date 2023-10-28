using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class InfoComplem : EntityType<InfoComplem>, IDisposable
    {
        public string? NmTrab { get; set; }
        public DateTime? DtNascto { get; set; }
        public SucessaoVinc? SucessaoVinc { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoComplem));
            element.Add(new XElement(ns + nameof(NmTrab), NmTrab));
            element.Add(new XElement(ns + nameof(DtNascto), DtNascto));
            element.Add(SucessaoVinc?.GetXmlElements(ns));
            return element;
        }
    }
}
