using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashAndReturnComplexHashingValue
{

    internal class Hash
    {
        public static List<string> SplitMyEmail(string mail)
        {
            int splitfactor = 0;
            double CollectionLength = mail.Length / 2;
            CollectionLength = Math.Ceiling((double)mail.Length / 2);

            List<string> splitted = new List<string>((int)CollectionLength);

            do
            {
                splitfactor += 2;
                if (splitfactor > mail.Length) splitfactor = mail.Length;
                splitted.Add(mail.Substring(0, splitfactor));
            } while (splitfactor < mail.Length);
            return splitted;
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

        public static string HashTargetEmailWithComblexMD5Equation(string email)
        {
            //const string mail = "elmorshdi53@gmail.com";
            List<string> splitedMail = SplitMyEmail(email);
            StringBuilder sb = new StringBuilder();
            foreach (var item in splitedMail)
            {
                //Console.WriteLine(item);
                Console.WriteLine(CreateMD5Segmint(item, email));
                //Console.WriteLine(CreateMD5Segmint(item, mail).Length);
                sb.Append(CreateMD5Segmint(item, email));
            }

            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }
    }
}
