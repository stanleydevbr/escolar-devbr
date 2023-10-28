using DevBr.Core.Tools.Documents;
using DevBr.Core.Tools.Formattings;

namespace DevBr.Core.Tests
{
    internal static class DocumentsTests
    {
        public static bool CpfTest(Cpf sourceCPF) => sourceCPF.EhValido;

        public static void PisTest()
        {
            var result = Pis.IsValid("12708832311");
            Console.WriteLine(result);
        }

        public static void RemoverCaracteresEspeciaisTest()
        {
            var text = "Mãe, Feliz, Cão gato, não, canção é fisíca 'teste'";
            Console.WriteLine(text.RemoverCaracteresEspeciais());
        }
    }
}
