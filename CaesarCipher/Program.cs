using static CaesarCipher.CaesarCipher;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    private static void Main(string[] args)
    {
        var encryptKey = GenerateKey(3);  // shift by 3
        var text = "Link Development".ToUpper();
        var encrypted = Encrypt(encryptKey, text);
        Console.WriteLine($"encrypted text is : {encrypted}");

        var decryptKey = GetDecryptKey(encryptKey);
        var decrypted = Encrypt(decryptKey, encrypted);
        Console.WriteLine($"decrypted text is : {decrypted}");
        Attacking_Caesar_Cipher(encrypted);
    }

    private static void Attacking_Caesar_Cipher(string encryptedMsg)
    {
        Console.WriteLine("Start Attacking Caesar Cipher");
        for (int i = 0; i < 26; i++) //26 for all English letters that ceasar cipher algorithm have
        {
            var dKey = GenerateKey(i);
            string message = Encrypt(dKey, encryptedMsg);
            // encrypt shift = x
            // decrypt shift is 26 - x
            Console.WriteLine($"for key: {i} => message is : {message}");
        }
    }
}