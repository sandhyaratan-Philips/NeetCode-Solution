using System;
using System.Linq;

namespace ValidAnagram
{
    class Program
    {
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            if (String.Concat(s.OrderBy(x => x)) == String.Concat(t.OrderBy(x => x)))
                return true;

            return false;
        }
        static void Main(string[] args)
        {
            //string s = "anagram"; string t = "nagaram";
            string s = "ac"; string t = "bb";
            Console.WriteLine(Program.IsAnagram(s, t));
        }
    }
}
