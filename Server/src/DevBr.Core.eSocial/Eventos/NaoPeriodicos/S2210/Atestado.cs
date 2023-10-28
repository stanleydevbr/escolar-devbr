using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2210
{
    public class Atestado : EntityType<Atestado>, IDisposable
    {
        public DateTime? DtAtendimento { get; set; }
        public string? HrAtendimento { get; set; }
        public char? IndInternacao { get; set; }
        public uint? DurTrat { get; set; }
        public char? IndAfast { get; set; }
        public ulong? DscLesao { get; set; }
        public string? DscCompLesao { get; set; }
        public string? DiagProvavel { get; set; }
        public string? CodCID { get; set; }
        public Emitente? Emitente { get; set; }
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

            XElement element = new XElement(ns + nameof(Atestado));
            element.Add(new XElement(ns + nameof(DtAtendimento), DtAtendimento?.ToString("dd-MM-yyyy")));
            element.Add(new XElement(ns + nameof(HrAtendimento), HrAtendimento));
            element.Add(new XElement(ns + nameof(IndInternacao), IndInternacao));
            element.Add(new XElement(ns + nameof(DurTrat), DurTrat));
            element.Add(new XElement(ns + nameof(IndAfast), IndAfast));
            element.Add(new XElement(ns + nameof(DscLesao), DscLesao));
            element.Add(new XElement(ns + nameof(DscCompLesao), DscCompLesao));
            element.Add(new XElement(ns + nameof(DiagProvavel), DiagProvavel));
            element.Add(new XElement(ns + nameof(CodCID), CodCID));
            element.Add(Emitente?.GetXmlElements(ns));
            return element;

        }
    }
}

