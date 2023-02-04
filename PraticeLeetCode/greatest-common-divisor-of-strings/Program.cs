using System;

namespace greatest_common_divisor_of_strings
{
    /*
    For two strings s and t, we say "t divides s" if and only if s = t + ... + t (i.e., t is concatenated with itself one or more times).

    Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.
     */
    class Program
    {
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1.Length < str2.Length)
                return GcdOfStrings(str2, str1);
            if (str2.Equals(""))
                return str1;
            if (!str1.StartsWith(str2))
                return "";
            return GcdOfStrings(str2, mod(str1, str2));
        }

        string mod(string str1, string str2)
        {
            while (str1.StartsWith(str2))
            {
                str1 = str1.Substring(str2.Length);
            }
            return str1;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.GcdOfStrings("ABCABC", "ABC"));
        }
    }
}
