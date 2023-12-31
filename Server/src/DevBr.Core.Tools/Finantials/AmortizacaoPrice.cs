﻿using DevBr.Core.Tools.Formattings;

namespace DevBr.Core.Tools.Finantials
{
    public class AmortizacaoPrice
    {
        public static IReadOnlyList<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela>
            {
                new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor)
            };

            var saldoDevedorAtual = saldoDevedor;
            var coeficienteK = (taxaDeJuros * (1 + taxaDeJuros).ElevadoPor(prazo)) / ((1 + taxaDeJuros).ElevadoPor(prazo) - 1);
            var prestacaoAtravesDoPrazo = coeficienteK * saldoDevedor;

            for (var numeroDaParcela = 0; numeroDaParcela < prazo; numeroDaParcela++)
            {
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, 1);
                var amortizacao = prestacaoAtravesDoPrazo - juros;
                saldoDevedorAtual -= amortizacao;
                var parcelaAtual = new Parcela(juros.Arredondado(2), amortizacao.Arredondado(2), saldoDevedorAtual.Arredondado(2));
                parcelas.Add(parcelaAtual);
            }

            return parcelas;
        }
    }
}
