using System;
using System.Collections.Generic;
using System.Linq;

namespace longest_continuous_subarray_with_absolute_diff_less_than_or_equal_to_limit
{
    /*
     * 1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit

Given an array of integers nums and an integer limit, return the size of the longest non-empty subarray such that the absolute difference between any two elements of this subarray is less than or equal to limit.

 

Example 1:

Input: nums = [8,2,4,7], limit = 4
Output: 2 
Explanation: All subarrays are: 
[8] with maximum absolute diff |8-8| = 0 <= 4.
[8,2] with maximum absolute diff |8-2| = 6 > 4. 
[8,2,4] with maximum absolute diff |8-2| = 6 > 4.
[8,2,4,7] with maximum absolute diff |8-2| = 6 > 4.
[2] with maximum absolute diff |2-2| = 0 <= 4.
[2,4] with maximum absolute diff |2-4| = 2 <= 4.
[2,4,7] with maximum absolute diff |2-7| = 5 > 4.
[4] with maximum absolute diff |4-4| = 0 <= 4.
[4,7] with maximum absolute diff |4-7| = 3 <= 4.
[7] with maximum absolute diff |7-7| = 0 <= 4. 
Therefore, the size of the longest subarray is 2.
    */
    class Program
    {
        public int LongestSubarray(int[] nums, int limit)
        {
            LinkedList<int> max = new LinkedList<int>();
            LinkedList<int> min = new LinkedList<int>();
            int i = 0;
            int maxWindowSize = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                while (max.Any() && nums[j] > max.Last.Value)
                    max.RemoveLast();
                while (min.Any() && nums[j] < min.Last.Value)
                    min.RemoveLast();
                max.AddLast(nums[j]);
                min.AddLast(nums[j]);

                while (max.First.Value - min.First.Value > limit)
                {
                    if (max.First.Value == nums[i])
                        max.RemoveFirst();
                    if (min.First.Value == nums[i])
                        min.RemoveFirst();
                    i++;
                }

                maxWindowSize = Math.Max(maxWindowSize, j - i + 1);
            }
            return maxWindowSize;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.LongestSubarray(new int[] { 2, 2, 2, 4, 4, 2, 5, 5, 5, 5, 5, 2 }, 2));
        }
    }
}
