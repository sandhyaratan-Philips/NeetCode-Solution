using System;

namespace shuffle_the_array
{
    /*
     * Leetcode 1470
     * Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].

        Return the array in the form [x1,y1,x2,y2,...,xn,yn].

 

        Example 1:

        Input: nums = [2,5,1,3,4,7], n = 3
        Output: [2,3,5,4,1,7] 
        Explanation: Since x1=2, x2=5, x3=1, y1=3, y2=4, y3=7 then the answer is [2,3,5,4,1,7].
    */
    class Program
    {
        public int[] Shuffle(int[] nums, int n)
        {
            int[] ans = new int[2 * n];
            int j = 0;
            for (int i = 0; i < 2 * n; i = i + 2)
            {
                ans[i] = nums[j];
                ans[i + 1] = nums[n + j];
                j++;
            }
            return ans;

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Shuffle(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4);
            Console.WriteLine("Hello World!");
        }
    }
}
