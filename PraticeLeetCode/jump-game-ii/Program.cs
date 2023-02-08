﻿using System;

namespace jump_game_ii
{
    /*
     * 45. Jump Game ii
     * You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].

        Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:

        0 <= j <= nums[i] and
        i + j < n
        Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

 

        Example 1:

        Input: nums = [2,3,1,1,4]
        Output: 2
        Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
    */
    class Program
    {
        public int Jump(int[] nums)
        {
            int res = 0;
            int l = 0;
            int r = 0;

            while (r < nums.Length - 1)
            {
                int farthest = 0;
                for (int i = l; i < r + 1; i++)
                {
                    farthest = Math.Max(farthest, i + nums[i]);
                }
                l = r + 1;
                r = farthest;
                res++;
            }
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.Jump(new int[] { 2, 3, 0, 1, 4 }));
        }
    }
}
