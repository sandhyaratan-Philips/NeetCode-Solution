using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFleet
{
    class combine
    {
        public int position { get; set; }
        public int speed { get; set; }
    }
    class Program
    {

        public static int CarFleet(int target, int[] position, int[] speed)
        {
            if (position.Length == 1)
                return 1;
            int N = position.Length;
            List<combine> combinedList = new List<combine>();
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < N; i++)
            {
                combinedList.Add(new combine { position = position[i], speed = speed[i] });
            }

            List<combine> combinedList1 = combinedList.OrderByDescending(x => x.position).ToList();
            combinedList = combinedList1;
            for (int i = 0; i < N; i++)
            {
                float currentTime = (target - combinedList[i].position) / (float)combinedList[i].speed;

                if (stack.Count > 0 && currentTime <= stack.Peek())
                {
                    continue;
                }
                else
                {
                    stack.Push(currentTime);
                }
            }
            return stack.Count;

        }

        static void Main(string[] args)
        {
            int target = 12;
            int[] position = { 10, 8, 0, 5, 3 };
            int[] speed = { 2, 4, 1, 1, 3 };

            int target1 = 10;
            int[] position1 = { 6, 8 };
            int[] speed1 = { 3, 2 };

            Console.WriteLine(Program.CarFleet(target1, position1, speed1));
        }
    }
}
