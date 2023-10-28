using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Brasil : EntityType<Brasil>, IDisposable
    {
        public string? TpLograd { get; set; }
        public string? DscLograd { get; set; }
        public string? NrLograd { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cep { get; set; }
        public ulong? CodMunic { get; set; }
        public string? Uf { get; set; }

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
            XElement element = new XElement(ns + nameof(Brasil));
            element.Add(new XElement(ns + nameof(TpLograd), TpLograd));
            element.Add(new XElement(ns + nameof(DscLograd), DscLograd));
            element.Add(new XElement(ns + nameof(NrLograd), NrLograd));
            element.Add(new XElement(ns + nameof(Complemento), Complemento));
            element.Add(new XElement(ns + nameof(Bairro), Bairro));
            element.Add(new XElement(ns + nameof(Cep), Cep));
            element.Add(new XElement(ns + nameof(CodMunic), CodMunic));
            element.Add(new XElement(ns + nameof(Uf), Uf));
            return element;
        }
    }
}
