using System.Text;
using XSystem.Security.Cryptography;

namespace Infrastructure
{
    public static class KeyHash
    {
        public static string Hash(string key)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(key));
                return Convert.ToBase64String(data);
            }
        }

        public static bool CheckKey(string key, string keyHash)
        {
            if (keyHash == Hash(key))
            {
                return true;
            }
            return false;
        }
    }
}
