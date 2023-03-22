using System;

namespace _912_sort_an_array
{
    /*
     * 912. Sort an Array

        Given an array of integers nums, sort the array in ascending order and return it.

        You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.

        Example 1:

        Input: nums = [5,2,3,1]
        Output: [1,2,3,5]
        Explanation: After sorting the array, the positions of some numbers are not changed (for example, 2 and 3), while the positions of other numbers are changed (for example, 1 and 5).
    */
    class Program
    {
        public int[] SortArray(int[] nums)
        {
            return SortArray(nums, 0, nums.Length - 1);
        }

        public int[] SortArray(int[] nums, int l, int r)
        {
            if (l < r)
            {
                int mid = l + (r - l) / 2;
                SortArray(nums, l, mid);
                SortArray(nums, mid + 1, r);
                MergeArray(nums, l, mid, r);
            }
            return nums;
        }

        public void MergeArray(int[] nums, int l, int mid, int r)
        {
            int leftArrLength = mid - l + 1;
            int rightArrLength = r - mid;

            int[] leftArr = new int[leftArrLength];
            int[] rightArr = new int[rightArrLength];

            int i = 0;
            int j = 0;
            int k = l;
            for (int x = 0; x < leftArrLength; x++)
            {
                leftArr[x] = nums[x + l];
            }
            for (int x = 0; x < rightArrLength; x++)
            {
                rightArr[x] = nums[x + mid + 1];
            }

            while (i < leftArrLength && j < rightArrLength)
            {
                if (leftArr[i] <= rightArr[j])
                    nums[k++] = leftArr[i++];
                else
                    nums[k++] = rightArr[j++];
            }

            while (i < leftArrLength)
                nums[k++] = leftArr[i++];
            while (j < rightArrLength)
                nums[k++] = rightArr[j++];

        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.SortArray(new int[] { 5, 1, 1, 2, 0, 0 }));
        }
    }
}
