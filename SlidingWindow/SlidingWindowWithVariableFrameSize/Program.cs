using System;

namespace SlidingWindowWithVariableFrameSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FindMaxSumSubarray: " + FindSmallestSubarraySize(new int[] { 4, 2, 2, 7, 8, 1, 2, 8, 10 }, 3));
        }

        private static int FindSmallestSubarraySize(int[] arr, int targetsum) //the subset sum should be >= to the targetsum
        {
            if (arr.Length == 1)
            {
                return 1;
            }
            else if (arr.Length == 0)
            {
                return 0;
            }
            else
            {
                int minWindowSize = int.MaxValue;
                int currentWindowSum = 0;
                int windowStart = 0;
                for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
                {
                    currentWindowSum += arr[windowEnd];

                    while (currentWindowSum >= targetsum)
                    {
                        minWindowSize = Math.Min(minWindowSize, (windowEnd - windowStart + 1));
                        currentWindowSum -= arr[windowStart];
                        windowStart++;
                    }
                }
                return minWindowSize;
            }
        }
    }
}
