using System;

namespace CountSpecialQuadruplets
{
    class Program
    {
        public static int CountQuadruplets(int[] nums)
        {
            int count = 0;
            int length = nums.Length;
            for (int i = 0; i < length - 3; i++)
            {
                for (int j = i + 1; j < length - 2; j++)
                {
                    for (int k = j + 1; k < length - 1; k++)
                    {
                        int sum = nums[i] + nums[j] + nums[k];
                        for (int m = k + 1; m < length; m++)
                        {
                            if (sum == nums[m])
                                count++;
                        }
                    }
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3, 6 };
            int[] b = new int[] { 1, 1, 1, 3, 5 };//4
            int[] c = new int[] { 2, 16, 9, 27, 3, 39 };//2
            int[] d = new int[] { 9, 6, 8, 23, 39, 23 };//2
            Console.WriteLine(Program.CountQuadruplets(b));
        }
    }
}
