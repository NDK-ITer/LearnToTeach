using System.Text;
using XSystem.Security.Cryptography;

namespace Infrastructure
{
    public static class KeyHash
    {
        public static string Hash(string key)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(key);
            string encryptedString = Convert.ToBase64String(plainBytes);
            return encryptedString;
        }


        public static string Decode(string input)
        {
            byte[] encryptedBytes = Convert.FromBase64String(input);
            string decryptedString = Encoding.UTF8.GetString(encryptedBytes);
            return decryptedString;
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
