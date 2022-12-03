using System;
using System.Collections.Generic;

namespace DailyTemperatures
{
    class Program
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            Stack<int> stack = new Stack<int>();
            int N = temperatures.Length;
            int[] result = new int[N];

            for (int i = 0; i < N; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    var lastDay = stack.Pop();
                    result[lastDay] = i - lastDay;
                }
                stack.Push(i);
            }
            return result;

        }

        static void Main(string[] args)
        {
            int[] temperatures = { 73, 74, 75, 71, 69, 72, 76, 73 };

            Program program = new Program();
            Console.WriteLine(program.DailyTemperatures(temperatures));
        }
    }
}
