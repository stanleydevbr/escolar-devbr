using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2418
{
    public class InfoReativ : EntityType<InfoReativ>, IDisposable
    {
        public DateTime? DtEfetReativ { get; set; }
        public DateTime? DtEfeito { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoReativ));
            element.Add(new XElement(ns + nameof(DtEfetReativ), DtEfetReativ?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DtEfeito), DtEfeito?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
