namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoInscricao : TipoBase<TipoInscricao>
    {
        public static TipoInscricao CNPJ = new TipoInscricao(1, "CNPJ");
        public static TipoInscricao CPF = new TipoInscricao(2, "CPF");
        public static TipoInscricao CAEPF = new TipoInscricao(3, "CEPF");
        public static TipoInscricao CNO = new TipoInscricao(4, "CNO");

        public TipoInscricao(uint codigo, string descricao) : base(codigo, descricao) { }
        protected static List<TipoInscricao> Valores()
        {
            var values = new List<TipoInscricao>();
            values.Add(CNPJ);
            values.Add(CPF);
            values.Add(CAEPF);
            values.Add(CNO);
            return values;

        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoInscricao ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));
    }
}
