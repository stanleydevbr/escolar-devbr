using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class TrabImig : EntityType<TrabImig>, IDisposable
    {
        public uint? TmpResid { get; set; }
        public uint? CondIng { get; set; }
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
            XElement element = new XElement(ns + nameof(TrabImig));
            element.Add(new XElement(ns + nameof(TmpResid), TmpResid));
            element.Add(new XElement(ns + nameof(CondIng), CondIng));
            return element;

        }
    }
}
