using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class Trabalhador : EntityType<Trabalhador>, IDisposable
    {
        public string? CpfTrab { get; set; }
        public string? NmTrab { get; set; }
        public char? Sexo { get; set; }
        public uint? RacaCor { get; set; }
        public uint? EstCiv { get; set; }
        public string? GrauInstr { get; set; }
        public string? NmSoc { get; set; }
        public Nascimento? Nascimento { get; set; }
        public Endereco? Endereco { get; set; }
        public TrabImig? TrabImig { get; set; }
        public InfoDeficiencia? InfoDeficiencia { get; set; }
        public List<Dependente>? Dependentes { get; set; }
        public ContatoTrabalhador? Contato { get; set; }

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
            XElement element = new XElement(ns + nameof(Trabalhador));
            element.Add(new XElement(ns + nameof(CpfTrab), CpfTrab));
            element.Add(new XElement(ns + nameof(NmTrab), NmTrab));
            element.Add(new XElement(ns + nameof(Sexo), Sexo));
            element.Add(new XElement(ns + nameof(RacaCor), RacaCor));
            element.Add(new XElement(ns + nameof(EstCiv), EstCiv));
            element.Add(new XElement(ns + nameof(GrauInstr), GrauInstr));
            element.Add(new XElement(ns + nameof(NmSoc), NmSoc));
            element.Add(Nascimento?.GetXmlElements(ns));
            element.Add(Endereco?.GetXmlElements(ns));
            element.Add(TrabImig?.GetXmlElements(ns));
            element.Add(InfoDeficiencia?.GetXmlElements(ns));
            Dependentes?.ForEach(dep => element.Add(dep.GetXmlElements(ns)));
            element.Add(Contato?.GetXmlElements(ns));
            return element;
        }
    }
}
