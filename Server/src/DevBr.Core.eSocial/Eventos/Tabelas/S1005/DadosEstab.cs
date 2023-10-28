using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class DadosEstab : EntityType<DadosEstab>, IDisposable
    {
        public long CnaePrep { get; set; }
        public string? CnpjResp { get; set; }

        public AliqGilrat? AliqGilrat { get; set; }
        public InfoCaepf? InfoCaepf { get; set; }
        public InfoObra? InfoObra { get; set; }
        public InfoTrab? InfoTrab { get; set; }

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
            var element = new XElement(ns + nameof(DadosEstab));
            element.Add(new XElement(ns + nameof(CnaePrep), CnaePrep));
            element.Add(new XElement(ns + nameof(CnpjResp), CnpjResp));
            element.Add(AliqGilrat?.GetXmlElements(ns));
            element.Add(InfoCaepf?.GetXmlElements(ns));
            element.Add(InfoObra?.GetXmlElements(ns));
            element.Add(InfoTrab?.GetXmlElements(ns));
            return element;
        }
    }
}
