using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class HorContratual : EntityType<HorContratual>, IDisposable
    {
        public double? QtdHrsSem { get; set; }
        public uint? TpJornada { get; set; }
        public uint? TmpParc { get; set; }
        public char? HorNoturno { get; set; }
        public string? DscJorn { get; set; }
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

            XElement element = new XElement(ns + nameof(HorContratual));
            element.Add(new XElement(ns + nameof(QtdHrsSem), QtdHrsSem));
            element.Add(new XElement(ns + nameof(TpJornada), TpJornada));
            element.Add(new XElement(ns + nameof(TmpParc), TmpParc));
            element.Add(new XElement(ns + nameof(HorNoturno), HorNoturno));
            element.Add(new XElement(ns + nameof(DscJorn), DscJorn));
            return element;

        }
    }
}
