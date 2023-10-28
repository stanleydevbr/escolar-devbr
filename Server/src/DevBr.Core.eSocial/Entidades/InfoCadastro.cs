using DevBr.Core.eSocial.Events.Bases;
using FluentValidation;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class InfoCadastro : EntityType<InfoCadastro>, IDisposable
    {
        public string? NmRazao { get; set; }
        public int ClassTrib { get; set; }
        public int NatJurid { get; set; }
        public int IndCoop { get; set; }
        public int IndConstr { get; set; }
        public int IndDesFolha { get; set; }
        public int IndOptRegEletron { get; set; }
        public string? MultTabRubricas { get; set; }
        public string? IndEntEd { get; set; }
        public string? IndEtt { get; set; }
        public Contato? Contato { get; set; }
        public SoftwareHouse? SoftwareHouse { get; set; }
        public InfoComplementares? InfoComplements { get; set; } = new InfoComplementares();

        public void AddInfoComplementar(int processo)
        {
            InfoComplements?.AddSituacao(processo);
        }

        public void Dispose()
        {
            Contato?.Dispose();
            SoftwareHouse?.Dispose();
            InfoComplements?.Dispose();
            GC.SuppressFinalize(this);
        }

        public override bool EhValido()
        {
            RuleFor(x => x.NmRazao)
                .NotNull()
                .WithMessage($"{nameof(NmRazao)} - É necessário informar a razão social");

            RuleFor(x => x.ClassTrib)
                .NotNull()
                .WithMessage($"{nameof(ClassTrib)} - É necessário informar a classificação tributária");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        internal override XElement? GetXmlElements(XNamespace ns)
        {
            XElement element = new XElement(ns + nameof(InfoCadastro));
            element.SetElementValue(ns + nameof(NmRazao), NmRazao);
            element.SetElementValue(ns + nameof(ClassTrib), ClassTrib);
            element.SetElementValue(ns + nameof(NatJurid), NatJurid);
            element.SetElementValue(ns + nameof(IndCoop), IndCoop);
            element.SetElementValue(ns + nameof(IndConstr), IndConstr);
            element.SetElementValue(ns + nameof(IndDesFolha), IndDesFolha);
            element.SetElementValue(ns + nameof(IndOptRegEletron), IndOptRegEletron);
            element.SetElementValue(ns + nameof(MultTabRubricas), MultTabRubricas);
            element.SetElementValue(ns + nameof(IndEntEd), IndEntEd);
            element.SetElementValue(ns + nameof(IndEtt), IndEtt);
            element.Add(Contato?.GetXmlElements(ns));
            element.Add(SoftwareHouse?.GetXmlElements(ns));
            element.Add(InfoComplements?.GetXmlElements(ns));

            return element;

        }

    }
}
