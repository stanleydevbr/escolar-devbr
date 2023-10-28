using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class InfoDirigenteSindical : EntityType<InfoDirigenteSindical>, IDisposable
    {
        public uint? CategOrig { get; set; }
        public uint TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public DateTime? DtAdmOrig { get; set; }
        public string? MatricOrig { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoDirigenteSindical));
            element.Add(new XElement(ns + nameof(CategOrig), CategOrig));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(new XElement(ns + nameof(DtAdmOrig), DtAdmOrig));
            element.Add(new XElement(ns + nameof(MatricOrig), MatricOrig));
            element.Add(new XElement(ns + nameof(TpRegTrab), TpRegTrab));
            element.Add(new XElement(ns + nameof(TpRegPrev), TpRegPrev));
            return element;

        }
    }
}
