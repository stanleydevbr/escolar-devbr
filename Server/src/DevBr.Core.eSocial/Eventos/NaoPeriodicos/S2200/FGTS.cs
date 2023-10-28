﻿using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2200
{
    public class FGTS : EntityType<FGTS>, IDisposable
    {
        public DateTime? DtOpcFGTS { get; set; }
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
            XElement element = new XElement(ns + nameof(FGTS));
            element.Add(new XElement(ns + nameof(DtOpcFGTS), DtOpcFGTS?.ToString("dd-MM-yyyy")));
            return element;

        }
    }
}
