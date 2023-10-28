using DevBr.Core.eSocial.Eventos.Beneficios.S2410;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2416
{
    public class IdeBeneficio : EntityType<IdeBeneficio>, IDisposable
    {
        public string? CpfBenef { get; set; }
        public string? NrBeneficio { get; set; }
        public InfoBenAlteracao? InfoBenAlteracao { get; set; }
        public InfoBenTermino? InfoBenTermino { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeBeneficio));
            element.Add(new XElement(ns + nameof(CpfBenef), CpfBenef));
            element.Add(new XElement(ns + nameof(NrBeneficio), NrBeneficio));
            element.Add(InfoBenAlteracao?.GetXmlElements(ns));
            if (InfoBenTermino != null)
                element.Add(InfoBenTermino.GetXmlElements(ns));

            return element;

        }
    }
}
