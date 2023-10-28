using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class AlvaraJudicial : EntityType<AlvaraJudicial>, IDisposable
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
            XElement element = new XElement(ns + nameof(AlvaraJudicial));
            element.Add(new XElement(ns + nameof(NrProcJud), NrProcJud));
            return element;
        }
    }
}
