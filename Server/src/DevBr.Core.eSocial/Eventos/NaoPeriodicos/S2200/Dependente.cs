using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Dependente : EntityType<Dependente>, IDisposable
    {
        public string? TpDep { get; set; }
        public string? NmDep { get; set; }
        public DateTime? DtNascto { get; set; }
        public string? CpfDep { get; set; }
        public char? SexoDep { get; set; }
        public char? DepIRRF { get; set; }
        public char? DepSF { get; set; }
        public char? IncTrab { get; set; }
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

            XElement element = new XElement(ns + nameof(Dependente));
            element.Add(new XElement(ns + nameof(TpDep), TpDep));
            element.Add(new XElement(ns + nameof(NmDep), NmDep));
            element.Add(new XElement(ns + nameof(DtNascto), DtNascto?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(CpfDep), CpfDep));
            element.Add(new XElement(ns + nameof(SexoDep), SexoDep));
            element.Add(new XElement(ns + nameof(DepIRRF), DepIRRF));
            element.Add(new XElement(ns + nameof(DepSF), DepSF));
            element.Add(new XElement(ns + nameof(IncTrab), IncTrab));
            return element;

        }
    }
}
