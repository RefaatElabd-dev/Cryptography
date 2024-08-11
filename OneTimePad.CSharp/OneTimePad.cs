using System.Security.Cryptography;

namespace OneTimePad
{
    public static class OneTimePad
    {
        // Method to generate a key stream of length n
        public static byte[] GenerateKeyStream(int n)
        {
            byte[] keyStream = new byte[n];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyStream);
            }
            return keyStream;
        }

        // Method to XOR the key stream with the message
        public static byte[] XOR(byte[] keyStream, byte[] message)
        {
            int length = Math.Min(message.Length, keyStream.Length);
            byte[] result = new byte[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = (byte)(message[i] ^ keyStream[i]);
            }
            return result;
        }
    }
}
