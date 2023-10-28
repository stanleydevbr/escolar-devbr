using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class IdeADCRemun : EntityType<IdeADCRemun>, IDisposable
    {
        public DateTime? DtAcConv { get; set; }
        public char? TpAcConv { get; set; }
        public string? Dsc { get; set; }
        public char? RemunSuc { get; set; }
        public List<IdePeriodoRemun>? IdePeriodo { get; set; }
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

            XElement element = new XElement(ns + "IdeADC");
            element.Add(new XElement(ns + nameof(DtAcConv), DtAcConv?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(TpAcConv), TpAcConv));
            element.Add(new XElement(ns + nameof(Dsc), Dsc));
            element.Add(new XElement(ns + nameof(RemunSuc), RemunSuc));
            IdePeriodo?.ForEach(per => element.Add(per?.GetXmlElements(ns)));
            return element;

        }
    }
}
