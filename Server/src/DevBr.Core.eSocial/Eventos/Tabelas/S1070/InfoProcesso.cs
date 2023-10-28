using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1070
{
    public class InfoProcesso : EntityType<InfoProcesso>, IDisposable
    {
        public InclusaoProcesso? Inclusao { get; set; }
        public AlteracaoProcesso? Alteracao { get; set; }
        public ExclusaoProcesso? Exclusao { get; set; }

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
            XElement element = new XElement(ns + nameof(InfoProcesso));
            element.Add(Inclusao?.GetXmlElements(ns));
            return element;

        }
    }
}
