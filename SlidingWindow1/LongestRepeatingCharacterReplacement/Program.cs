using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestRepeatingCharacterReplacement
{
    class Program
    {
        public static int CharacterReplacement(string s, int k)
        {
            Dictionary<char, int> occurance = new Dictionary<char, int>();
            int res = 0;

            int l = 0;
            int N = s.Length;


            for (int r = 0; r < N; r++)
            {
                if (occurance.ContainsKey(s[r]))
                {
                    occurance[s[r]]++;
                }
                else
                {
                    occurance.Add(s[r], 1);
                }

                while (((r - l + 1) - (occurance.Values).Max()) > k)
                {
                    occurance[s[l]]--;
                    l++;
                }
                res = Math.Max(res, r - l + 1);
            }
            return res;
        }
        static void Main(string[] args)
        {
            string s = "AABABBA";
            Console.WriteLine(Program.CharacterReplacement(s, 1));
        }
    }
}
