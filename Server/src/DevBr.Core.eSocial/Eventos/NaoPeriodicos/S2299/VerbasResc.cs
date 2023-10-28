using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class VerbasResc : EntityType<VerbasResc>, IDisposable
    {
        public List<DmDev>? DmDevs { get; set; }
        public List<ProcJudTrab>? Processos { get; set; }
        public InfoMV? InfoMV { get; set; }
        public ProcCS? ProcCS { get; set; }
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
            XElement element = new XElement(ns + nameof(VerbasResc));
            DmDevs?.ForEach(d => element.Add(d?.GetXmlElements(ns)));
            Processos?.ForEach(p => p.GetXmlElements(ns));
            element.Add(InfoMV?.GetXmlElements(ns));
            element.Add(ProcCS?.GetXmlElements(ns));
            return element;

        }
    }
}
