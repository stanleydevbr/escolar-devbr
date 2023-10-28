using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2206
{
    public class IdeVinculo : EntityType<IdeVinculo>, IDisposable
    {
        public string? CpfTrab { get; set; }
        public string? Matricula { get; set; }
        public string? CodCateg { get; set; }
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
            XElement element = new XElement(ns + nameof(IdeVinculo));
            element.Add(new XElement(ns + nameof(CpfTrab), CpfTrab));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            if (!string.IsNullOrEmpty(CodCateg))
                element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            return element;
        }
    }
}
