using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2210
{
    public class ParteAtingida : EntityType<ParteAtingida>, IDisposable
    {
        public ulong? CodParteAting { get; set; }
        public uint? Lateralidade { get; set; }
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
            XElement element = new XElement(ns + nameof(ParteAtingida));
            element.Add(new XElement(ns + nameof(CodParteAting), CodParteAting));
            element.Add(new XElement(ns + nameof(Lateralidade), Lateralidade));
            return element;
        }
    }
}

