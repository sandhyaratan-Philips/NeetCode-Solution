using System;

namespace TrappingRainWater
{
    class Program
    {
        public static int Trap(int[] height)
        {
            int N = height.Length;
            int[] leftMaxArr = new int[N];
            leftMaxArr[0] = 0;
            int[] rightMaxArr = new int[N];
            rightMaxArr[N - 1] = 0;

            int trapCount = 0;

            for (int i = 1; i <= N - 1; i++)
            {
                leftMaxArr[i] = Math.Max(leftMaxArr[i - 1], height[i - 1]);
            }

            for (int i = N - 2; i >= 0; i--)
            {
                rightMaxArr[i] = Math.Max(rightMaxArr[i + 1], height[i + 1]);
            }

            for (int i = 0; i < N - 1; i++)
            {
                var a = Math.Min(leftMaxArr[i], rightMaxArr[i]) - height[i];
                if (a > 0)
                {
                    trapCount += a;
                }
            }

            return trapCount;
        }
        static void Main(string[] args)
        {
            int[] a = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };// 6
            int[] b = new int[] { 4, 2, 0, 3, 2, 5 };//9
            Console.WriteLine(Program.Trap(b));
        }
    }
}
