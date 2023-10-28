using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1070
{
    public class DadosProcJud : EntityType<DadosProcJud>, IDisposable
    {
        public string? UfVara { get; set; }
        public uint? CodMunic { get; set; }
        public ulong? IdVara { get; set; }
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

            XElement element = new XElement(ns + nameof(DadosProcJud));
            element.Add(new XElement(ns + nameof(UfVara), UfVara));
            element.Add(new XElement(ns + nameof(CodMunic), CodMunic));
            element.Add(new XElement(ns + nameof(IdVara), IdVara));
            return element;

        }
    }
}
