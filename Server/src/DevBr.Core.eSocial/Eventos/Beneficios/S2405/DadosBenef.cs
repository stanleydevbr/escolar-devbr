using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Beneficios.S2405
{
    public class DadosBenef : EntityType<DadosBenef>, IDisposable
    {
        public string? NmBenefic { get; set; }
        public char? Sexo { get; set; }
        public uint? RacaCor { get; set; }
        public uint? EstCiv { get; set; }
        public char? IncFisMen { get; set; }
        public Endereco? Endereco { get; set; }
        public List<Dependente>? Dependentes { get; set; }
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

            XElement element = new XElement(ns + nameof(DadosBenef));
            element.Add(new XElement(ns + nameof(NmBenefic), NmBenefic));
            element.Add(new XElement(ns + nameof(Sexo), Sexo));
            element.Add(new XElement(ns + nameof(RacaCor), RacaCor));
            element.Add(new XElement(ns + nameof(EstCiv), EstCiv));
            element.Add(new XElement(ns + nameof(IncFisMen), IncFisMen));
            element.Add(Endereco?.GetXmlElements(ns));
            Dependentes?.ForEach(dep => element.Add(dep?.GetXmlElements(ns)));
            return element;

        }
    }
}
