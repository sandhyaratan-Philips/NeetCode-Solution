using System;
using System.Collections.Generic;

namespace find_all_anagrams_in_a_string
{
    /*
     * Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.

        An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

        Example 1:

        Input: s = "cbaebabacd", p = "abc"
        Output: [0,6]
        Explanation:
        The substring with start index = 0 is "cba", which is an anagram of "abc".
        The substring with start index = 6 is "bac", which is an anagram of "abc".
    */
    class Program
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> res = new List<int>();
            if (s.Length < p.Length)
                return res;



            Dictionary<char, int> Pcount = new Dictionary<char, int>();
            Dictionary<char, int> Scount = new Dictionary<char, int>();

            for (int i = 0; i < p.Length; i++)
            {
                if (Pcount.ContainsKey(p[i]))
                    Pcount[p[i]]++;
                else
                    Pcount.Add(p[i], 1);

                if (Scount.ContainsKey(s[i]))
                    Scount[s[i]]++;
                else
                    Scount.Add(s[i], 1);
            }

            if (Scount.Except(Pcount).Count() == 0)
                res.Add(0);


            int l = 0;


            for (int r = p.Length; r < s.Length; r++)
            {
                if (Scount.ContainsKey(s[r]))
                    Scount[s[r]]++;
                else
                    Scount.Add(s[r], 1);
                Scount[s[l]]--;

                if (Scount[s[l]] == 0)
                    Scount.Remove(s[l]);

                l++;

                if (Scount.Except(Pcount).Count() == 0)
                    res.Add(l);
            }

            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.FindAnagrams("asgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxkasgyfqvhoimpbtjleurdncwzxk", "fqvhoimpbtjleurdncwzxk"));
        }
    }
}
