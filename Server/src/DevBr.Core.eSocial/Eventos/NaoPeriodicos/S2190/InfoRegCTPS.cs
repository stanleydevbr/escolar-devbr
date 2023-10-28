using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2190
{
    public class InfoRegCTPS : EntityType<InfoRegCTPS>, IDisposable
    {
        public string? CBOCargo { get; set; }
        public double? VrSalFx { get; set; }
        public uint? UndSalFixo { get; set; }
        public uint? TpContr { get; set; }
        public DateTime? DtTerm { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoRegCTPS));
            element.Add(new XElement(ns + nameof(CBOCargo), CBOCargo));
            element.Add(new XElement(ns + nameof(VrSalFx), VrSalFx));
            element.Add(new XElement(ns + nameof(UndSalFixo), UndSalFixo));
            element.Add(new XElement(ns + nameof(TpContr), TpContr));
            element.Add(new XElement(ns + nameof(DtTerm), DtTerm?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
