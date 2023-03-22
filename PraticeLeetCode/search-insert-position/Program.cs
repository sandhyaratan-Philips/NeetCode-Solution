using System;

namespace search_insert_position
{
    /*
     * 35. Search Insert Position

        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

        You must write an algorithm with O(log n) runtime complexity.

 

        Example 1:

        Input: nums = [1,3,5,6], target = 5
        Output: 2
    */
    class Program
    {
        public int SearchInsert(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length;

            while (l < r)
            {
                int m = (l + r) / 2;
                if (nums[m] == target)
                {
                    return m;
                }
                else if (nums[m] < target)
                {
                    l = m + 1;
                }
                else
                {
                    r = m;
                }
            }
            return r;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.SearchInsert(new int[] { 1, 3, 5, 6 }, 7));
        }
    }
}
