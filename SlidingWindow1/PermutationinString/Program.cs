using System;

namespace PermutationinString
{
    class Program
    {
        public static bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;

            int[] s1Chars = new int[26];
            int[] s2Chars = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                s1Chars[s1[i] - 'a']++;
                s2Chars[s2[i] - 'a']++;
            }

            int match = 0;
            for (int i = 0; i < 26; i++)
            {
                if (s1Chars[i] == s2Chars[i])
                    match++;
            }

            int l = 0;
            int index = 0;

            for (int r = s1.Length; r < s2.Length; r++)
            {
                if (match == 26)
                    return true;

                index = s2[r] - 'a';

                s2Chars[index]++;

                if (s2Chars[index] == s1Chars[index])
                    match++;
                else if (s2Chars[index] == s1Chars[index] + 1)
                    match--;


                index = s2[l] - 'a';

                s2Chars[index]--;

                if (s2Chars[index] == s1Chars[index])
                    match++;
                else if (s2Chars[index] == s1Chars[index] - 1)
                    match--;

                l++;
            }

            return match == 26;
        }
        static void Main(string[] args)
        {
            string s1 = "ab";
            string s2 = "eidbaooo";//true

            string a1 = "adc";
            string a2 = "dcda";//true

            string b1 = "abc";
            string b2 = "ccccbbbbaaaa"; //false
            Console.WriteLine(Program.CheckInclusion(b1, b2));
        }
    }
}
