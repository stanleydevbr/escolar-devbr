namespace DevBr.Core.eSocial.Enumeradores
{
    public class NaturezaAtividade : TipoBase<NaturezaAtividade>
    {
        public static NaturezaAtividade TrabalhoUrbano = new NaturezaAtividade(1, "Trabalho urbano");
        public static NaturezaAtividade TrabalhoRural = new NaturezaAtividade(2, "Trabalho rural");
        public NaturezaAtividade(uint codigo, string descricao) : base(codigo, descricao)
        {
        }

        protected static List<NaturezaAtividade> Valores()
        {
            var values = new List<NaturezaAtividade>();
            values.Add(TrabalhoUrbano);
            values.Add(TrabalhoRural);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static NaturezaAtividade ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));


    }
}
