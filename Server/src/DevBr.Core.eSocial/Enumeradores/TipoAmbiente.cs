namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoAmbiente : TipoBase<TipoAmbiente>
    {
        private static TipoAmbiente Producao = new TipoAmbiente(1, "Produção");
        private static TipoAmbiente Restrita = new TipoAmbiente(2, "Produção restrita");
        private static TipoAmbiente Interno = new TipoAmbiente(7, "Validação interna");
        private static TipoAmbiente Teste = new TipoAmbiente(8, "Teste interno");
        private static TipoAmbiente Desenvolvimento = new TipoAmbiente(9, "Desenvolvimento");
        public TipoAmbiente(uint codigo, string descricao) : base(codigo, descricao) { }
        protected static List<TipoAmbiente> Valores()
        {
            var values = new List<TipoAmbiente>();
            values.Add(Producao);
            values.Add(Restrita);
            values.Add(Interno);
            values.Add(Teste);
            values.Add(Desenvolvimento);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoAmbiente ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));

    }
}
