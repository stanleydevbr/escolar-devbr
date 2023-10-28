using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1070
{
    public class InfoSusp : EntityType<InfoSusp>, IDisposable
    {
        public ulong? CodSusp { get; set; }
        public string? IndSusp { get; set; }
        public DateTime? DtDescisao { get; set; }
        public char? IndDeposito { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoSusp));
            element.Add(new XElement(ns + nameof(CodSusp), CodSusp));
            element.Add(new XElement(ns + nameof(IndSusp), IndSusp));
            element.Add(new XElement(ns + nameof(DtDescisao), DtDescisao));
            element.Add(new XElement(ns + nameof(IndDeposito), IndDeposito));
            return element;

        }
    }
}
