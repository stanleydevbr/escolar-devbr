using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class Contato : EntityType<Contato>, IDisposable
    {
        public string? NmCtt { get; set; }
        public string? CpfCtt { get; set; }
        public string? FoneFixo { get; set; }
        public string? Email { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
        internal override XElement? GetXmlElements(XNamespace ns)
        {
            XElement element = new XElement(ns + nameof(Contato));
            element.Add(new XElement(ns + nameof(NmCtt), NmCtt));
            element.Add(new XElement(ns + nameof(CpfCtt), CpfCtt));
            element.Add(new XElement(ns + nameof(FoneFixo), FoneFixo));
            element.Add(new XElement(ns + nameof(Email), Email));
            return element;
        }
    }
}
