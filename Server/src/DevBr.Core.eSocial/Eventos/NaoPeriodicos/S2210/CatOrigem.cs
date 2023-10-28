using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2210
{
    public class CatOrigem : EntityType<CatOrigem>, IDisposable
    {
        public string? NrRecCatOrig { get; set; }
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

            XElement element = new XElement(ns + nameof(CatOrigem));
            element.Add(new XElement(ns + nameof(NrRecCatOrig), NrRecCatOrig));
            return element;

        }
    }
}

