using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class InfoComplCont : EntityType<InfoComplCont>, IDisposable
    {
        public string? CodCBO { get; set; }
        public uint? NatAtividade { get; set; }
        public uint? QtdDiasTrab { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoComplCont));
            element.Add(new XElement(ns + nameof(CodCBO), CodCBO));
            element.Add(new XElement(ns + nameof(NatAtividade), NatAtividade));
            element.Add(new XElement(ns + nameof(QtdDiasTrab), QtdDiasTrab));
            return element;

        }
    }
}
