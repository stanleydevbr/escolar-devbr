using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2230
{
    public class InfoCessao : EntityType<InfoCessao>, IDisposable
    {
        public string? CnpjCess { get; set; }
        public uint? InfOnus { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoCessao));
            element.Add(new XElement(ns + nameof(CnpjCess), CnpjCess));
            element.Add(new XElement(ns + nameof(InfOnus), InfOnus));
            return element;

        }
    }
}
