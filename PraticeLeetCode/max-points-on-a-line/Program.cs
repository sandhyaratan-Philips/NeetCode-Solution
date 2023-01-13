using System;
using System.Collections.Generic;

namespace max_points_on_a_line
{
    class Program
    {
        /*
         * Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.
         * slope = (points[y2]-points[y1]) / (points[x2]-points[x1]);
         * 
         * Time complexity O(n^2)
            Space complexity O(n^2)
         */

        public int MaxPoints(int[][] points)
        {
            int l = points.Length;
            if (l <= 2)
                return l;
            Dictionary<float, int> valuePairs = null;
            int ans = 0;

            for (int i = 0; i < l; i++)
            {
                valuePairs = new Dictionary<float, int>();
                for (int j = i + 1; j < l; j++)
                {
                    float slope = 0;
                    if (points[j][0] == points[i][0])
                        slope = float.PositiveInfinity;
                    else
                        slope = (points[j][1] - points[i][1]) / (points[j][0] - points[i][0]);

                    if (!valuePairs.ContainsKey(slope))
                        valuePairs.Add(slope, 1);

                    valuePairs[slope] += 1;

                    ans = Math.Max(ans, valuePairs[slope]);
                }
            }
            return ans + 1; //as j started from i+1 we need to consider the starting point. so + 1
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.MaxPoints(new int[][] { new int[] { 0, 0 }, new int[] { 4, 5 }, new int[] { 7, 8 }, new int[] { 8, 9 }, new int[] { 5, 6 }, new int[] { 3, 4 }, new int[] { 1, 1 } }); // ans : 7


            Console.WriteLine("Hello World!");
        }
    }
}
