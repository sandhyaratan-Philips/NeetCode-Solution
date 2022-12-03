using System;

namespace BinarySearch
{
    class Program
    {

        public static int Search(int[] nums, int target)
        {
            return Binary_Search(nums, 0, nums.Length - 1, target);
        }

        public static int Binary_Search(int[] arr, int start, int end, int target)
        {
            if (end >= start)
            {
                int mid = (start + end) / 2;

                if (arr[mid] == target)
                    return mid;

                if (arr[mid] < target)
                    return Binary_Search(arr, mid + 1, end, target);

                if (arr[mid] > target)
                    return Binary_Search(arr, start, mid - 1, target);
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int target = 9;
            Console.WriteLine(Program.Search(nums, target));
        }
    }
}
