namespace DevBr.Core.Tools.Formattings
{
    public static class FormattingDecimal
    {
        public static decimal DecimalFormat(this decimal valor, int NumberOfDecimal)
        {
            if (valor == null) return valor;
            return decimal.Parse(valor.ToString($"n{NumberOfDecimal}"));
        }
        public static decimal ElevadoPor(this decimal @base, int expoente)
        {
            return (decimal)Math.Pow((double)@base, expoente);
        }

        public static decimal Arredondado(this decimal numero, int casasDecimais)
        {
            return decimal.Round(numero, casasDecimais);
        }

        public static void ParaCadaFaca(this int numeroDeVezes, Action<int> metodo)
        {
            for (var i = 0; i < numeroDeVezes; i++)
                metodo.Invoke(i);
        }
    }
}
