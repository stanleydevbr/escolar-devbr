namespace DevBr.Core.Tools.Finantials
{
    public static class LucroLiquido
    {
        public static double Calcular(double entrada, double lucroMes)
        {
            var result = ((lucroMes / entrada) * 100);
            return result;
        }
    }
}
