using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class IdeEstab : EntityType<IdeEstab>, IDisposable
    {

        public byte TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public DateTime? IniValid { get; set; }
        public DateTime? FimValid { get; set; }

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
            var evento = new XElement(ns + nameof(IdeEstab));
            evento.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            evento.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            evento.Add(new XElement(ns + nameof(IniValid), IniValid));
            evento.Add(new XElement(ns + nameof(FimValid), FimValid));
            return evento;

        }
    }
}
