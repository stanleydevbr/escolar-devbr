namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoExtensao : TipoBase<TipoExtensao>
    {
        public static TipoExtensao Patronal = new TipoExtensao(1, "Contribuição previdenciária patronal");
        public static TipoExtensao Descontada = new TipoExtensao(2, "Contribuição previdenciária + descontada dos segurados");
        public TipoExtensao(uint codigo, string descricao) : base(codigo, descricao)
        {
        }

        protected static List<TipoExtensao> Valores()
        {
            var values = new List<TipoExtensao>();
            values.Add(Patronal);
            values.Add(Descontada);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoExtensao ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));
    }
}
