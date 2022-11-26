using System;
using System.Collections.Generic;

namespace EncodeandDecodeStrings
{
    class Program
    {
        // Encodes a list of strings to a single string.
        public static string encode(IList<string> strs)
        {
            string res = "";
            foreach (var item in strs)
            {
                res += item.Length + "#" + item;
            }
            return res; //"5#Hello5#World"
        }

        // Decodes a single string to a list of strings.
        public static IList<string> decode(string s)
        {
            IList<string> res = new List<string>();
            int i = 0;
            int j = i;
            int length = 0;
            while (i < s.Length)
            {
                j = i;
                while (s[j] != '#')
                {
                    j++;
                }
                length = Convert.ToInt32(s.Substring(i, j - i));
                res.Add(s.Substring(j + 1, length));
                i = j + 1 + length;
            }

            return res;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Program.decode(Program.encode(new List<string> { "Hello", "World" })));
        }
    }
}
