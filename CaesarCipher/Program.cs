using static CaesarCipher.CaesarCipher;

public class Program
{
    private static void Main(string[] args)
    {
        var encryptKey = GenerateKey(3);
        var text = "Starting Cryptography".ToUpper();
        var encrypted = Encrypt(encryptKey, text);
        Console.WriteLine($"encrypted text is : {encrypted}");
        var decryptKey = GetDecryptKey(encryptKey);
        var decrypted = Encrypt(decryptKey, encrypted);
        Console.WriteLine($"decrypted text is : {decrypted}");
        Console.WriteLine("Attacking Caesar Cipher");
        for (int i = 0; i < 26; i++) //26 for all English letters that ceasar cipher algorithm have
        {
            var dKey = GenerateKey(i);
            string message = Encrypt(dKey, encrypted);
            if(message == text)
            {
                Console.WriteLine($"for key: {i} => message is : {message}");
                Console.WriteLine($"The secret decrypt Key is: {i}");
            }
        }
    }
}