using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class IdeTrabalhador : EntityType<IdeTrabalhador>, IDisposable
    {
        public string? CpfTrab { get; set; }
        public InfoMV? InfoMV { get; set; }
        public InfoComplem? InfoComplem { get; set; }
        public List<ProcJudTrab>? Processos { get; set; }
        public InfoInterm? InfoInterm { get; set; }
        public List<DmDevRemun>? Demonstrativos { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeTrabalhador));
            element.Add(new XElement(ns + nameof(CpfTrab), CpfTrab));
            element.Add(InfoMV?.GetXmlElements(ns));
            element.Add(InfoComplem?.GetXmlElements(ns));
            Processos?.ForEach(proc => element.Add(proc?.GetXmlElements(ns)));
            element.Add(InfoInterm?.GetXmlElements(ns));
            Demonstrativos?.ForEach(dem => element.Add(dem?.GetXmlElements(ns)));
            return element;

        }
    }
}
