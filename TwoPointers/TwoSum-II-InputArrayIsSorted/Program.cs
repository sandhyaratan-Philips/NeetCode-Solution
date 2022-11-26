using System;

namespace TwoSum_II_InputArrayIsSorted
{
    class Program
    {

        public static int[] TwoSum(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;
            int sum = 0;
            while (l < r)
            {
                sum = numbers[l] + numbers[r];

                if (sum > target)
                {
                    r--;
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    break;
                }
            }
            return new int[] { l + 1, r + 1 };
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Program.TwoSum(new int[] { 2, 7, 11, 15 }, 9)); //[1,2]
        }
    }
}
