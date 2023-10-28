using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class InfoTrabCedido : EntityType<InfoTrabCedido>, IDisposable
    {
        public uint? CategOrig { get; set; }
        public string? CnpjCednt { get; set; }
        public string? MatricCed { get; set; }
        public DateTime? DtAdmCed { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoTrabCedido));
            element.Add(new XElement(ns + nameof(CategOrig), CategOrig));
            element.Add(new XElement(ns + nameof(CnpjCednt), CnpjCednt));
            element.Add(new XElement(ns + nameof(MatricCed), MatricCed));
            element.Add(new XElement(ns + nameof(DtAdmCed), DtAdmCed));
            element.Add(new XElement(ns + nameof(TpRegTrab), TpRegTrab));
            element.Add(new XElement(ns + nameof(TpRegPrev), TpRegPrev));
            return element;

        }
    }
}
