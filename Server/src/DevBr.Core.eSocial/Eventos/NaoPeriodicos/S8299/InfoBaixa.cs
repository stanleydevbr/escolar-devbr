using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S8299
{
    public class InfoBaixa : EntityType<InfoBaixa>, IDisposable
    {
        public string? MtvDeslig { get; set; }
        public DateTime? DtDeslig { get; set; }
        public DateTime? DtProjFimAPI { get; set; }
        public string? NrProcTrab { get; set; }
        public string? Observacao { get; set; }

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
            XElement element = new XElement(ns + nameof(InfoBaixa));
            element.Add(new XElement(ns + nameof(MtvDeslig), MtvDeslig));
            element.Add(new XElement(ns + nameof(DtDeslig), DtDeslig?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(DtProjFimAPI), DtProjFimAPI?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(NrProcTrab), NrProcTrab));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            return element;
        }
    }
}
