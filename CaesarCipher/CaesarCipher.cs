using System.Text;

namespace CaesarCipher
{
    public class CaesarCipher
    {
        public static Dictionary<char, char> GenerateKey(int shift)
        {
            var domain = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var key = new Dictionary<char, char>();
            for (var i = 0; i < domain.Length; i++)
            {
                key[domain[i]] = domain[(i + shift + domain.Length) % domain.Length];
            }
            return key;
        }

        public static Dictionary<char, char> GetDecryptKey(Dictionary<char, char> key) { 
            var dKey = new Dictionary<char, char>();
            foreach (KeyValuePair<char, char> item in key)
            {
                dKey[item.Value] = item.Key;
            }
            return dKey;
        }

        public static string Encrypt(Dictionary<char, char> key, string value)
        {
            StringBuilder encrypedString = new();
            for (var i = 0; i < value.Length; i++)
            {
                if (key.ContainsKey(value[i])) {
                    encrypedString.Append(key[value[i]]);
                }
                else
                {
                    encrypedString.Append(value[i]);
                }
            }
            return encrypedString.ToString();
        }
    }
}
