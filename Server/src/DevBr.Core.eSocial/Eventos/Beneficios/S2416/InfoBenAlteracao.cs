using DevBr.Core.eSocial.Eventos.Beneficios.S2410;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2416
{
    public class InfoBenAlteracao : EntityType<InfoBenAlteracao>, IDisposable
    {
        public DateTime? DtAltBeneficio { get; set; }
        public DadosBeneficio? DadosBeneficio { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoBenAlteracao));
            element.Add(new XElement(ns + nameof(DtAltBeneficio), DtAltBeneficio?.ToString("dd-MM-yyyy")));
            element.Add(DadosBeneficio?.GetXmlElements(ns));
            return element;

        }
    }
}
