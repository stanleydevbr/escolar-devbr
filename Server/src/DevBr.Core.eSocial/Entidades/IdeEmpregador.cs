using DevBr.Core.eSocial.Enumeradores;
using DevBr.Core.eSocial.Events.Bases;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class IdeEmpregador : EntityType<IdeEmpregador>, IDisposable
    {
        public uint? TpInsc { get; set; }
        public string? NrInsc { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.TpInsc)
                .NotNull()
                .WithMessage($"{nameof(TpInsc)} - É necessário informar o tipo de inscrição do empregador.");

            RuleFor(x => x.TpInsc)
                .Must(TpInsc => TipoInscricao.ObterTipo((uint)TpInsc) != null)
                .WithMessage("Tipo de inscrição informado é inválido");

            RuleFor(x => x.NrInsc)
                .NotEmpty()
                .WithMessage($"{nameof(NrInsc)} - É necessário informar o número de inscrição do empregador.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            XElement element = new XElement(ns + nameof(IdeEmpregador));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            return element;
        }

    }
}
