using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class CargoFuncao : EntityType<CargoFuncao>, IDisposable
    {
        public string? NmCargo { get; set; }
        public string? CBOCargo { get; set; }
        public string? NmFuncao { get; set; }
        public string? CBOFuncao { get; set; }
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
            XElement element = new XElement(ns + nameof(CargoFuncao));
            element.Add(new XElement(ns + nameof(NmCargo), NmCargo));
            element.Add(new XElement(ns + nameof(CBOCargo), CBOCargo));
            element.Add(new XElement(ns + nameof(NmFuncao), NmFuncao));
            element.Add(new XElement(ns + nameof(CBOFuncao), CBOFuncao));
            return element;

        }
    }
}
