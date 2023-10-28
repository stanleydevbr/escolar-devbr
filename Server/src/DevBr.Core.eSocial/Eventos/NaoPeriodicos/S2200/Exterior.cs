using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Exterior : EntityType<Exterior>, IDisposable
    {
        public string? PaisResid { get; set; }
        public string? DscLograd { get; set; }
        public string? NrLograd { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? NmCid { get; set; }
        public string? CodPostal { get; set; }
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

            XElement element = new XElement(ns + nameof(Exterior));
            element.Add(new XElement(ns + nameof(PaisResid), PaisResid));
            element.Add(new XElement(ns + nameof(DscLograd), DscLograd));
            element.Add(new XElement(ns + nameof(NrLograd), NrLograd));
            element.Add(new XElement(ns + nameof(Complemento), Complemento));
            element.Add(new XElement(ns + nameof(Bairro), Bairro));
            element.Add(new XElement(ns + nameof(NmCid), NmCid));
            element.Add(new XElement(ns + nameof(CodPostal), CodPostal));
            return element;

        }
    }
}
