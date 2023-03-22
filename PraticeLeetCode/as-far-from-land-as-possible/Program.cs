using System;
using System.Collections;

namespace as_far_from_land_as_possible
{
    /*
     * Given an n x n grid containing only values 0 and 1, where 0 represents water and 1 represents land, find a water cell such that its distance to the nearest land cell is maximized, and return the distance. If no land or water exists in the grid, return -1.

        The distance used in this problem is the Manhattan distance: the distance between two cells (x0, y0) and (x1, y1) is |x0 - x1| + |y0 - y1|.

 

        Example 1:


        Input: grid = [[1,0,1],[0,0,0],[1,0,1]]
        Output: 2
        Explanation: The cell (1, 1) is as far as possible from all the land with distance 2.
    */
    class Program
    {
        class Grid
        {
            public int r { get; set; }
            public int c { get; set; }
            public Grid(int R, int C)
            {
                r = R;
                c = C;
            }
        }
        public int MaxDistance(int[][] grid)
        {
            int N = grid.Length;
            Queue q = new Queue();

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (!q.Contains(grid[r][c]))
                        q.Enqueue(new Grid(r, c));
                }
            }
            int res = -1;


            while (q.Count >= 0)
            {
                Grid rc = (Grid)q.Dequeue();

                //yet to complete
                res = grid[rc.r][rc.c];
            }
            return res > 1 ? res - 1 : -1;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaxDistance(new int[][] { new[] { 1, 0, 1 }, new[] { 0, 0, 0 }, new[] { 1, 0, 1 } }));
        }
    }
}
