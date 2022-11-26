using System;

namespace ContainerWithMostWater
{
    class Program
    {
        public static int MaxArea(int[] height)
        {
            int l = 0;
            int N = height.Length;
            int r = N - 1;
            int area = Math.Min(height[0], height[N - 1]) * (N - 1);

            while (l < r)
            {
                if (height[l] < height[r] && l < r)
                {
                    l++;
                }
                else
                {
                    r--;
                }

                area = Math.Max(area, (Math.Min(height[l], height[r]) * (r - l)));
            }

            return area;
        }
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int[] b = new int[] { 1, 1 };
            Console.WriteLine(Program.MaxArea(b));
        }
    }
}
