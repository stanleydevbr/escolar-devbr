using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2230
{
    public class InfoRetif : EntityType<InfoRetif>, IDisposable
    {
        public uint? OrigRetif { get; set; }
        public uint? TpProc { get; set; }
        public string? NrProc { get; set; }
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
            XElement element = new XElement(ns + nameof(InfoRetif));
            element.Add(new XElement(ns + nameof(OrigRetif), OrigRetif));
            element.Add(new XElement(ns + nameof(TpProc), TpProc));
            element.Add(new XElement(ns + nameof(NrProc), NrProc));
            return element;

        }
    }
}
