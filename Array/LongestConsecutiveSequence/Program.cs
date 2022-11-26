using System;
using System.Collections.Generic;

namespace LongestConsecutiveSequence
{
    class Program
    {
        public static int LongestConsecutive(int[] nums)
        {
            int LongestSequence = 0;
            HashSet<int> numbers = new HashSet<int>(nums);

            foreach (var item in numbers)
            {
                if (numbers.Contains(item + 1))
                {
                    int length = 0;
                    while (numbers.Contains(item + length))
                        length++;

                    LongestSequence = Math.Max(LongestSequence, length);
                }
            }
            return LongestSequence;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Program.LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }));
        }
    }
}
