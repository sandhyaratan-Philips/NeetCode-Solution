﻿using System;

namespace SlidingWindowMaximum2
{
    class Program
    {
        /*
            Iterate along the array in the direction left->right and build an array left.

            Iterate along the array in the direction right->left and build an array right.

            Build an output array as max(right[i], left[i + k - 1]) for i in range (0, n - k + 1).
         */
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            if (n * k == 0) return new int[0];
            if (k == 1) return nums;

            int[] left = new int[n];
            left[0] = nums[0];
            int[] right = new int[n];
            right[n - 1] = nums[n - 1];
            for (int i = 1; i < n; i++)
            {
                // from left to right
                if (i % k == 0) left[i] = nums[i];  // block_start
                else left[i] = Math.Max(left[i - 1], nums[i]);

                // from right to left
                int j = n - i - 1;
                if ((j + 1) % k == 0) right[j] = nums[j];  // block_end
                else right[j] = Math.Max(right[j + 1], nums[j]);
            }

            int[] output = new int[n - k + 1];
            for (int i = 0; i < n - k + 1; i++)
                output[i] = Math.Max(left[i + k - 1], right[i]);

            return output;
        }
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 }; int k = 3;
            Console.WriteLine(Program.MaxSlidingWindow(nums, k));
        }
    }
}
