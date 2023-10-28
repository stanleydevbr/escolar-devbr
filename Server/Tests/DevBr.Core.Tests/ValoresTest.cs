using DevBr.Core.Tools.Valores;

namespace DevBr.Core.Tests
{
    public class ValoresTest
    {
        public static void ExtensoTest()
        {
            decimal valor = 110123.56m;
            Console.WriteLine(valor.ToExtenso());
        }
    }
}
