﻿using DevBr.Core.eSocial.Eventos.NaoPeriodicos.S2299;
using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Eventos.Periodicos.S1200
{
    public class RemunPerApur : EntityType<RemunPerApur>, IDisposable
    {
        public string? Matricula { get; set; }
        public uint? IndSimples { get; set; }
        public List<ItensRemun>? ItensRemun { get; set; }
        public InfoAgNocivo? InfoAgNocivo { get; set; }
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

            XElement element = new XElement(ns + nameof(RemunPerApur));
            element.Add(new XElement(ns + nameof(Matricula), Matricula));
            element.Add(new XElement(ns + nameof(IndSimples), IndSimples));
            ItensRemun?.ForEach(item => element.Add(item?.GetXmlElements(ns)));
            element.Add(InfoAgNocivo?.GetXmlElements(ns));
            return element;

        }
    }
}
