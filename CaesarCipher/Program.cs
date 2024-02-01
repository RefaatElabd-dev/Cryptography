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
    }
}