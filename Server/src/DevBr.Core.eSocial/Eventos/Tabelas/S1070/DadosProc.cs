using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1070
{
    public class DadosProc : EntityType<DadosProc>, IDisposable
    {
        public byte? IndAutoria { get; set; }
        public uint? IndMatProc { get; set; }
        public string? Observacao { get; set; }
        public DadosProcJud? DadosProcJud { get; set; }
        public List<InfoSusp>? InfoSusp { get; set; }
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

            XElement element = new XElement(ns + nameof(DadosProc));
            element.Add(new XElement(ns + nameof(IndAutoria), IndAutoria));
            element.Add(new XElement(ns + nameof(IndMatProc), IndMatProc));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            element.Add(new XElement(DadosProcJud?.GetXmlElements(ns)));
            return element;

        }
    }
}
