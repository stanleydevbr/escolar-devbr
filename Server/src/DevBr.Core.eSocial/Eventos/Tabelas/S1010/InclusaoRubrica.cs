using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1010
{
    public class InclusaoRubrica : EntityType<InclusaoRubrica>, IDisposable
    {
        public IdeRubrica? IdeRubrica { get; set; }
        public DadosRubrica? DadosRubrica { get; set; }
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
            XElement element = new XElement(ns + "Inclusao");
            element.Add(new XElement(ns + nameof(IdeRubrica), IdeRubrica));
            return element;
        }
    }
}
