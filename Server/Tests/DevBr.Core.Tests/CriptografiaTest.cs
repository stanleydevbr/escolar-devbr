using DevBr.Core.Crypto;

namespace DevBr.Core.Tests
{
    public class CriptografiaTest
    {
        public static void ChavePrivadaTest()
        {
            Console.WriteLine(Assimetrica.ChavePrivada());
        }

        public static void ChavePublicaTest()
        {
            Console.WriteLine(Assimetrica.ChavePublica());
        }

        public static void CriptografarTest()
        {
            Console.WriteLine(Assimetrica.Criptografar("Stanley Dias Paulo"));
        }

        public static void DescriptografarTest()
        {
            Console.WriteLine(Assimetrica.Descriptografar(Assimetrica.Criptografar("Stanley Dias Paulo")));
        }
    }
}
