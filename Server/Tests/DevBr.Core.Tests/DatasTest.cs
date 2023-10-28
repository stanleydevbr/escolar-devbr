using DevBr.Core.Tools.Dates;

namespace DevBr.Core.Tests
{
    internal static class DatasTest
    {
        public static void UltimoDiaMesTest()
        {
            var data = DateTime.Now;
            var result = data.LastDayOfMonth();

            Console.WriteLine(result);
        }

        public static void PrimeiroDiaMesTest()
        {
            var data = DateTime.Now;
            var result = data.FirstDayOfMonth();

            Console.WriteLine(result);
        }

        public static void QuantidadeDeDiasEntreDuasDatasTest()
        {
            var dataInicio = new DateTime(2022, 1, 1);
            var dataTermino = new DateTime(2022, 12, 31);
            var result = dataTermino.NumberDay(dataInicio);
            Console.WriteLine(result);
        }

        public static void DiaDaSemanaTest()
        {
            var data = DateTime.Now;
            Console.WriteLine(data.DiaDaSemana());
        }
    }
}
