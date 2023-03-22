using System;
using System.Collections.Generic;

namespace naming_a_company
{
    /*
     * You are given an array of strings ideas that represents a list of names to be used in the process of naming a company. The process of naming a company is as follows:

        Choose 2 distinct names from ideas, call them ideaA and ideaB.
        Swap the first letters of ideaA and ideaB with each other.
        If both of the new names are not found in the original ideas, then the name ideaA ideaB (the concatenation of ideaA and ideaB, separated by a space) is a valid company name.
        Otherwise, it is not a valid name.
        Return the number of distinct valid names for the company.

 

        Example 1:

        Input: ideas = ["coffee","donuts","time","toffee"]
        Output: 6
    */
    class Program
    {
        public long DistinctNames(string[] ideas)
        {
            long ans = 0;
            // Group strings by initials
            List<HashSet<string>> suffixes = new List<HashSet<string>>();

            for (int i = 0; i < 26; ++i)
                suffixes[i] = new HashSet<string>();

            foreach (String idea in ideas)
                suffixes[idea[0] - 'a'].Add(idea.Substring(1));

            for (int i = 0; i < 25; ++i)
                for (int j = i + 1; j < 26; ++j)
                {
                    int count = 0;
                    foreach (String suffix in suffixes[i])
                        if (suffixes[j].Contains(suffix))
                            ++count;
                    ans += 2 * (suffixes[i].Count - count) * (suffixes[j].Count - count);
                }

            return ans;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.DistinctNames(new string[] { "coffee", "donuts", "time", "toffee" }));
        }
    }
}
