using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class ProcJudTrab : EntityType<ProcJudTrab>, IDisposable
    {
        public uint? TpTrib { get; set; }
        public string? NrProcJud { get; set; }
        public ulong? CodSusp { get; set; }

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

            XElement element = new XElement(ns + nameof(ProcJudTrab));
            element.Add(new XElement(ns + nameof(TpTrib), TpTrib));
            element.Add(new XElement(ns + nameof(NrProcJud), NrProcJud));
            element.Add(new XElement(ns + nameof(CodSusp), CodSusp));
            return element;

        }
    }
}
