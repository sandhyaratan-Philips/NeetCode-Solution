using System;

namespace ValidPalindrome
{
    class Program
    {
        public static bool IsPalindrome(string s)
        {
            if (s == string.Empty)
            {
                return true;
            }
            int l = 0;
            int r = s.Length - 1;

            while (l < r)
            {
                while (l < r && !Program.IsAlphanum(s[l]))
                {
                    l++;
                }
                while (l < r && !Program.IsAlphanum(s[r]))
                {
                    r--;
                }

                if (char.ToLower(s[l]) != char.ToLower(s[r]))
                {
                    return false;
                }
                l++;
                r--;
            }
            return true;
        }

        public static bool IsAlphanum(char c)
        {
            return (65 <= (int)c && (int)c <= 90) || (97 <= (int)c && (int)c <= 122) || (48 <= (int)c && (int)c <= 57);
        }
        static void Main(string[] args)
        {
            string s = "A man, a plan, a canal: Panama"; //true
            string k = ".,";//true
            string h = "a.";//true
            Console.WriteLine(Program.IsPalindrome(h));
        }
    }
}
