namespace DevBr.Core.Tools.Finantials
{
    public static class VPL
    {
        public static double Calcular(double[] fluxoCaixa)
        {
            double vpl = 0;
            int size = fluxoCaixa.Length;
            double prepot = (1 + 0.2);

            for (int t = 0; t < size; t++)
            {
                double pot = Math.Pow(prepot, t);
                vpl += fluxoCaixa[t] / pot;
            }
            return vpl;
        }
    }

}
