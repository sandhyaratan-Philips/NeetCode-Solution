using System;
using System.Collections.Generic;

namespace word_pattern
{
    /*
     * Given a pattern and a string s, find if s follows the same pattern.

        Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
    */

    class Program
    {
        public bool WordPattern(string pattern, string s)
        {
            var arr = s.Split();
            if (pattern.Length != arr.Length)
            {
                return false;
            }
            Dictionary<char, string> map = new Dictionary<char, string>();
            bool ans = true;

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!map.ContainsKey(pattern[i]))
                {
                    if (!map.ContainsValue(arr[i]))
                        map.Add(pattern[i], arr[i]);
                    else
                    {
                        ans = false;
                        break;
                    }

                }
                else if (map[pattern[i]] != arr[i])
                {
                    ans = false;
                    break;
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("is pattern: " + program.WordPattern("aaaa", "dog dog dog dog"));
        }
    }
}
