using DevBr.Core.eSocial.Eventos.S1005;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1070
{
    public class AlteracaoProcesso : EntityType<AlteracaoProcesso>, IDisposable
    {
        public IdeProcesso? IdeProcesso { get; set; }
        public DadosProc? DadosProc { get; set; }
        public NovaValidade? NovaValidade { get; set; }
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

            XElement element = new XElement(ns + "Alteracao");
            element.Add(IdeProcesso?.GetXmlElements(ns));
            element.Add(DadosProc?.GetXmlElements(ns));
            element.Add(NovaValidade?.GetXmlElements(ns));
            return element;

        }
    }
}
