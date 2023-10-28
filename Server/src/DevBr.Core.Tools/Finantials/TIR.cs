namespace DevBr.Core.Tools.Finantials
{
    public static class TIR
    {
        public static double Calcular(double[] fluxoCaixa)
        {
            double tir = 0.0;
            double aux;
            int size = fluxoCaixa.Length;

            do
            {
                aux = 0;
                tir += 0.01;

                for (int i = 0; i < size; i++)
                    aux += fluxoCaixa[i] / Math.Pow((1 + tir / 100), i);
            } while (aux > 0);

            return tir;
        }
    }
}
