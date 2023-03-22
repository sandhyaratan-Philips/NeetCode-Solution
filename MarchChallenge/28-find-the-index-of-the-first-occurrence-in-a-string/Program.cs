using System;

namespace _28_find_the_index_of_the_first_occurrence_in_a_string
{
    /*
     * 28. Find the Index of the First Occurrence in a String
Medium

2226

123

Add to List

Share
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

 

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
    */
    class Program
    {
        public int StrStr(string haystack, string needle)
        {
            int m = haystack.Length;
            int n = needle.Length;

            for (int i = 0; i < m - n + 1; ++i)
                if (haystack.Substring(i, n).Equals(needle))
                    return i;

            return -1;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.StrStr("leetcode", "leeto"));
        }
    }
}
