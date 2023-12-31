﻿using DevBr.Core.Tools.Formattings;

namespace DevBr.Core.Tools.Finantials
{
    public class AmortizacaoConstante
    {
        public static IReadOnlyList<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela>();
            var saldoDevedorAtual = saldoDevedor;
            var amortizacaoAtravesDoPrazo = saldoDevedor / prazo;

            parcelas.Add(new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor));

            for (var numeroDaParcela = 0; numeroDaParcela < prazo; numeroDaParcela++)
            {
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, prazo: 1);
                saldoDevedorAtual -= amortizacaoAtravesDoPrazo;

                var temQueCompensarDizimaPeriodica = numeroDaParcela == prazo - 1 && saldoDevedorAtual != 0;

                if (temQueCompensarDizimaPeriodica)
                    amortizacaoAtravesDoPrazo += 0.01m;

                parcelas.Add(new Parcela(juros.Arredondado(2), amortizacaoAtravesDoPrazo.Arredondado(2), saldoDevedorAtual.Arredondado(2)));

            }

            return parcelas;
        }
    }
}
