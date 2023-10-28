using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2220
{
    public class Exame : EntityType<Exame>, IDisposable
    {
        public DateTime? DtExm { get; set; }
        public ulong? ProcRealizado { get; set; }
        public string? ObsProc { get; set; }
        public uint? OrdExame { get; set; }
        public uint? IndResult { get; set; }
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

            XElement element = new XElement(ns + nameof(Exame));
            element.Add(new XElement(ns + nameof(DtExm), DtExm?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(ProcRealizado), ProcRealizado));
            element.Add(new XElement(ns + nameof(ObsProc), ObsProc));
            element.Add(new XElement(ns + nameof(OrdExame), OrdExame));
            element.Add(new XElement(ns + nameof(IndResult), IndResult));
            return element;

        }
    }
}
