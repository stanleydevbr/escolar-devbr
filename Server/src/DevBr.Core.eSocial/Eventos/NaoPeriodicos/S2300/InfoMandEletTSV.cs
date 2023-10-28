using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class InfoMandEletTSV : EntityType<InfoMandEletTSV>, IDisposable
    {
        public uint? CategOrig { get; set; }
        public string? CnpjOrig { get; set; }
        public string? MatricOrig { get; set; }
        public DateTime? DtExercOrig { get; set; }
        public char? IndRemunCargo { get; set; }
        public uint? TpRegTrab { get; set; }
        public uint? TpRegPrev { get; set; }
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
            XElement element = new XElement(ns + "InfoMandElet");
            element.Add(new XElement(ns + nameof(CategOrig), CategOrig));
            element.Add(new XElement(ns + nameof(CnpjOrig), CnpjOrig));
            element.Add(new XElement(ns + nameof(MatricOrig), MatricOrig));
            element.Add(new XElement(ns + nameof(DtExercOrig), DtExercOrig?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(IndRemunCargo), IndRemunCargo));
            element.Add(new XElement(ns + nameof(TpRegTrab), TpRegTrab));
            element.Add(new XElement(ns + nameof(TpRegPrev), TpRegPrev));
            return element;

        }
    }
}
