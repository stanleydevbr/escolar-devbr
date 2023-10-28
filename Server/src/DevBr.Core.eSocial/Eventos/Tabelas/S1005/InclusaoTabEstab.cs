using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InclusaoTabEstab : EntityType<InclusaoTabEstab>, IDisposable
    {
        public IdeEstab? IdeEstab { get; set; }
        public DadosEstab? DadosEstab { get; set; }

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
            var evento = new XElement(ns + "Inclusao");
            evento.Add(IdeEstab?.GetXmlElements(ns));
            evento.Add(DadosEstab?.GetXmlElements(ns));
            return evento;

        }
    }
}
