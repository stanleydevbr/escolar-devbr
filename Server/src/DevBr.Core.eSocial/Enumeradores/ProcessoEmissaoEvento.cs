namespace DevBr.Core.eSocial.Enumeradores
{
    public class ProcessoEmissaoEvento : TipoBase<ProcessoEmissaoEvento>
    {

        private static ProcessoEmissaoEvento Empregador = new ProcessoEmissaoEvento(1, "Aplicativo do empregador");
        private static ProcessoEmissaoEvento PessoaFisica = new ProcessoEmissaoEvento(2, "Aplicativo governamental - Simplificado Pessoa Física");
        private static ProcessoEmissaoEvento WebGeral = new ProcessoEmissaoEvento(3, "Aplicativo governamental - Web Geral");
        private static ProcessoEmissaoEvento PessoaJuridica = new ProcessoEmissaoEvento(4, "Aplicativo governamental - Simplificado Pessoa Jurídica");
        private static ProcessoEmissaoEvento JuntaComercial = new ProcessoEmissaoEvento(9, "Aplicativo governamental - Integração com a Junta Comercial");
        private static ProcessoEmissaoEvento EmpregadorDomestico = new ProcessoEmissaoEvento(22, "Aplicativo governamental para dispositivos móveis empregador doméstico");
        public ProcessoEmissaoEvento(uint codigo, string descricao) : base(codigo, descricao) { }

        protected static List<ProcessoEmissaoEvento> Valores()
        {
            var values = new List<ProcessoEmissaoEvento>();
            values.Add(Empregador);
            values.Add(PessoaFisica);
            values.Add(WebGeral);
            values.Add(PessoaJuridica);
            values.Add(JuntaComercial);
            values.Add(EmpregadorDomestico);
            return values;
        }
        public static uint[] ToCodigos() => Valores().Select(x => x.Codigo).ToArray();
        public static ProcessoEmissaoEvento ObterTipo(uint valor) => Valores().FirstOrDefault(x => x.Codigo == valor);
        public static string ToValores() => string.Join(", ", Valores().Select(x => x.ToString()));

    }
}
