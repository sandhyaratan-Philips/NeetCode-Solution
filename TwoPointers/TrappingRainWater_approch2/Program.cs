using System;

namespace TrappingRainWater_approch2
{
    class Program
    {
        public static int Trap(int[] height)
        {
            if (height.Length == 0)
                return 0;

            int l = 0;
            int N = height.Length;
            int r = N - 1;

            int leftMax = height[l];
            int rightMax = height[r];

            int trapCount = 0;

            while (l < r)
            {
                if (leftMax < rightMax)
                {
                    l++;
                    leftMax = Math.Max(leftMax, height[l]);
                    trapCount += leftMax - height[l];
                }
                else
                {
                    r--;
                    rightMax = Math.Max(rightMax, height[r]);
                    trapCount += rightMax - height[r];
                }
            }

            return trapCount;
        }
        static void Main(string[] args)
        {
            int[] a = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };// 6
            int[] b = new int[] { 4, 2, 0, 3, 2, 5 };//9
            Console.WriteLine(Program.Trap(a));
        }
    }
}
