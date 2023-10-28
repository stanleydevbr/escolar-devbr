namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoContribuicao : TipoBase<TipoContribuicao>
    {
        public static TipoContribuicao Substituida = new TipoContribuicao(1, "Contribuição substituida");
        public static TipoContribuicao NaoSubstituida = new TipoContribuicao(2, "Contribuição não substituida");
        public TipoContribuicao(uint codigo, string descricao) : base(codigo, descricao) { }
        protected static List<TipoContribuicao> Valores()
        {
            var values = new List<TipoContribuicao>();
            values.Add(Substituida);
            values.Add(NaoSubstituida);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoContribuicao ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));

    }
}
