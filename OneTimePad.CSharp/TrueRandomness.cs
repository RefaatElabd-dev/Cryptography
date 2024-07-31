using System;
using System.Security.Cryptography;

namespace OneTimePad.TrueRandomness
{
    public class TrueRandomness
    {
        public static int GetRandomIntFromRNG()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4]; // 4 bytes for an integer
                rng.GetBytes(randomNumber);
                return BitConverter.ToInt32(randomNumber, 0);
            }
        }

        public static byte[] GetRandomBytesFromRNG(int length)
        {
            using(RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }

        public static int GetRandomInt()
        {
            byte[] randomNumber = new byte[4]; // 4 bytes for an integer
            RandomNumberGenerator.Fill(randomNumber);
            return BitConverter.ToInt32(randomNumber, 0);
        }

        public static byte[] GetRandomBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            RandomNumberGenerator.Fill(randomBytes);
            return randomBytes;
        }
    }
}
