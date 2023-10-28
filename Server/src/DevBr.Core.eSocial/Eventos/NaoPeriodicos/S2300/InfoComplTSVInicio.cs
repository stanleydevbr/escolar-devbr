using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class InfoComplTSVInicio : EntityType<InfoComplTSVInicio>, IDisposable
    {
        public CargoFuncao? CargoFuncao { get; set; }
        public Remuneracao? Remuneracao { get; set; }
        public FGTS? FGTS { get; set; }
        public InfoDirigenteSindical? InfoDirigenteSindical { get; set; }
        public InfoTrabCedido? InfoTrabCedido { get; set; }
        public InfoMandEletTSV? InfoMandElet { get; set; }
        public InfoEstagiario? InfoEstagiario { get; set; }
        public MudancaCPF? MudancaCPF { get; set; }
        public Afastamento? Afastamento { get; set; }
        public TerminoVinculo? Termino { get; set; }
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
            XElement element = new XElement(ns + "InfoComplementares");
            element.Add(CargoFuncao?.GetXmlElements(ns));
            element.Add(Remuneracao?.GetXmlElements(ns));
            element.Add(FGTS?.GetXmlElements(ns));
            element.Add(InfoDirigenteSindical?.GetXmlElements(ns));
            element.Add(InfoTrabCedido?.GetXmlElements(ns));
            element.Add(InfoMandElet?.GetXmlElements(ns));
            element.Add(InfoEstagiario?.GetXmlElements(ns));
            element.Add(MudancaCPF?.GetXmlElements(ns));
            element.Add(Afastamento?.GetXmlElements(ns));
            element.Add(Termino?.GetXmlElements(ns));
            return element;

        }
    }
}
