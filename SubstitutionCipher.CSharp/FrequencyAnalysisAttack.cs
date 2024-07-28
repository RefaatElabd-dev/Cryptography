using System.Text;
using static System.Math;

namespace SubstitutionCipher.Attacks
{
    public class FrequencyAnalysisAttack
    {
        public static Dictionary<char, float> CalculateFrequences(string message)
        {
            message = message.ToUpper();
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<char, float> frequencies = new Dictionary<char, float>();

            foreach (char ch in alphabets)
            {
                frequencies[ch] = 0.0f;
            }

            int lettersCount = message.Count(c => alphabets.Contains(c));
            foreach (char ch in message)
            {
                if (frequencies.ContainsKey(ch))
                {
                    frequencies[ch] += 1;
                    //lettersCount++;
                }
            }

            foreach (char c in frequencies.Keys)
            {
                frequencies[c] = (float)Math.Round(frequencies[c] / lettersCount, 4);
            }

            return frequencies;
        }

        public static Dictionary<char, Dictionary<char, float>> GetMappingsForEachCipherChar(Dictionary<char, float> messageFrequences)
        {
            Dictionary<char, Dictionary<char, float>> mappings = new();

            foreach (var standardKey in EnglishFrequencies.Keys)
            {
                Dictionary<char, float> map = new();
                foreach (var messageKey in messageFrequences.Keys)
                {
                    map[messageKey] = (float)Round(Abs(EnglishFrequencies[standardKey] - messageFrequences[messageKey]), 4);
                }

                mappings[standardKey] = map.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            return mappings;
        }

        public static void SetKeyMapping(char cipherChar, char plainChar, StringBuilder cipherCharsLeft, StringBuilder plainCharsLeft, ref Dictionary<char, char> key)
        {
            if (!cipherCharsLeft.ToString().Contains(cipherChar) || !plainCharsLeft.ToString().Contains(plainChar))
            {
                return;
            }
            key[cipherChar] = plainChar;
            cipherCharsLeft.Remove(cipherCharsLeft.ToString().IndexOf(cipherChar), 1);
            plainCharsLeft.Remove(plainCharsLeft.ToString().IndexOf(plainChar), 1);
        }

        public static Dictionary<char, char> GuessKey(StringBuilder cipherCharsLeft, StringBuilder plainCharsLeft, Dictionary<char, char> key, Dictionary<char, Dictionary<char, float>> mappings)
        {
            foreach (char c in cipherCharsLeft.ToString())
            {
                var leftCharDifferences = mappings[c];
                foreach (var plainChar in leftCharDifferences.Keys)
                {
                    if (plainCharsLeft.ToString().Contains(plainChar))
                    {
                        key[c] = plainChar;
                        plainCharsLeft.Remove(plainCharsLeft.ToString().IndexOf(plainChar), 1);
                        break;
                    }
                }
            }

            return key;
        }

        private static readonly Dictionary<char, float> EnglishFrequencies = new Dictionary<char, float>()
        {
            { 'A', 0.0817f },
            { 'B', 0.0150f },
            { 'C', 0.0278f },
            { 'D', 0.0425f },
            { 'E', 0.1270f },
            { 'F', 0.0223f },
            { 'G', 0.0202f },
            { 'H', 0.0609f },
            { 'I', 0.0697f },
            { 'J', 0.0015f },
            { 'K', 0.0077f },
            { 'L', 0.0403f },
            { 'M', 0.0241f },
            { 'N', 0.0675f },
            { 'O', 0.0751f },
            { 'P', 0.0193f },
            { 'Q', 0.0010f },
            { 'R', 0.0599f },
            { 'S', 0.0633f },
            { 'T', 0.0906f },
            { 'U', 0.0276f },
            { 'V', 0.0098f },
            { 'W', 0.0236f },
            { 'X', 0.0015f },
            { 'Y', 0.0197f },
            { 'Z', 0.0007f }
        };
    }
}
