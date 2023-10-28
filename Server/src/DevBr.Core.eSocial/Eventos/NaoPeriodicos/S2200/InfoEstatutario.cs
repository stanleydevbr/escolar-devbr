using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class InfoEstatutario : EntityType<InfoEstatutario>, IDisposable
    {
        public uint? TpProv { get; set; }
        public DateTime? DtExercicio { get; set; }
        public uint? TpPlanRP { get; set; }
        public char? IndTetoRGPS { get; set; }
        public char? IndAbonoPerm { get; set; }
        public DateTime? DtIniAbono { get; set; }


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
            XElement element = new XElement(ns + nameof(InfoEstatutario));
            element.Add(new XElement(ns + nameof(TpProv), TpProv));
            element.Add(new XElement(ns + nameof(DtExercicio), DtExercicio?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(TpPlanRP), TpPlanRP));
            element.Add(new XElement(ns + nameof(IndTetoRGPS), IndTetoRGPS));
            element.Add(new XElement(ns + nameof(IndAbonoPerm), IndAbonoPerm));
            element.Add(new XElement(ns + nameof(DtIniAbono), DtIniAbono?.ToString("dd-MM-yyyy")));
            return element;
        }
    }
}
