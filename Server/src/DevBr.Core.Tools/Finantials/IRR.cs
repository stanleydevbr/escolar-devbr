namespace DevBr.Core.Tools.Finantials
{
    public static class IRR
    {
        public static double Calcular(this Dictionary<double, double> fluxoCaixa)
        {
            int count = 0;
            double r1 = 0.1d, r2 = 0.05d, v1, v2, r = 0, v;
            v1 = fluxoCaixa.ValorDesconto(r1);
            v2 = fluxoCaixa.ValorDesconto(r2);
            while (Math.Abs(v2 - v1) > .001 && count < 1000)
            {
                count++;
                r = (0 - v1) / (v1 - v2) * (r1 - r2) + r1;
                v = fluxoCaixa.ValorDesconto(r);
                v1 = v2;
                r1 = r2;
                v2 = v;
                r2 = r;
            }
            if (count == 1000) return -1;

            return r;
        }
        public static double ValorDesconto(this Dictionary<double, double> fluxoCaixa, double rate)
        {
            double dv = 0d;
            for (int i = 0; i < fluxoCaixa.Count; i++)
            {
                var element = fluxoCaixa.ElementAt(i);
                dv += element.Value * Math.Pow(1 + rate, -(element.Key));
            }
            return dv;
        }
    }

}
