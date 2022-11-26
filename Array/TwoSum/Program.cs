using System;
using System.Collections.Generic;

namespace TwoSum
{
    class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length <= 1)
            {
                return null;
            }

            Dictionary<int, int> occurance = new Dictionary<int, int>(); //Dictionary <ith element, its index>

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];

                if (occurance.ContainsKey(diff))
                {
                    return new int[] { occurance[diff], i };
                }

                if (!occurance.ContainsKey(nums[i]))
                {
                    occurance.Add(nums[i], i);
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            var ans = Program.TwoSum(new int[] { 3, 2, 3 }, 6);
            Console.WriteLine(ans);
        }
    }
}
