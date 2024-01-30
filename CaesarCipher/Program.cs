using static CaesarCipher.CaesarCipher;

public class Program
{
    private static void Main(string[] args)
    {
        var key = GenerateKey(3);
        var text = "Starting Cryptography".ToUpper();
        var encrypted = Encrypt(key, text);
        Console.WriteLine($"encrypted text is : {encrypted}");
        var decrypted = Decrypt(key, encrypted);
        Console.WriteLine($"decrypted text is : {decrypted}");
    }
}