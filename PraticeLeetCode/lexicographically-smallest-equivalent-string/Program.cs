using System;

namespace lexicographically_smallest_equivalent_string
{
    /*
     * You are given two strings of the same length s1 and s2 and a string baseStr.

        We say s1[i] and s2[i] are equivalent characters.

        For example, if s1 = "abc" and s2 = "cde", then we have 'a' == 'c', 'b' == 'd', and 'c' == 'e'.
        Equivalent characters follow the usual rules of any equivalence relation:

        Reflexivity: 'a' == 'a'.
        Symmetry: 'a' == 'b' implies 'b' == 'a'.
        Transitivity: 'a' == 'b' and 'b' == 'c' implies 'a' == 'c'.
        For example, given the equivalency information from s1 = "abc" and s2 = "cde", "acd" and "aab" are equivalent strings of baseStr = "eed", 
    and "aab" is the lexicographically smallest equivalent string of baseStr.

        Return the lexicographically smallest equivalent string of baseStr by using the equivalency information from s1 and s2.
    time: O((M+N)LogN)
    space: O(26+S)=>O(S)
    */
    class Program
    {
        int[] list = new int[26];

        int find(int x)
        {
            if (list[x] == -1)
                return x;
            else
                return list[x] = find(list[x]);
        }

        void union(int x, int y)
        {
            int parentx = find(x);
            int parenty = find(y);

            if (parentx == parenty) return;

            //if parent is diff
            list[Math.Max(parentx, parenty)] = Math.Min(parenty, parentx);
        }



        public string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            string str = "";
            for (int i = 0; i < 26; i++)
            {
                list[i] = -1;
            }
            for (int i = 0; i < s1.Length; i++)
            {
                union(s1[i] - 'a', s2[i] - 'a');
            }
            for (int i = 0; i < baseStr.Length; i++)
            {
                str += ((char)('a' + find(baseStr[i] - 'a')));
            }
            return str;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("least :" + program.SmallestEquivalentString("parker", "morris", "parser"));

        }
    }
}
