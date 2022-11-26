using System;
using System.Collections.Generic;

namespace MinimumWindowSubstring
{
    class Program
    {
        public static string MinWindow(string s, string t)
        {
            if (s.Length < t.Length || s.Length == 0)
            {
                return "";
            }

            Dictionary<char, int> occuranceOfT = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                if (occuranceOfT.ContainsKey(t[i]))
                {
                    occuranceOfT[t[i]]++;
                }
                else
                {
                    occuranceOfT.Add(t[i], 1);
                }
            }
            int have = 0;
            int need = occuranceOfT.Count;
            int l = 0; int[] res = { -1, -1 }; int resLen = int.MaxValue;

            for (int r = 0; r < s.Length; r++)
            {
                if (window.ContainsKey(s[r]))
                {
                    window[s[r]]++;
                }
                else
                {
                    window.Add(s[r], 1);
                }

                if (occuranceOfT.ContainsKey(s[r]) && window[s[r]] == occuranceOfT[s[r]])
                {
                    have++;
                }
                while (have == need)
                {
                    if (r - l + 1 < resLen)
                    {
                        res = new int[] { l, r };
                        resLen = r - l + 1;
                    }
                    //remove from left
                    window[s[l]]--;
                    if (occuranceOfT.ContainsKey(s[l]) && window[s[l]] < occuranceOfT[s[l]])
                    {
                        have--;
                    }
                    l++;
                }
            }

            if (resLen != int.MaxValue)
            {
                return s.Substring(res[0], (res[1] - res[0] + 1));
            }
            else
                return "";
        }
        static void Main(string[] args)
        {
            string s = "ADOBECODEBANC";
            string t = "ABC";

            string a = "aa";
            string b = "aa";
            Console.WriteLine(Program.MinWindow(s, t));
        }
    }
}
