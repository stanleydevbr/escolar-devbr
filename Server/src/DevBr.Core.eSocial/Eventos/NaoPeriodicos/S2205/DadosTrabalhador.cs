using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200;
using DevBr.Core.eSocial.Events;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2205
{
    public class DadosTrabalhador : EntityType<DadosTrabalhador>, IDisposable
    {
        public string? NmTrab { get; set; }
        public char? Sexo { get; set; }
        public uint? RacaCor { get; set; }
        public uint? EstCiv { get; set; }
        public uint? GrauInstr { get; set; }
        public string? NmSoc { get; set; }
        public string? PaisNac { get; set; }
        public Endereco? Endereco { get; set; }
        public TrabImig? TrabImig { get; set; }
        public InfoDeficiencia? InfoDeficiencia { get; set; }
        public List<Dependente>? Dependentes { get; set; }
        public Contato? Contato { get; set; }
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

            XElement element = new XElement(ns + nameof(DadosTrabalhador));
            element.Add(new XElement(ns + nameof(NmTrab), NmTrab));
            element.Add(new XElement(ns + nameof(Sexo), Sexo));
            element.Add(new XElement(ns + nameof(RacaCor), RacaCor));
            element.Add(new XElement(ns + nameof(EstCiv), EstCiv));
            element.Add(new XElement(ns + nameof(GrauInstr), GrauInstr));
            element.Add(new XElement(ns + nameof(NmSoc), NmSoc));
            element.Add(new XElement(ns + nameof(PaisNac), PaisNac));
            element.Add(Endereco?.GetXmlElements(ns));
            element.Add(TrabImig?.GetXmlElements(ns));
            element.Add(InfoDeficiencia?.GetXmlElements(ns));
            Dependentes?.ForEach(dep => element.Add(dep.GetXmlElements(ns)));
            element.Add(Contato?.GetXmlElements(ns));

            return element;

        }
    }
}
