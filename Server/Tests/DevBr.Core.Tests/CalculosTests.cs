using DevBr.Core.Tools.Finantials;

namespace DevBr.Core.Tests
{
    internal static class CalculosTests
    {
        public static void MediaTest()
        {
            var valores = new List<double>();
            valores.Add(12);
            valores.Add(13);
            valores.Add(14);
            valores.Add(20);
            var calculos = new CalculosFinanceiros();

            var result = calculos.MediaSimples(valores);
            Console.WriteLine(result);
        }

        public static void JurosCompostosTest()
        {
            var calculos = new CalculosFinanceiros();
            var result = calculos.JurosCompostos(100, 0.02, 3);
            Console.WriteLine(result);
        }

        public static void CalculoAmortizacaoConstanteTeste()
        {
            var parcelas = AmortizacaoConstante.CalcularParcelas(5000m, 0.05m, 24);
            Console.WriteLine("PARCELA AMORTIZAÇÃO CONSTANTE");
            foreach (var parcela in parcelas)
            {
                Console.WriteLine(parcela.ToString());
            }
            Console.WriteLine("TOTAL: " + parcelas.Sum(x => x.Prestacao + x.Juros));
        }

        public static void CalculoAmortizacaoPriceTest()
        {
            var parcelas = AmortizacaoPrice.CalcularParcelas(5000m, 0.05m, 24);
            Console.WriteLine("PARCELA AMORTIZAÇÃO PRICE");
            foreach (var parcela in parcelas)
            {
                Console.WriteLine(parcela.ToString());
            }
            Console.WriteLine("TOTAL: " + parcelas.Sum(x => x.Prestacao + x.Juros));
        }

        public static void CalculoAmortizacaoMistaTest()
        {
            var parcelas = AmortizacaoMista.CalcularParcelas(5000m, 0.05m, 24);
            Console.WriteLine("PARCELA AMORTIZAÇÃO MISTA");
            foreach (var parcela in parcelas)
            {
                Console.WriteLine(parcela.ToString());
            }
            Console.WriteLine("TOTAL: " + parcelas.Sum(x => x.Prestacao + x.Juros));
        }

        public static void CaclularVPLTest()
        {
            var vpl = VPL.Calcular(new double[] { -6000000, 2300000, 2500000, 2500000, 2000000, 3000000 });
            var tir = TIR.Calcular(new double[] { -6000000, 2300000, 2500000, 2500000, 2000000, 3000000 });
            Console.WriteLine($"VPL: {vpl} | TIR: {tir.ToString("2")}");
        }
    }
}
