using System.Globalization;
using System.Text;

namespace DevBr.Core.Tools.Formattings
{
    public static class FormattingDocuments
    {
        public static string CpfFormat(this string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return cpf;
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static string CpfFormatString(this string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return cpf;
            cpf = cpf.Replace(".", "").Replace("-", "").Trim();
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}.{cpf.Substring(9, 2)}";
        }

        public static string CnpjFormat(this string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj)) return cnpj;
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        public static string RemoverAcentos(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string RemoverCaracteresEspeciais(this string text)
        {
            //http://leandrolisura.com.br/removendo-acentos-de-um-string-usando-c/

            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
