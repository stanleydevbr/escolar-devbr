using DevBr.Core.eSocial.Events.Bases;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class SoftwareHouse : EntityType<SoftwareHouse>, IDisposable
    {
        public string? CnpjSoftHouse { get; set; }
        public string? NmRazao { get; set; }
        public string? NmCont { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.CnpjSoftHouse)
                .NotEmpty()
                .WithMessage($"{nameof(CnpjSoftHouse)} - É necessário informar o número do CNPJ da Software House");

            RuleFor(x => x.NmRazao)
                .NotEmpty()
                .WithMessage($"{nameof(NmRazao)} - É necessário informar o nome da Software House");

            RuleFor(x => x.NmCont)
                .NotEmpty()
                .WithMessage($"{nameof(NmCont)} - É necessário informar o nome de contato da empresa de software");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage($"{nameof(Telefone)} - É necessário informar o número de telefone de contato da empresa de software");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage($"{nameof(Email)} - É necessário informar o endereço de e-mail da software house");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage($"{nameof(Email)} - Informe um endereço de e-mail valido");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            XElement element = new XElement(ns + nameof(SoftwareHouse));
            element.Add(new XElement(ns + nameof(CnpjSoftHouse), CnpjSoftHouse));
            element.Add(new XElement(ns + nameof(NmCont), NmCont));
            element.Add(new XElement(ns + nameof(Telefone), Telefone));
            element.Add(new XElement(ns + nameof(Email), Email));
            return element;
        }
    }
}
