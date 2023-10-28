namespace DevBr.Core.Tools.Finantials
{
    public class CalculosFinanceiros
    {
        public double? JurosSimples(double princial, double taxa, int tempo)
        {
            return princial * (1 + taxa) * tempo;
        }

        public double? JurosCompostos(double principal, double taxa, int numeroDeMes)
        {
            return (principal * Math.Pow((1 + taxa), numeroDeMes)) - principal;
        }

        public double? JurosCompostos(double principal, double taxa, DateTime inicio, DateTime termino)
        {
            var numeroDeDias = termino.Subtract(inicio).Days;
            return (principal * Math.Pow((1 + taxa), numeroDeDias)) - principal;
        }

        public double? MediaSimples(List<double> valores)
        {
            var itemTotal = valores.Count();
            var valorTotal = valores.Sum(x => x);
            return valorTotal / itemTotal;
        }

        public IEnumerable<TabelaDeValor> CalculoDeParcela(double principal, double taxa, int quantidadeParcela, DateTime inicio)
        {
            //TODO: Concluir
            /**
             * distribuir calculo em uma tabela de valores
             * **/

            return new List<TabelaDeValor>();
        }


    }
}
