using System;
using System.Collections.Generic;

namespace _4Sum_ll
{
    class Program
    {
        public static int FourSumCount(int[] n1, int[] n2, int[] n3, int[] n4)
        {
            Dictionary<int, int> occuranceCount = new Dictionary<int, int>();
            int sum = 0;
            int count = 0;

            for (int i = 0; i < n1.Length; i++)
            {
                for (int j = 0; j < n2.Length; j++)
                {
                    sum = n1[i] + n2[j];
                    if (occuranceCount.ContainsKey(sum))
                    {
                        occuranceCount[sum]++;
                    }
                    else
                    {
                        occuranceCount.Add(sum, 1);
                    }
                }
            }

            for (int i = 0; i < n3.Length; i++)
            {
                for (int j = 0; j < n4.Length; j++)
                {
                    sum = n3[i] + n4[j];
                    count += occuranceCount.ContainsKey(0 - sum) == false ? 0 : occuranceCount[0 - sum];

                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2 };
            int[] nums2 = { -2, -1 };
            int[] nums3 = { -1, 2 };
            int[] nums4 = { 0, 2 };
            Console.WriteLine(Program.FourSumCount(nums1, nums2, nums3, nums3));
        }
    }
}
