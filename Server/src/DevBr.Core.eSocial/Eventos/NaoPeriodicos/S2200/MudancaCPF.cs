using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class MudancaCPF : EntityType<MudancaCPF>, IDisposable
    {
        public string? CpfAnt { get; set; }
        public string? MatricAnt { get; set; }
        public DateTime? DtAltCPF { get; set; }
        public string? Observacao { get; set; }
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
            XElement element = new XElement(ns + nameof(MudancaCPF));
            element.Add(new XElement(ns + nameof(CpfAnt), CpfAnt));
            element.Add(new XElement(ns + nameof(MatricAnt), MatricAnt));
            element.Add(new XElement(ns + nameof(DtAltCPF), DtAltCPF?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            return element;
        }
    }
}
