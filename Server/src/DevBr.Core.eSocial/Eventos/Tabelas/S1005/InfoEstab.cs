using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InfoEstab : EntityType<InfoEstab>, IDisposable
    {
        public InclusaoTabEstab? Inclusao { get; set; }
        public AlteracaoTabEstab? Alteracao { get; set; }
        public ExclusaoTabEstab? Exclusao { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            ValidationResult = Validate(this);
            if (!Inclusao.ValidationResult.IsValid)
                ValidationResult.Errors.AddRange(Inclusao.ValidationResult.Errors);

            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            var evento = new XElement(ns + nameof(InfoEstab));
            evento.Add(Inclusao?.GetXmlElements(ns));
            return evento;
        }
    }
}
