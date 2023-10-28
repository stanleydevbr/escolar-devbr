namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoContrato : TipoBase<TipoContrato>
    {
        public static TipoContrato PrazoIndeterminado = new TipoContrato(1, "Prazo Indeterminado");
        public static TipoContrato PrazoDeterminado = new TipoContrato(2, "Prazo determinado, definido em dias");
        public static TipoContrato DeterminadoVinculado = new TipoContrato(3, "Prazo determinado, vinculado à ocorrência de um fato");
        public TipoContrato(uint codigo, string descricao) : base(codigo, descricao) { }

        protected static List<TipoContrato> Valores()
        {
            var values = new List<TipoContrato>();
            values.Add(PrazoIndeterminado);
            values.Add(PrazoDeterminado);
            values.Add(DeterminadoVinculado);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoContrato ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));

    }
}
