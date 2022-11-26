using System;
using System.Collections.Generic;

namespace GroupAnagramsApproch2
{
    // O(M*N*26)=O(M*N) where M is size of strs and N is avg size of each element
    class Program
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            int[] count = null;
            Dictionary<string, List<string>> countDic = new Dictionary<string, List<string>>();
            foreach (var item in strs)
            {
                count = new int[26];
                foreach (var character in item)
                {
                    count[character - 'a'] += 1;
                }

                var key = string.Join(",", count);

                if (countDic.ContainsKey(key))
                {
                    countDic[key].Add(item);
                }
                else
                {
                    countDic.Add(key, new List<string> { item });
                }
            }
            IList<IList<string>> ans = new List<IList<string>>();


            foreach (var item in countDic.Values)
            {
                ans.Add(item);
            }

            return ans;
        }
        static void Main(string[] args)
        {
            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var ans = Program.GroupAnagrams(strs);
            Console.WriteLine("Hello World!");
        }
    }
}
