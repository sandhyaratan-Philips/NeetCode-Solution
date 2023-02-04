using System;

namespace maximum_sum_circular_subarray
{
    /*
     * Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.

        A circular array means the end of the array connects to the beginning of the array. Formally, the next element of nums[i] is nums[(i + 1) % n] 
            and the previous element of nums[i] is nums[(i - 1 + n) % n].

        A subarray may only include each element of the fixed buffer nums at most once. Formally, for a subarray nums[i], nums[i + 1], ..., nums[j],
            there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.
        Input: nums = [1,-2,3,-2]
        Output: 3
        Explanation: Subarray [3] has maximum sum 3.
 */
    class Program
    {
        public int MaxSubarraySumCircular(int[] nums)
        {
            int currMax = 0;
            int GlobalMax = nums[0];

            int currMin = 0;
            int GlobalMin = nums[0];
            int total = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currMax = Math.Max(nums[i], (currMax + nums[i]));
                currMin = Math.Min(nums[i], (currMin + nums[i]));

                GlobalMax = Math.Max(GlobalMax, currMax);
                GlobalMin = Math.Min(GlobalMin, currMin);
                total += nums[i];
            }

            if (GlobalMax < 0)
                return GlobalMax;
            return GlobalMax > (total - GlobalMin) ? GlobalMax : (total - GlobalMin);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaxSubarraySumCircular(new int[] { -3, -2, -3 }));
        }
    }
}
