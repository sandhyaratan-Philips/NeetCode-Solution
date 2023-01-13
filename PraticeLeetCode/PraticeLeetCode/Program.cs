using System;

namespace PraticeLeetCode
{
    class Program
    {
        /*
         * There are some spherical balloons taped onto a flat wall that represents the XY-plane.
         * The balloons are represented as a 2D integer array points where points[i] = [xstart, xend] 
         * denotes a balloon whose horizontal diameter stretches between xstart and xend. You do not know the exact y-coordinates of the balloons.
         */

        public int FindMinArrowShots(int[][] points)
        {
            Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));

            int arrow = 1;
            int end = points[0][1];
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i][0] > end)
                {
                    arrow++;
                    end = points[i][1];
                }
            }
            return arrow;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("arrows: " + program.FindMinArrowShots(new int[][] { new[] { 10, 16 }, new[] { 2, 8 }, new[] { 1, 6 }, new[] { 7, 12 } }));
        }
    }
}
