namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoProcesso : TipoBase<TipoProcesso>
    {
        public static TipoProcesso Administrativo = new TipoProcesso(1, "Administrativo");
        public static TipoProcesso Judicial = new TipoProcesso(2, "Judicial");
        public static TipoProcesso Fap = new TipoProcesso(4, "Processo FAP");
        public TipoProcesso(uint codigo, string descricao) : base(codigo, descricao) { }
        protected static List<TipoProcesso> Valores()
        {
            var values = new List<TipoProcesso>();
            values.Add(Administrativo);
            values.Add(Judicial);
            values.Add(Fap);
            return values;

        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoProcesso ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));
    }
}
