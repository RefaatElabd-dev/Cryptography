using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePad.CSharp
{
    internal class XOR
    {
        public static void Xor(int x, int y)
        {
            //Console.WriteLine(x ^ y);
            Console.WriteLine($"{x} ^ {y} = {Convert.ToString(x, 2)} ^ {Convert.ToString(y, 2)} = {Convert.ToString(x ^ y, 2)} = {x ^ y}");
        }
    }
}
