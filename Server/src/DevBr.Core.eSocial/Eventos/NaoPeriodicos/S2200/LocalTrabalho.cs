using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class LocalTrabalho : EntityType<LocalTrabalho>, IDisposable
    {
        public LocalTrabGeral? LocalTrabGeral { get; set; }
        public LocalTempDom? LocalTempDom { get; set; }
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
            XElement element = new XElement(ns + nameof(LocalTrabalho));
            element.Add(LocalTrabGeral?.GetXmlElements(ns));
            element.Add(LocalTempDom?.GetXmlElements(ns));
            return element;

        }
    }
}
