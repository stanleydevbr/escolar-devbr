using RSAExtensions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DevBr.Core.Crypto
{
    public static class Assimetrica
    {
        private static RSA rsa = RSA.Create(2048);
        public static string ChavePublica()
        {
            rsa.ExportParameters(false);
            return rsa.ExportPublicKey(RSAKeyType.Pkcs1, true);
        }

        public static string ChavePrivada()
        {
            rsa.ExportParameters(true);
            return rsa.ExportPrivateKey(RSAKeyType.Pkcs1, true);
        }

        public static string Criptografar(string mensagem)
        {
            var cypher = rsa.Encrypt(Encoding.UTF8.GetBytes(mensagem), RSAEncryptionPadding.Pkcs1);
            return BitConverter.ToString(cypher).ToLower().Replace("-", string.Empty);
        }

        public static string Descriptografar(string cifra)
        {
            var cypher = Encoding.UTF8.GetBytes(cifra);
            var desc = rsa.Decrypt(cypher, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(desc);
        }
    }
}
