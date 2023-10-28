using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InfoPcd : EntityType<InfoPcd>, IDisposable
    {
        public string? NrProcJud { get; set; }
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
            var element = new XElement(ns + nameof(InfoPcd));
            element.Add(new XElement(ns + nameof(NrProcJud), NrProcJud));
            return element;
        }
    }
}
