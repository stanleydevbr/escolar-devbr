using DevBr.Core.eSocial.Events.Bases;
using DevBr.Core.Tools.Documents;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.S1005
{
    public class InfoEntEduc : EntityType<InfoEntEduc>, IDisposable
    {
        public string NrInsc { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.NrInsc)
                .NotEmpty()
                .WithMessage($"{nameof(NrInsc)} - É necessário informar o número de inscrição");
            RuleFor(x => x.NrInsc)
                .Length(14)
                .WithMessage($"{nameof(NrInsc)} - O número de inscrição deve conter 14 algarismos");
            RuleFor(x => x.NrInsc)
                .Must(x => new Cnpj(NrInsc).EhValido)
                .WithMessage($"{nameof(NrInsc)} - O número de inscrição informado está inválido");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            var element = new XElement(ns + nameof(NrInsc), NrInsc);
            return element;
        }
    }
}
