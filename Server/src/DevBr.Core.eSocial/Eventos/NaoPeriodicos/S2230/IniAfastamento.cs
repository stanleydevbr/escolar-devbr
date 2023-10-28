using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2230
{
    public class IniAfastamento : EntityType<IniAfastamento>, IDisposable
    {
        public DateTime? DtIniAfast { get; set; }
        public string? CodMotAfast { get; set; }
        public char? InfoMesmoMtv { get; set; }
        public uint? TpAcidTransito { get; set; }
        public string? Observacao { get; set; }
        public PerQuis? PerQuis { get; set; }
        public InfoCessao? InfoCessao { get; set; }
        public InfoMandElet? InfoMandElet { get; set; }
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

            XElement element = new XElement(ns + nameof(IniAfastamento));
            element.Add(new XElement(ns + nameof(DtIniAfast), DtIniAfast?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(CodMotAfast), CodMotAfast));
            element.Add(new XElement(ns + nameof(InfoMesmoMtv), InfoMesmoMtv));
            element.Add(new XElement(ns + nameof(TpAcidTransito), TpAcidTransito));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            element.Add(PerQuis?.GetXmlElements(ns));
            element.Add(InfoCessao?.GetXmlElements(ns));
            element.Add(InfoMandElet?.GetXmlElements(ns));
            return element;

        }
    }
}
