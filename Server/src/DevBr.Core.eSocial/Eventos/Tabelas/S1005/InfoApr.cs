using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InfoApr : EntityType<InfoApr>, IDisposable
    {
        public string? NrProcJud { get; set; }
        public List<InfoEntEduc> InfoEntEduc { get; set; }
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
            var element = new XElement(ns + nameof(InfoApr));
            element.Add(new XElement(ns + nameof(NrProcJud), NrProcJud));
            var aux = new XElement(ns + nameof(InfoEntEduc));
            foreach (var item in InfoEntEduc)
            {
                aux.Add(item.GetXmlElements(ns));
            }
            element.Add(aux);
            return element;
        }
    }
}
