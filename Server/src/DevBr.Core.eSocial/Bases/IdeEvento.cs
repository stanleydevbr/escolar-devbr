using FluentValidation;
using FluentValidation.Results;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Events
{
    public abstract class IdeEvento<T> : AbstractValidator<T> where T : IdeEvento<T>
    {
        protected readonly X509Certificate2 certificate;
        protected virtual string? Id { get; set; }
        public byte? IndRetif { get; set; }
        protected string? NrRecibo { get; set; }
        public string? NrRecArqBase { get; set; }
        protected uint? IndApuracao { get; set; }
        public DateTime? PerApur { get; set; }
        protected uint? IndGuia { get; set; }
        protected uint? TpAmb { get; set; }
        protected uint? ProcEmi { get; set; }
        protected uint? VerProc { get; set; }
        protected XNamespace ns { get; set; }

        protected IdeEvento(string evento, string version)
        {
            ns = XNamespace.Get(@$"http://www.esocial.gov.br/schema/evt/{evento}/v{version}");
            ValidationResult = new ValidationResult();
        }
        protected IdeEvento(uint tpAmb, uint procEmi, uint verProc, string evento, string version)
        {
            TpAmb = tpAmb;
            ProcEmi = procEmi;
            VerProc = verProc;
            ns = XNamespace.Get(@$"http://www.esocial.gov.br/schema/evt/{evento}/v{version}");
            ValidationResult = new ValidationResult();
        }
        protected IdeEvento(byte? indRetif, string? nrRecibo, string? nrRecArqBase, uint? indApuracao, DateTime? perApur, uint? indGuia, uint? tpAmb, uint? procEmi, uint? verProc, string evento, string version)
        {
            IndRetif = indRetif;
            NrRecibo = nrRecibo;
            NrRecArqBase = nrRecArqBase;
            IndApuracao = indApuracao;
            PerApur = perApur;
            IndGuia = indGuia;
            TpAmb = tpAmb;
            ProcEmi = procEmi;
            VerProc = verProc;
            ns = XNamespace.Get(@$"http://www.esocial.gov.br/schema/evt/{evento}/v{version}");
            ValidationResult = new ValidationResult();

        }

        public virtual string GerarNovoId(string tipoInsc, string nrInsc)
        {
            if (!string.IsNullOrEmpty(Id)) return Id;

            var data = DateTime.Now;
            var random = RandomNumberGenerator.Create();
            byte[] aleatorio = new byte[5];
            random.GetBytes(aleatorio);
            var complementId = string.Join('.', aleatorio.Select(x => x)).Replace(".", "").Substring(0, 5);

            var id = $"ID" +
                $"{tipoInsc}" +
                $"{nrInsc.PadRight(14, '0')}" +
                $"{data.ToString("yyyy")}" +
                $"{data.ToString("MM")}" +
                $"{data.ToString("dd")}" +
                $"{data.ToString("HH")}" +
                $"{data.ToString("mm")}" +
                $"{data.ToString("ss")}" +
                $"{complementId?.PadLeft(6, '0')}";
            return id.Substring(0, 36);
        }
        public abstract bool EhValido();
        protected abstract XElement? GetXmlElements(XNamespace ns);
        public ValidationResult ValidationResult { get; protected set; }
        protected XElement GetXmlEvento(XNamespace ns)
        {
            var evento = new XElement(ns + "IdeEvento");
            if (IndRetif != null)
                evento.Add(new XElement(ns + nameof(IndRetif), IndRetif));
            if (!string.IsNullOrEmpty(NrRecibo))
                evento.Add(new XElement(ns + nameof(NrRecibo), NrRecibo));
            if (!string.IsNullOrEmpty(NrRecArqBase))
                evento.Add(new XElement(ns + nameof(NrRecArqBase), NrRecArqBase));
            if (IndApuracao != null)
            {
                evento.Add(new XElement(ns + nameof(IndApuracao), IndApuracao));
                if (IndApuracao == 1)
                    evento.Add(new XElement(ns + nameof(PerApur), PerApur?.ToString("yyyy-MM")));
                else
                    evento.Add(new XElement(ns + nameof(PerApur), PerApur?.ToString("yyyy")));
            }
            evento.Add(new XElement(ns + nameof(TpAmb), TpAmb));
            evento.Add(new XElement(ns + nameof(ProcEmi), ProcEmi));
            evento.Add(new XElement(ns + nameof(VerProc), VerProc));
            return evento;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as IdeEvento<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }
        public static bool operator ==(IdeEvento<T> a, IdeEvento<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(IdeEvento<T> a, IdeEvento<T> b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }
    }
}
