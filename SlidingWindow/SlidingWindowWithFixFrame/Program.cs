using System;

namespace SlidingWindowWithFixFrame
{
    class Program
    {

        public static int FindMaxSumSubarray(int[] arr, int frameSize)
        {
            if (arr.Length == 1)
            {
                return arr[0];
            }
            else if (arr.Length == 0)
            {
                return 0;
            }
            else
            {
                int maxSum = int.MinValue;
                int currentRunningSum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    currentRunningSum += arr[i];
                    if (i >= (frameSize - 1))
                    {
                        maxSum = Math.Max(maxSum, currentRunningSum);
                        currentRunningSum -= arr[i - (frameSize - 1)];
                    }
                }
                return maxSum;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("FindMaxSumSubarray: " + FindMaxSumSubarray(new int[] { 4, 2, 1, 7, 8, 1, 2, 8, 1, 0 }, 3));
        }
    }
}
