using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class InfoCeletista : EntityType<InfoCeletista>, IDisposable
    {
        public DateTime? DtAdm { get; set; }
        public byte? TpAdmissao { get; set; }
        public byte? IndAdmissao { get; set; }
        public string? NrProcTrab { get; set; }
        public byte? TpRegJor { get; set; }
        public byte? NatAtividade { get; set; }
        public uint? DtBase { get; set; }
        public string? CnpjSindCategProf { get; set; }
        public FGTS? FGTS { get; set; }
        public TrabTemporario? TrabTemporario { get; set; }
        public Aprend? Aprend { get; set; }

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

            XElement element = new XElement(ns + nameof(InfoCeletista));
            element.Add(new XElement(ns + nameof(DtAdm), DtAdm?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(TpAdmissao), TpAdmissao));
            element.Add(new XElement(ns + nameof(IndAdmissao), IndAdmissao));
            element.Add(new XElement(ns + nameof(NrProcTrab), NrProcTrab));
            element.Add(new XElement(ns + nameof(TpRegJor), TpRegJor));
            element.Add(new XElement(ns + nameof(NatAtividade), NatAtividade));
            element.Add(new XElement(ns + nameof(DtBase), DtBase));
            element.Add(new XElement(ns + nameof(CnpjSindCategProf), CnpjSindCategProf));
            element.Add(FGTS?.GetXmlElements(ns));
            element.Add(TrabTemporario?.GetXmlElements(ns));
            element.Add(Aprend?.GetXmlElements(ns));
            return element;

        }
    }
}
