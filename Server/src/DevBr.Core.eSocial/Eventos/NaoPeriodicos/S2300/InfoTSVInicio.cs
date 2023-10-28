using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2300
{
    public class InfoTSVInicio : EntityType<InfoTSVInicio>, IDisposable
    {
        public char? CadIni { get; set; }
        public string? Matricula { get; set; }
        public uint? CodCateg { get; set; }
        public DateTime? DtInicio { get; set; }
        public string? NrProcTrab { get; set; }
        public uint? NatAtividade { get; set; }
        public InfoComplTSVInicio? InfoComplementares { get; set; }
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

            XElement element = new XElement(ns + nameof(InfoTSVInicio));
            element.Add(new XElement(ns + nameof(CadIni), CadIni));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            element.Add(new XElement(ns + nameof(CodCateg), CodCateg));
            element.Add(new XElement(ns + nameof(DtInicio), DtInicio));
            element.Add(new XElement(ns + nameof(NrProcTrab), NrProcTrab));
            element.Add(new XElement(ns + nameof(NatAtividade), NatAtividade));
            return element;

        }
    }
}
