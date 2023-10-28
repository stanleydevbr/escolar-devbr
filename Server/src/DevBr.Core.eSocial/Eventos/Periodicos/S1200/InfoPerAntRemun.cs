using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class InfoPerAntRemun : EntityType<InfoPerAntRemun>, IDisposable
    {
        public List<IdeADCRemun>? IdeADC { get; set; }
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

            XElement element = new XElement(ns + "InfoPerAnt");
            IdeADC?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            return element;

        }
    }
}
