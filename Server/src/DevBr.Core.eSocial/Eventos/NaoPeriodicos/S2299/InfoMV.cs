using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299
{
    public class InfoMV : EntityType<InfoMV>, IDisposable
    {
        public uint? IndMV { get; set; }
        public List<RemunOutrEmpr>? RemunOutrEmprs { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoMV));
            element.Add(new XElement(ns + nameof(IndMV), IndMV));
            RemunOutrEmprs?.ForEach(rem => element.Add(rem.GetXmlElements(ns)));
            return element;

        }
    }
}
