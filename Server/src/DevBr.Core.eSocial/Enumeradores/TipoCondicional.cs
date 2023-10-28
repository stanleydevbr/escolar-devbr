namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoCondicional : TipoBase<TipoCondicional, char>
    {
        public static TipoCondicional Sim = new TipoCondicional('S', "Sim");
        public static TipoCondicional Nao = new TipoCondicional('N', "Não");
        public TipoCondicional(char codigo, string descricao) : base(codigo, descricao)
        {
        }

        protected static List<TipoCondicional> Valores()
        {
            var values = new List<TipoCondicional>();
            values.Add(Sim);
            values.Add(Nao);
            return values;
        }
        public static char[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoCondicional ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));


    }
}
