using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2220
{
    public class Aso : EntityType<Aso>, IDisposable
    {
        public DateTime? DtAso { get; set; }
        public uint ResAso { get; set; }
        public Exame? Exame { get; set; }
        public Medico? Medico { get; set; }
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

            XElement element = new XElement(ns + nameof(Aso));
            element.Add(new XElement(ns + nameof(DtAso), DtAso?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(ResAso), ResAso));
            element.Add(Exame?.GetXmlElements(ns));
            element.Add(Medico?.GetXmlElements(ns));
            return element;

        }
    }
}
