using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class AliqGilrat : EntityType<AliqGilrat>, IDisposable
    {
        public byte? AliqRat { get; set; }
        public decimal? Fap { get; set; }
        public ProcAdmJudRat? ProcAdmJudRat { get; set; }
        public ProcAdmJudFap? ProcAdmJudFap { get; set; }

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
            var element = new XElement(ns + nameof(AliqGilrat));
            element.Add(new XElement(ns + nameof(AliqRat), AliqRat));
            element.Add(new XElement(ns + nameof(Fap), Fap));
            element.Add(ProcAdmJudRat?.GetXmlElements(ns));
            element.Add(ProcAdmJudFap?.GetXmlElements(ns));
            return element;
        }
    }
}
