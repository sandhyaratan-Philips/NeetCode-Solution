using System;
using System.Collections.Generic;

namespace ContainsDuplicate
{
    class Program
    {
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> number = new HashSet<int>();

            foreach (var item in nums)
            {
                if (number.Contains(item))
                {
                    return true;
                    break;
                }
                else
                {
                    number.Add(item);
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            Console.WriteLine(Program.ContainsDuplicate(arr));
        }
    }
}
