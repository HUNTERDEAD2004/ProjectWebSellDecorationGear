using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention
{
    public class HashKey
    {
        private const int KeySize = 32; // 256 bits
        private const int IvSize = 16; // 128 bits
        private const int SaltSize = 16; // 128 bits
        private const int Iterations = 10000; // Số lần lặp để tạo khóa từ mật khẩu



        private static byte[] GenerateRandomBytes(int size)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[size];
                rng.GetBytes(bytes);
                return bytes;
            }
        }

        //mã hóa
        public static string EncryptPassword(string password, string plainText)
        {
            byte[] salt = GenerateRandomBytes(SaltSize);
            byte[] iv = GenerateRandomBytes(IvSize);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] key = deriveBytes.GetBytes(KeySize);

                using (var aes = new AesManaged())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var encryptor = aes.CreateEncryptor())
                    using (var ms = new MemoryStream())
                    {
                        ms.Write(salt, 0, salt.Length); // Ghi salt vào đầu
                        ms.Write(iv, 0, iv.Length);     // Ghi IV vào tiếp theo

                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        using (var writer = new StreamWriter(cs))
                        {
                            writer.Write(plainText);
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
        //giải mã
        public static string DecryptPassword(string password, string encryptedText)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);

            using (var ms = new MemoryStream(cipherBytes))
            {
                byte[] salt = new byte[SaltSize];
                byte[] iv = new byte[IvSize];

                ms.Read(salt, 0, SaltSize); // Đọc salt
                ms.Read(iv, 0, IvSize);     // Đọc IV

                using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    byte[] key = deriveBytes.GetBytes(KeySize);

                    using (var aes = new AesManaged())
                    {
                        aes.Key = key;
                        aes.IV = iv;
                        aes.Mode = CipherMode.CBC;
                        aes.Padding = PaddingMode.PKCS7;

                        using (var decryptor = aes.CreateDecryptor())
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        using (var reader = new StreamReader(cs))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string GenerateRandomString(int length = 8)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

