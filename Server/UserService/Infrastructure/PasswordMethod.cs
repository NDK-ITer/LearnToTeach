using System.Text;
using XSystem.Security.Cryptography;

namespace Infrastructure
{
    public static class PasswordMethod
    {
        public static string HashPassword(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }

        public static bool CheckPassword(string password, string passwordHash)
        {
            if (passwordHash == HashPassword(password))
            {
                return true;
            }
            return false;
        }
    }
}
