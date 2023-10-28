using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2306
{
    public class IdeTrabSemVinculo : EntityType<IdeTrabSemVinculo>, IDisposable
    {
        public string? CpfTrab { get; set; }
        public string? Matricula { get; set; }
        public uint? CodCateg { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeTrabSemVinculo));
            element.Add(new XElement(ns + nameof(CpfTrab), CpfTrab));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            return element;

        }
    }
}
