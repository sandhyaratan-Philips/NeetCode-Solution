using System;

namespace add_binary
{
    /*
     * 67. Add Binary
        Given two binary strings a and b, return their sum as a binary string.

 

        Example 1:

        Input: a = "11", b = "1"
        Output: "100"
    */
    class Program
    {
        public string AddBinary(string a, string b)
        {
            string res = "";

            int s = 0;

            int i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0 || s == 1)
            {
                s += ((i >= 0) ? a[i] - '0' : 0);
                s += ((j >= 0) ? b[j] - '0' : 0);
                res = (char)(s % 2 + '0') + res;

                s /= 2;
                i--; j--;
            }
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.AddBinary(
            "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101"
            , "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011"));
        }
    }
}
