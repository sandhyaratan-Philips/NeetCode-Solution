using System;

namespace count_odd_numbers_in_an_interval_range
{
    /*
     * 1523. Count Odd Numbers in an Interval Range

        Given two non-negative integers low and high. Return the count of odd numbers between low and high (inclusive).

        Example 1:

        Input: low = 3, high = 7
        Output: 3
        Explanation: The odd numbers between 3 and 7 are [3,5,7].
    */
    class Program
    {
        public int CountOdds(int low, int high)
        {
            int res = 0;
            for (int i = low; i <= high; i++)
            {
                if (i % 2 != 0)
                {
                    res++;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CountOdds(3, 7));
        }
    }
}
