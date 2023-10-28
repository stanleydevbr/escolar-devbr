using DevBr.Core.Tools.Formattings;

namespace DevBr.Core.Tools.Finantials
{
    public class AmortizacaoMista
    {
        public static IReadOnlyList<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela> { new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor) };

            var parcelasNoSAC = AmortizacaoConstante.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var parcelasNoPrice = AmortizacaoPrice.CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var saldoDevedorAtual = saldoDevedor;

            for (var indiceDaParcela = 1; indiceDaParcela < parcelasNoSAC.Count; indiceDaParcela++)
            {
                var parcelaMedia = (parcelasNoSAC[indiceDaParcela].Prestacao + parcelasNoPrice[indiceDaParcela].Prestacao) / 2;
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, 1);
                var amortizacao = parcelaMedia - juros;
                saldoDevedorAtual -= amortizacao;
                var parcelaAtual = new Parcela(juros.Arredondado(2), amortizacao.Arredondado(2), saldoDevedorAtual.Arredondado(2));
                parcelas.Add(parcelaAtual);
            }

            return parcelas;
        }
    }
}
