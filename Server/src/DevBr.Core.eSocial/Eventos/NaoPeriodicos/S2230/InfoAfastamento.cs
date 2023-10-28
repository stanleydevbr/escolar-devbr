using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2230
{
    public class InfoAfastamento : EntityType<InfoAfastamento>, IDisposable
    {
        public IniAfastamento? IniAfastamento { get; set; }
        public InfoRetif? InfoRetif { get; set; }
        public FimAfastamento? FimAfastamento { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoAfastamento));
            element.Add(IniAfastamento?.GetXmlElements(ns));
            element.Add(InfoRetif?.GetXmlElements(ns));
            element.Add(FimAfastamento?.GetXmlElements(ns));
            return element;

        }
    }
}
