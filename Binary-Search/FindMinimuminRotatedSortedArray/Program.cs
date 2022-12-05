using System;

namespace FindMinimuminRotatedSortedArray
{
    class Program
    {
        public static int FindMin(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;
            int res = int.MaxValue;

            while (l <= r)
            {
                if (nums[l] < nums[r])
                {
                    res = Math.Min(res, nums[l]);
                    break;
                }
                int mid = (l + r) / 2;
                res = Math.Min(res, nums[mid]);

                if (nums[mid] >= nums[l])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
