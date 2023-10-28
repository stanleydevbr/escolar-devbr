using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Duracao : EntityType<Duracao>, IDisposable
    {
        public uint? TpContr { get; set; }
        public DateTime? DtTerm { get; set; }
        public char? ClauAssec { get; set; }
        public string? ObjDet { get; set; }

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

            XElement element = new XElement(ns + nameof(Duracao));
            element.Add(new XElement(ns + nameof(TpContr), TpContr));
            element.Add(new XElement(ns + nameof(DtTerm), DtTerm));
            element.Add(new XElement(ns + nameof(ClauAssec), ClauAssec));
            element.Add(new XElement(ns + nameof(ObjDet), ObjDet));
            return element;

        }
    }
}
