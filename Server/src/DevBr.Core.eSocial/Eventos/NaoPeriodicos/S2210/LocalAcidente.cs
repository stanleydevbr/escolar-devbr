using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2210
{
    public class LocalAcidente : EntityType<LocalAcidente>, IDisposable
    {
        public uint? TpLocal { get; set; }
        public string? DscLocal { get; set; }
        public string? TpLograd { get; set; }
        public string? DscLograd { get; set; }
        public string? NrLograd { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cep { get; set; }
        public string? CodMunic { get; set; }
        public string? Uf { get; set; }
        public string? Pais { get; set; }
        public string? CodPostal { get; set; }
        public IdeLocalAcid? IdeLocalAcid { get; set; }
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
            XElement element = new XElement(ns + nameof(LocalAcidente));
            element.Add(new XElement(ns + nameof(TpLocal), TpLocal));
            element.Add(new XElement(ns + nameof(DscLocal), DscLocal));
            element.Add(new XElement(ns + nameof(TpLograd), TpLograd));
            element.Add(new XElement(ns + nameof(DscLograd), DscLograd));
            element.Add(new XElement(ns + nameof(NrLograd), NrLograd));
            element.Add(new XElement(ns + nameof(Complemento), Complemento));
            element.Add(new XElement(ns + nameof(Bairro), Bairro));
            element.Add(new XElement(ns + nameof(Cep), Cep));
            element.Add(new XElement(ns + nameof(CodMunic), CodMunic));
            element.Add(new XElement(ns + nameof(Uf), Uf));
            element.Add(new XElement(ns + nameof(Pais), Pais));
            element.Add(new XElement(ns + nameof(CodPostal), CodPostal));
            return element;

        }
    }
}

