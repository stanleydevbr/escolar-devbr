namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoCepf : TipoBase<TipoCepf>
    {
        public static TipoCepf ContribuinteIndividual = new TipoCepf(1, "Contribuinte Individual");
        public static TipoCepf ProdutorRural = new TipoCepf(2, "Produtor Rural");
        public static TipoCepf SeguradoEspecial = new TipoCepf(3, "Segurado Especial");
        public TipoCepf(uint codigo, string descricao) : base(codigo, descricao) { }

        protected static List<TipoCepf> Valores()
        {
            var values = new List<TipoCepf>();
            values.Add(ContribuinteIndividual);
            values.Add(ProdutorRural);
            values.Add(SeguradoEspecial);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoCepf ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));
    }
}
