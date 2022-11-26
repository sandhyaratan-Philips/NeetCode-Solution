using System;

namespace PourWater
{
    class Program
    {

        public static int[] PourWater(int[] heights, int volume, int k)
        {
            int N = heights.Length;
            int l = 0;
            int r = N - 1;
            int currentHeight = heights[k];
            int leftHeight = 0;
            int rightHeight = 0;

            for (int j = 0; j < volume; j++)
            {
                leftHeight = k;
                currentHeight = heights[k];
                for (int i = k; i >= 0; i--)
                {
                    var newH = heights[i];
                    if (newH > currentHeight)
                    {
                        break;
                    }
                    if (newH < currentHeight)
                    {
                        leftHeight = i;
                        currentHeight = newH;
                    }
                }
                if (leftHeight < k)
                {
                    heights[leftHeight]++;
                }
                else
                {
                    rightHeight = k;
                    currentHeight = heights[k];
                    for (int i = k; i < N; i++)
                    {
                        var newH = heights[i];
                        if (newH > currentHeight)
                        {
                            break;
                        }
                        if (newH < currentHeight)
                        {
                            rightHeight = i;
                            currentHeight = newH;
                        }
                    }
                    if (rightHeight > k)
                    {
                        heights[rightHeight]++;
                    }
                    else
                    {
                        heights[k]++;
                    }
                }
            }

            return heights;
        }
        static void Main(string[] args)
        {
            int[] a = { 2, 1, 1, 2, 1, 2, 2 }; //v=4 k=3
            int[] b = { 1, 2, 3, 4 }; //v=2 k=2
            Console.WriteLine(Program.PourWater(b, 2, 2));
            //Console.WriteLine(Program.PourWater(a, 4, 3));
        }
    }
}
