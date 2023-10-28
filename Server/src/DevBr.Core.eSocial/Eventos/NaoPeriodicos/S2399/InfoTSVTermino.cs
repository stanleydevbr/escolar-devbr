using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2399
{
    public class InfoTSVTermino : EntityType<InfoTSVTermino>, IDisposable
    {
        public DateTime? DtTerm { get; set; }
        public string? MtvDesligTSV { get; set; }
        public double? PensAlim { get; set; }
        public double? VrAlim { get; set; }
        public string? NrProcTrab { get; set; }
        public MudancaCPF? MudancaCPF { get; set; }
        public VerbasRescTerm? VerbasResc { get; set; }
        public Quarentena? Quarentena { get; set; }
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

            XElement element = new XElement(ns + "InfoTSVTermino");
            element.Add(new XElement(ns + nameof(DtTerm), DtTerm?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(MtvDesligTSV), MtvDesligTSV));
            element.Add(new XElement(ns + nameof(PensAlim), PensAlim));
            element.Add(new XElement(ns + nameof(VrAlim), VrAlim));
            element.Add(new XElement(ns + nameof(NrProcTrab), NrProcTrab));
            element.Add(MudancaCPF?.GetXmlElements(ns));
            element.Add(VerbasResc?.GetXmlElements(ns));
            return element;

        }
    }

}
