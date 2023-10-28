namespace DevBr.Core.eSocial.Enumeradores
{
    public sealed class TipoRubrica : TipoBase<TipoRubrica>
    {
        public static TipoRubrica Vencimento = new TipoRubrica(1, "Vencimento, provento ou pensão");
        public static TipoRubrica Desconto = new TipoRubrica(2, "Desconto");
        public static TipoRubrica Informativa = new TipoRubrica(3, "Informativa");
        public static TipoRubrica Dedutora = new TipoRubrica(4, "Informativa dedutora");
        public TipoRubrica(uint codigo, string descricao) : base(codigo, descricao) { }
        protected static List<TipoRubrica> Valores()
        {
            var values = new List<TipoRubrica>();
            values.Add(Vencimento);
            values.Add(Desconto);
            values.Add(Informativa);
            values.Add(Dedutora);
            return values;
        }

        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoRubrica ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));
    }
}
