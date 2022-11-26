using System;
using System.Collections.Generic;

namespace _4Sum
{
    class Program
    {
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums); //O(nlogn)
            var asd = Program.kSum(nums, target, 0, 4);
            return asd;
        }

        public static IList<IList<int>> kSum(int[] nums, long target, int start, int k)
        {
            IList<IList<int>> res = new List<IList<int>>();
            // If we have run out of numbers to add, return res.
            if (start == nums.Length)
            {
                return res;
            }

            // There are k remaining values to add to the sum. The 
            // average of these values is at least target / k.
            long average_value = target / k;

            // We cannot obtain a sum of target if the smallest value
            // in nums is greater than target / k or if the largest 
            // value in nums is smaller than target / k.
            if (nums[start] > average_value || average_value > nums[nums.Length - 1])
            {
                return res;
            }

            if (k == 2)
            {
                return Program.twoSum(nums, target, start);
            }

            for (int i = start; i < nums.Length; ++i)
            {
                if (i == start || nums[i - 1] != nums[i])
                {
                    foreach (List<int> subset in kSum(nums, target - nums[i], i + 1, k - 1))
                    {
                        var asd = new List<int>();

                        asd.Add(nums[i]);
                        asd.AddRange(subset);
                        res.Add(asd);
                    }
                }
            }

            return res;

        }

        public static IList<IList<int>> twoSum(int[] nums, long target, int start)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int lo = start, hi = nums.Length - 1;

            while (lo < hi)
            {
                int currSum = nums[lo] + nums[hi];
                if (currSum < target || (lo > start && nums[lo] == nums[lo - 1]))
                {
                    ++lo;
                }
                else if (currSum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
                {
                    --hi;
                }
                else
                {
                    res.Add(new List<int> { nums[lo++], nums[hi--] });
                }
            }

            return res;
        }

        static void Main(string[] args)
        {
            int[] n = new int[] { 1, 0, -1, 0, -2, 2 }; //target=0
            int[] k = new int[] { 2, 2, 2, 2, 2 };//target=8
            int[] h = new int[] { -2, -1, -1, 1, 1, 2, 2 };//target=0
            Console.WriteLine(Program.FourSum(k, 8));
        }
    }
}
