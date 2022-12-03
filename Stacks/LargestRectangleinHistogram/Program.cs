using System;
using System.Collections.Generic;

namespace LargestRectangleinHistogram
{
    class Height
    {
        public int index { get; set; }
        public int value { get; set; }
    }
    class Program
    {
        public int LargestRectangleArea(int[] heights)
        {
            int N = heights.Length;
            if (N == 1)
            {
                return heights[0];
            }
            int start = 0;


            Stack<Height> stack = new Stack<Height>(); //pair index n height
            int maxArea = 0;

            for (int i = 0; i < N; i++)
            {
                start = i;
                while (stack.Count > 0 && stack.Peek().value > heights[i])
                {
                    var h = stack.Pop();
                    maxArea = Math.Max(maxArea, h.value * (i - h.index));
                    start = h.index;
                }
                stack.Push(new Height { index = start, value = heights[i] });
            }

            while (stack.Count != 0)
            {
                var h = stack.Pop();
                maxArea = Math.Max(maxArea, h.value * (N - h.index));
                start++;
            }
            return maxArea;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
