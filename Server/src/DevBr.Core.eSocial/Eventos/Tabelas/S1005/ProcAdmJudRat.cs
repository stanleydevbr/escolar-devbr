using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class ProcAdmJudRat : EntityType<ProcAdmJudRat>, IDisposable
    {
        public byte TpProc { get; set; }
        public string NrProc { get; set; }
        public long CodSusp { get; set; }

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
            var element = new XElement(ns + nameof(ProcAdmJudRat));
            element.Add(new XElement(ns + nameof(TpProc), TpProc));
            element.Add(new XElement(ns + nameof(NrProc), NrProc));
            element.Add(new XElement(ns + nameof(CodSusp), CodSusp));
            return element;
        }
    }
}
