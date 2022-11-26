using System;

namespace LargestSumContiguousSubarray
{

    /*
     * approch a: prefix sum arr: O(N) 
     * arrpoch b: see below :O(N)       space:O(1) (Kadane’s Algorithm)
    */

    class Program
    {

        public static void LargestSumContiguous(int[] arr, int N)
        {
            if (N == 0)
            {
                return;
            }

            if (N == 1)
            {
                Console.WriteLine(arr[0]);
                return;
            }

            int Max = arr[0];
            int MaxSoFar = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                Max = Math.Max(Max + arr[i], arr[i]);

                if (MaxSoFar < Max)
                    MaxSoFar = Max;
            }

        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 1, 7, -1 }; //{ -2, -3, 4, -1, -2, 1, 5, -3 };
            Program.LargestSumContiguous(arr, arr.Length);
            //Console.WriteLine("Hello World!");
        }
    }
}
