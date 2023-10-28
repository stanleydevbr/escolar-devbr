using DevBr.Core.eSocial.Events.Bases;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public class InfoComplementares : EntityType<InfoComplementares>, IDisposable
    {
        protected List<SituacaoPj> Situacoes { get; set; } = new List<SituacaoPj>();

        public void AddSituacao(int processo)
        {
            Situacoes.Add(new SituacaoPj { IndSitPJ = processo });
        }

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
            if (Situacoes == null && Situacoes?.Count > 0)
                return null;
            var complment = new XElement(ns + nameof(InfoComplementares));
            var elements = new XElement(ns + nameof(SituacaoPj));
            foreach (var element in Situacoes)
                elements.Add(element.GetXmlElements(ns));
            complment.Add(elements);
            return complment;
        }

    }
}
