using System;

namespace verifying_an_alien_dictionary
{
    class Program
    {
        /*
         In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

        Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.
         */

        public bool IsAlienSorted(string[] words, string order)
        {
            int[] map = new int[26];

            for (int i = 0; i < order.Length; i++)
            {
                map[order[i] - 'a'] = i;
            }

            for (int i = 0; i + 1 < words.Length; ++i)
                if (!comapre(words[i], words[i + 1], map))
                    return false;

            return true;
        }

        private bool comapre(string s1, string s2, int[] map)
        {
            int m = s1.Length; int n = s2.Length;

            for (int i = 0; i < Math.Min(m, n); i++)
            {
                if (map[s1[i] - 'a'] < map[s2[i] - 'a'])
                    return true;
                else if (map[s1[i] - 'a'] > map[s2[i] - 'a'])
                    return false;
            }
            if (n >= m) return true;
            return false;
        }



        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz"));
        }
    }
}
