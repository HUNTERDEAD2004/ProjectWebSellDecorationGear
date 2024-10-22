using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention
{
    public class Hash
    {
        private const int HashSize = 32; // Kích thước băm (256 bits)

        // Mã hóa mật khẩu
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        // Xác thực mật khẩu
        public static bool VerifyPassword(string enteredPassword, string storedHash)
            {
            string hashOfInput = HashPassword(enteredPassword);
            return hashOfInput == storedHash;
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
