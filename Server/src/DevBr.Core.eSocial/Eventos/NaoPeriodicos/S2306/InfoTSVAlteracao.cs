using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2306
{
    public class InfoTSVAlteracao : EntityType<InfoTSVAlteracao>, IDisposable
    {
        public DateTime? DtAlteracao { get; set; }
        public uint? NatAtividade { get; set; }
        public InfoComplTSVAlteracao? InfoComplementares { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoTSVAlteracao));
            element.Add(InfoComplementares?.GetXmlElements(ns));
            return element;

        }
    }
}
