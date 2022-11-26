using System;
using System.Collections.Generic;

namespace SlidingWindow1
{
    class Program
    {
        public static int LengthOfLongestSubstring(string s)
        {

            int low = 0;
            int res = 0;
            HashSet<char> chars = new HashSet<char>();

            int N = s.Length;
            for (int high = 0; high < N; high++)
            {
                while (chars.Contains(s[high]))
                {
                    chars.Remove(s[low]);
                    low++;
                }
                chars.Add(s[high]);
                res = Math.Max(res, high - low + 1);
            }
            return res;
        }
        static void Main(string[] args)
        {
            string s = "abcabcbb";//3
            string b = "pwwkew";//3
            string c = "bbbb";//1
            string d = "au";//2
            string e = "dvdf";//3
            string a = "";
            Console.WriteLine(Program.LengthOfLongestSubstring(b));
        }
    }
}
