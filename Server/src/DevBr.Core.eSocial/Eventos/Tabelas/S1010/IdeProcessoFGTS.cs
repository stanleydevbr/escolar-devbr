using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1010
{
    public class IdeProcessoFGTS : EntityType<IdeProcessoFGTS>, IDisposable
    {
        public string? NrProc { get; set; }
        public ulong? CodSusp { get; set; }

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
            XElement element = new XElement(ns + nameof(IdeProcessoFGTS));
            element.Add(new XElement(ns + nameof(NrProc), NrProc));
            element.Add(new XElement(ns + nameof(CodSusp), CodSusp));
            return element;
        }
    }
}
