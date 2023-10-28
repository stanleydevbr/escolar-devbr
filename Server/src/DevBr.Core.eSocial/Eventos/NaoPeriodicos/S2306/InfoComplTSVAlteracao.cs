using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200;
using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2306
{
    public class InfoComplTSVAlteracao : EntityType<InfoComplTSVAlteracao>, IDisposable
    {
        public CargoFuncao? CargoFuncao { get; set; }
        public Remuneracao? Remuneracao { get; set; }
        public InfoDirigSindical? InfoDirigenteSindical { get; set; }
        public InfoTrabCedidoAlt? InfoTrabCedido { get; set; }
        public InfoMandEletAlt? InfoMandElet { get; set; }
        public InfoEstagiario? InfoEstagiario { get; set; }

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

            XElement element = new XElement(ns + nameof(InfoComplTSVAlteracao));
            element.Add(CargoFuncao?.GetXmlElements(ns));
            element.Add(Remuneracao?.GetXmlElements(ns));
            element.Add(InfoDirigenteSindical?.GetXmlElements(ns));
            element.Add(InfoTrabCedido?.GetXmlElements(ns));
            element.Add(InfoMandElet?.GetXmlElements(ns));
            element.Add(InfoEstagiario?.GetXmlElements(ns));
            return element;

        }
    }
}
