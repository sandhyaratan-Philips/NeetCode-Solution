using System;
using System.Collections.Generic;
using System.Linq;

namespace TopKFrequentElement
{
    class Program
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> occurance = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (occurance.ContainsKey(item))
                {
                    occurance[item] += 1;
                }
                else
                {
                    occurance.Add(item, 1);
                }
            }
            return occurance.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(',', Program.TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2)));
        }
    }
}
