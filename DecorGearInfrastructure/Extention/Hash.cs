using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Extention
{
    public class Hash
    {
        private const string Key = "h4mX#u2Dv@9s8FHg";
        // mã hóa
        public static string EncryptPassword(string password)
        {
            using (var aes = new AesManaged())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
                byte[] iv = new byte[aes.BlockSize / 8];
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                aes.Key = keyBytes;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aes.CreateEncryptor();

                byte[] encryptedBytes = encryptor.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        // giải mã
        public static string DecryptPassword(string encryptedPassword)
        {
            using (var aes = new AesManaged())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
                byte[] iv = new byte[aes.BlockSize / 8];
                byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

                aes.Key = keyBytes;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = aes.CreateDecryptor();

                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        public static string GenerateRandomString()
        {
            const string chars = "0123456789";
            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }
    }
}
