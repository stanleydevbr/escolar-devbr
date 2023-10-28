using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2205
{
    public class Alteracao : EntityType<Alteracao>, IDisposable
    {
        public DateTime? DtAlteracao { get; set; }
        public DadosTrabalhador? DadosTrabalhador { get; set; }
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

            XElement element = new XElement(ns + nameof(Alteracao));
            element.Add(new XElement(ns + nameof(DtAlteracao), DtAlteracao?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
