using System;

namespace permutation_in_string
{
    /*
     * Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

        In other words, return true if one of s1's permutations is the substring of s2.

 

        Example 1:

        Input: s1 = "ab", s2 = "eidbaooo"
        Output: true
        Explanation: s2 contains one permutation of s1 ("ba").
    */

    class Program
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;
            int[] s1Char = new int[26];
            int[] s2Char = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                s1Char[s1[i] - 'a']++;
                s2Char[s2[i] - 'a']++;
            }

            int match = 0;

            for (int i = 0; i < 26; i++)
            {
                if (s1Char[i] == s2Char[i])
                    match++;
            }

            int l = 0;
            int index = 0;

            for (int i = s1.Length; i < s2.Length; i++)
            {
                if (match == 26)
                    return true;
                index = s2[i] - 'a';
                s2Char[index]++;

                if (s2Char[index] == s1Char[index])
                    match++;
                else if (s2Char[index] == s1Char[index] + 1)
                    match--;

                index = s2[l] - 'a';
                s2Char[index]--;

                if (s2Char[index] == s1Char[index])
                    match++;
                else if (s2Char[index] == s1Char[index] - 1)
                    match--;
                l++;
            }

            return match == 26;

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CheckInclusion("ab", "eidbaooo"));
        }
    }
}
