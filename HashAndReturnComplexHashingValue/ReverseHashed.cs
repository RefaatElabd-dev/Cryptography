using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashAndReturnComplexHashingValue
{
    internal class ReverseHashed
    {
        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789+-._@";
            //const string chars = "elk236";//elmorshdi53
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static string CreateMD5Segmint(string segment, string fullmail)
        {
            //md5(md5(email) + x + md5(x))
            return CreateMD5(CreateMD5(fullmail) + segment + CreateMD5(segment));
        }

        public static List<string> HashedSeprator(string hashed)
        {
            int numberOfSegments = hashed.Length / 32;
            List<string> hashedCollection = new List<string>(numberOfSegments);
            int start = 0;
            for (int i = 1; i <= numberOfSegments; i++)
            {
                start = (i - 1) * 32;
                hashedCollection.Add(hashed.Substring(start, 32));
            }

            return hashedCollection;
        }

        public static string ReverseHashedFrom(string hashedValue)
        {
            int i = 1;
            //string HashedString = "0f63e1b87520cbce0d1a4c19b5d404a7271d3de08ca64165b56ec50a33f364f88306b54625df4b06c398cf2e2bac84e47d42d2eeb7bfc174a35a5007c0ed11df628255b7cc4314a6b415dc63bbdf0213d222e8311ec8ae40f9af930c47d99e21ddbda038d90ec0cb818f9caf1a4cf7be2ecbc149977b5dd25d016e3836b3831b058bb227e46542bcd372841880664d6356b5ed177900a73e3015c03bacefe306f72444660e799bb629bf3449fd3908657c2e81726548a7bfea288940ee314d48d77bdc7ee437d7ade3e681ca861f97c672edc9376dc08fd4d2485d1d0d4d23cf791b640fa5fb87b93ed79e4b0209a7072ef2a2180b52892ec27022d11fe6b0b7c17ea2048f66517857e5ed8673df815607a5cfbf9bef1816b983e9e90fe97bce";
            List<string> hashedArray = HashedSeprator(hashedValue);
            int emailLength = hashedArray.Count * 2;
            string domain = "@dijitalgaraj.com";
            int StringLengthFirstGuess = emailLength - domain.Length;
            string HashedTarget = hashedArray.Last();

            string emailValue = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            Dictionary<string, bool> token = new Dictionary<string, bool>(1000000);
            while (true)
            {
                Console.WriteLine(i++);
                str1 = GenerateRandomString(StringLengthFirstGuess);
                str2 = GenerateRandomString(StringLengthFirstGuess + 1);
                if (!token.ContainsKey(str1))
                {
                    token.Add(str1, true);
                    str3 = str1 + domain;
                    str3 = CreateMD5Segmint( str3, str3);

                    if (str3 == HashedTarget)
                    {
                        emailValue = str1;
                        Console.WriteLine(str1);
                        break;
                    }
                }

                if (!token.ContainsKey(str2))
                {
                    token.Add(str2, true);
                    str3 = str2 + domain;
                    str3 = CreateMD5Segmint(str3, str3);
                    if (str3 == HashedTarget)
                    {
                        emailValue = str2;
                        Console.WriteLine(str1);
                        break;
                    }
                }
            }
            Console.WriteLine(emailValue);
            return emailValue;
        }
    }
}
