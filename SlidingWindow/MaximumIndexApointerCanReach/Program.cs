using System;

namespace MaximumIndexApointerCanReach
{
    //Maximum index a pointer can reach in N steps by avoiding a given index B
    class Program
    {
        public static void MaximumIndexApointeCanReach(int steps, int avoid)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int current = 0;
            int step = 1;
            while (steps >= step)
            {
                var a = current + step;
                if (a != avoid)
                {
                    current = a;
                }
                step++;
            }
            Console.WriteLine("max reach: " + current);
        }
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Program.MaximumIndexApointeCanReach(3, 1);
        }
    }
}
