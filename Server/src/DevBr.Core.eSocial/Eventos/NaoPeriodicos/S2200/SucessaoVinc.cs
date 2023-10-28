﻿using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class SucessaoVinc : EntityType<SucessaoVinc>, IDisposable
    {
        public byte? TpInsc { get; set; }
        public string? NrInsc { get; set; }
        public string? MatricAnt { get; set; }
        public DateTime? DtTransf { get; set; }
        public string? Observacao { get; set; }
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

            XElement element = new XElement(ns + nameof(SucessaoVinc));
            element.Add(new XElement(ns + nameof(TpInsc), TpInsc));
            element.Add(new XElement(ns + nameof(NrInsc), NrInsc));
            element.Add(new XElement(ns + nameof(MatricAnt), MatricAnt));
            element.Add(new XElement(ns + nameof(DtTransf), DtTransf));
            element.Add(new XElement(ns + nameof(Observacao), Observacao));
            return element;

        }
    }
}
