namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoPagamento : TipoBase<TipoPagamento>
    {
        public static TipoPagamento PorHora = new TipoPagamento(1, "Por hora");
        public static TipoPagamento PorDia = new TipoPagamento(2, "Por dia");
        public static TipoPagamento PorSemana = new TipoPagamento(3, "Por semana");
        public static TipoPagamento PorQuinzena = new TipoPagamento(4, "Por quinzena");
        public static TipoPagamento PorMes = new TipoPagamento(5, "Por mês");
        public static TipoPagamento PorTarefa = new TipoPagamento(6, "Por tarefa");
        public static TipoPagamento NaoAplicavel = new TipoPagamento(7, "Não aplicável - Salário exclusivamente variável");
        public TipoPagamento(uint codigo, string descricao) : base(codigo, descricao) { }

        protected static List<TipoPagamento> Valores()
        {
            var values = new List<TipoPagamento>();
            values.Add(PorHora);
            values.Add(PorDia);
            values.Add(PorSemana);
            values.Add(PorQuinzena);
            values.Add(PorMes);
            values.Add(PorTarefa);
            values.Add(NaoAplicavel);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static TipoPagamento ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));

    }
}
