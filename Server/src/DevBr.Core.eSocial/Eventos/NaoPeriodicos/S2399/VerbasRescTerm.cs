using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2399
{
    public class VerbasRescTerm : EntityType<VerbasRescTerm>, IDisposable
    {
        public List<DmDevTerm>? DmDevs { get; set; }
        public List<ProcJudTrab>? Processos { get; set; }
        public InfoMV? InfoMV { get; set; }
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

            XElement element = new XElement(ns + "VerbasResc");
            DmDevs?.ForEach(x => element.Add(x?.GetXmlElements(ns)));
            Processos?.ForEach(proc => element.Add(proc?.GetXmlElements(ns)));
            element.Add(InfoMV?.GetXmlElements(ns));
            return element;

        }
    }

}
