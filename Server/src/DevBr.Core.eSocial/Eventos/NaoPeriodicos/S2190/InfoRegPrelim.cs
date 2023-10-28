using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2190
{
    public class InfoRegPrelim : EntityType<InfoRegPrelim>, IDisposable
    {
        public string? CpfTrab { get; set; }
        public DateTime? DtNascto { get; set; }
        public DateTime? DtAdm { get; set; }
        public string? Matricula { get; set; }
        public uint? CodCategoria { get; set; }
        public byte NatAtividade { get; set; }
        public InfoRegCTPS? InfoRegCTPS { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoRegPrelim));
            element.Add(new XElement(ns + nameof(CpfTrab), CpfTrab));
            element.Add(new XElement(ns + nameof(DtNascto), DtNascto?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DtAdm), DtAdm?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            element.Add(new XElement(ns + nameof(CodCategoria), CodCategoria));
            element.Add(new XElement(ns + nameof(NatAtividade), NatAtividade));
            element.Add(new XElement(InfoRegCTPS?.GetXmlElements(ns)));
            return element;

        }
    }
}
