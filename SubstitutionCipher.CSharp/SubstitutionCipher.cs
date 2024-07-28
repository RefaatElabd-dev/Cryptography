using System.Text;

namespace Substitution
{
    public class SubstitutionCipher
    {
        public static Dictionary<char, char> GenerateKey()
        {
            var keys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var domain = new List<char>(keys);
            Random random = new Random();
            var key = new Dictionary<char, char>();

            foreach (char c in keys)
            {
                int index = random.Next(domain.Count);
                key[c] = domain.ElementAt(index);
                domain.RemoveAt(index);
            }

            return key;
        }

        public static Dictionary<char, char> GetDecryptKey(Dictionary<char, char> key)
        {
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
                if (key.ContainsKey(value[i]))
                {
                    encrypedString.Append(key[value[i]]);
                }
                else // any another char like * _ space ...
                {
                    encrypedString.Append(value[i]);
                }
            }
            return encrypedString.ToString();
        }
    }
}
