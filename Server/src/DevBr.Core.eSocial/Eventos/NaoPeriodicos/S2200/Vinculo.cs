using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Vinculo : EntityType<Vinculo>, IDisposable
    {
        public string? Matricula { get; set; }
        public byte? TpRegTrab { get; set; }
        public byte? TpRegPrev { get; set; }
        public char? CadIni { get; set; }
        public InfoRegimeTrab? InfoRegimeTrab { get; set; }
        public InfoContrato? InfoContrato { get; set; }
        public SucessaoVinc? SucessaoVinc { get; set; }
        public TransfDom? TransfDom { get; set; }
        public MudancaCPF? MudancaCPF { get; set; }
        public Afastamento? Afastamento { get; set; }
        public Desligamento? Desligamento { get; set; }
        public Cessao? Cessao { get; set; }
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

            XElement element = new XElement(ns + nameof(Vinculo));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            element.Add(new XElement(ns + nameof(TpRegTrab), TpRegTrab));
            element.Add(new XElement(ns + nameof(TpRegPrev), TpRegPrev));
            element.Add(new XElement(ns + nameof(CadIni), CadIni));
            element.Add(InfoRegimeTrab?.GetXmlElements(ns));
            element.Add(InfoContrato?.GetXmlElements(ns));
            element.Add(SucessaoVinc?.GetXmlElements(ns));
            element.Add(TransfDom?.GetXmlElements(ns));
            element.Add(MudancaCPF?.GetXmlElements(ns));
            element.Add(Afastamento?.GetXmlElements(ns));
            element.Add(Desligamento?.GetXmlElements(ns));
            element.Add(Cessao?.GetXmlElements(ns));
            return element;

        }
    }
}
