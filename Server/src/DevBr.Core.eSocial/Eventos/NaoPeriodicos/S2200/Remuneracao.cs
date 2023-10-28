using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Remuneracao : EntityType<Remuneracao>, IDisposable
    {
        public double? VrSalFx { get; set; }
        public uint? UndSalFixo { get; set; }
        public string? DscSalVar { get; set; }
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

            XElement element = new XElement(ns + nameof(Remuneracao));
            element.Add(new XElement(ns + nameof(VrSalFx), VrSalFx));
            element.Add(new XElement(ns + nameof(UndSalFixo), UndSalFixo));
            element.Add(new XElement(ns + nameof(DscSalVar), DscSalVar));
            return element;

        }
    }
}
