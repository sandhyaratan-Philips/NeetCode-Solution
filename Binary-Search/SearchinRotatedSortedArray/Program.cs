using System;

namespace SearchinRotatedSortedArray
{
    class Program
    {
        public static int Search(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;

            while (l <= r)
            {
                int mid = (l + r) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[l] <= nums[mid])
                    if (nums[mid] < target || target < nums[l])
                        l = mid + 1;
                    else r = mid - 1;

                else if (nums[mid] > target || target > nums[r])
                    r = mid - 1;
                else l = mid + 1;

            }
            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
