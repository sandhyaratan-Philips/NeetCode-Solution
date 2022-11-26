using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingWindowMaximum
{
    class Program
    {
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length <= k)
            {
                return new int[] { nums.Max() };
            }


            int l = 0;
            int N = nums.Length;
            int r = 0;
            int[] arr = new int[N - k + 1];
            int j = 0;
            Deque<int> deqeue = new Deque<int>();

            while (r < N)
            {
                //pop the smallest
                while (deqeue.Count() > 0 && nums[deqeue[-1]] < nums[r])
                {
                    deqeue.RemoveFront();
                }
                deqeue.Add(r);

                if (l > deqeue[0])
                {
                    deqeue.RemoveBack();
                }
                if (r + 1 >= k)
                {
                    arr[j++] = nums[deqeue[0]];
                    l++;
                }
                r++;
            }


            return arr;

        }

        static void Main(string[] args)
        {
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 }; int k = 3;
            Console.WriteLine(Program.MaxSlidingWindow(nums, k));
        }
    }
}
