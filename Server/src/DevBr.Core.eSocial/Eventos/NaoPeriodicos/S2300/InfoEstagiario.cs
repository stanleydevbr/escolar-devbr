using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class InfoEstagiario : EntityType<InfoEstagiario>, IDisposable
    {
        public char? NatEstagio { get; set; }
        public uint? NivEstagio { get; set; }
        public string? AreaAtuacao { get; set; }
        public string? NrApol { get; set; }
        public DateTime? DtPrevTerm { get; set; }
        public InstEnsino? InstEnsino { get; set; }
        public AgeIntegracao? AgeIntegracao { get; set; }
        public SupervisorEstagio? SupervisorEstagio { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoEstagiario));
            element.Add(new XElement(ns + nameof(NatEstagio), NatEstagio));
            element.Add(new XElement(ns + nameof(NivEstagio), NivEstagio));
            element.Add(new XElement(ns + nameof(AreaAtuacao), AreaAtuacao));
            element.Add(new XElement(ns + nameof(NrApol), NrApol));
            element.Add(new XElement(ns + nameof(DtPrevTerm), DtPrevTerm?.ToString("dd-MM-yyyy")));
            element.Add(InstEnsino?.GetXmlElements(ns));
            element.Add(AgeIntegracao?.GetXmlElements(ns));
            element.Add(SupervisorEstagio?.GetXmlElements(ns));
            return element;

        }
    }
}
