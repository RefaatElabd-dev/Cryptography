using SubstitutionCipher.Attacks;
using SubstitutionCipher.Constants;
using System.Text;
using static Substitution.SubstitutionCipher;

public class Program
{
    private static void Main(string[] args)
    {
        #region permutations
        //List<IEnumerable<int>> nPermutations = Permutation.Permutations(new List<int> { 1, 2, 3, 4 });
        //Console.WriteLine(nPermutations.Count());
        //foreach (var permuation in nPermutations)
        //{
        //    Console.WriteLine(string.Join(" ,", permuation));
        //}
        //
        //var lettersPermutations = Permutation.Permutations("abcdefg");
        //Console.WriteLine(lettersPermutations.Count());
        //foreach (var permuation in lettersPermutations)
        //{
        //    Console.WriteLine(string.Join(" ,", permuation));
        //}

        #endregion

        #region Substitution Algorithm
        //var key = GenerateKey();
        //Console.WriteLine($"Key is: ");
        //PrintDectionary(key);
        //var text = "Link Development".ToUpper();
        //var encrypted = Encrypt(key, text);
        //Console.WriteLine($"encrypted text is : {encrypted}");
        //
        //var decryptKey = GetDecryptKey(key);
        //var decrypted = Encrypt(decryptKey, encrypted);
        //Console.WriteLine($"decrypted text is : {decrypted}");
        #endregion

        #region Attack
        var cipher = Constants.cipher.ToUpper();
        Console.WriteLine($"cipher text is : \n{cipher}");
        Console.WriteLine("-------------------Attack---------------------");

        var plaiCharsLeft = new StringBuilder("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        var cipherChars_Left = new StringBuilder("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

 Step1: var cipherFrequencies = FrequencyAnalysisAttack.CalculateFrequences(cipher);

        Console.WriteLine("-------------------Print Cipher Frequencies---------------------");
        PrintDectionary(cipherFrequencies);

 Step2: var mappingsForEachCipherChar = FrequencyAnalysisAttack.GetMappingsForEachCipherChar(cipherFrequencies);
       
        //Console.WriteLine("-------------------Print Mappings---------------------");
        //foreach (var mappings in mappingsForEachCipherChar)
        //{
        //    Console.WriteLine($"mappings for {mappings.Key} is:");
        //    PrintDectionary(mappings.Value); 
        //}
        Dictionary<char, char> dKey = new();

 Step3: Console.WriteLine("setSetKeyMapping According To Self Analyzing");
        
        //FrequencyAnalysisAttack.SetKeyMapping('R', 'E', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('B', 'T', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('P', 'H', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('J', 'O', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('I', 'S', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('W', 'I', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('K', 'N', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('C', 'W', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('U', 'R', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('H', 'L', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('V', 'C', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('X', 'F', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('T', 'Y', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('F', 'Q', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('M', 'A', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('S', 'P', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('O', 'G', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('E', 'V', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('A', 'X', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('N', 'U', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('D', 'D', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('Y', 'M', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('L', 'B', cipherChars_Left, plaiCharsLeft, ref dKey);
        //FrequencyAnalysisAttack.SetKeyMapping('Q', 'K', cipherChars_Left, plaiCharsLeft, ref dKey);

 Step4: dKey = FrequencyAnalysisAttack.GuessKey(cipherChars_Left, plaiCharsLeft, dKey, mappingsForEachCipherChar);
        Console.WriteLine($"Decrypt Key is: ");
        PrintDectionary(dKey);
 Step5: Console.WriteLine("-----------------------Dycrypting the cipher--------------------");
        string origenalMessage = Encrypt(dKey, cipher);
        Console.WriteLine($"origenal message after Decryption : \n {origenalMessage}");

        #endregion
    }



    private static void PrintDectionary<T1, T2>(Dictionary<T1, T2> freqs)
    {
        int cnt = 0;
        foreach (T1 ch in freqs.Keys)
        {
            Console.Write(ch!.ToString() + " : " + freqs[ch]!.ToString()!.PadRight(6));
            cnt++;
            if (cnt % 4 == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write("         ");
            }
        }
        Console.WriteLine();
    }
}

