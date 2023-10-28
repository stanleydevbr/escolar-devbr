using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S3000
{
    public class IdeFolhaPagto : EntityType<IdeFolhaPagto>, IDisposable
    {
        public uint? IndApuracao { get; set; }
        public DateTime? PerApur { get; set; }
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

            XElement element = new XElement(ns + nameof(IdeFolhaPagto));
            element.Add(new XElement(ns + nameof(IndApuracao), IndApuracao));
            element.Add(new XElement(ns + nameof(PerApur), PerApur?.ToString("yyyy-MM")));
            return element;

        }
    }
}
