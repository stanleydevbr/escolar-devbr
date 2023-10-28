using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class InfoPerAnt : EntityType<InfoPerAnt>, IDisposable
    {
        public List<IdeADC>? IdeADC { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoPerAnt));
            IdeADC?.ForEach(x => element.Add(x.GetXmlElements(ns)));
            return element;

        }
    }
}
