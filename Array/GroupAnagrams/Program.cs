using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupAnagrams
{
    class Program
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            int[] count = null;
            Dictionary<int[], List<string>> countDic = new Dictionary<int[], List<string>>();
            foreach (var item in strs)
            {
                count = new int[26];
                foreach (var character in item)
                {
                    count[character - 'a'] += 1;
                }

                string.Join(",", count);
                if (countDic.Any(x => x.Key.SequenceEqual(count))) // the Dictionary contain key was not working properly with array as key: check approch 2
                {
                    countDic.Where(x => x.Key.SequenceEqual(count)).FirstOrDefault().Value.Add(item);
                }
                else
                {
                    countDic.Add(count, new List<string> { item });
                }
            }
            IList<IList<string>> ans = new List<IList<string>>();


            foreach (var item in countDic.Values.ToList())
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
