using System;
using System.Linq;

namespace KokoEatingBananas
{
    class Program
    {
        public static int MinEatingSpeed(int[] piles, int h)
        {
            int max = piles.Max();
            int left = 1, right = max;


            while (left < right)
            {
                // Get the middle index between left and right boundary indexes.
                // hourSpent stands for the total hour Koko spends.
                int middle = (left + right) / 2;
                double hourSpent = 0;

                // Iterate over the piles and calculate hourSpent.
                // We increase the hourSpent by ceil(pile / middle)
                foreach (int pile in piles)
                {
                    hourSpent += Math.Ceiling((double)pile / middle);
                }

                // Check if middle is a workable speed, and cut the search space by half.
                if (hourSpent <= h)
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }

            // Once the left and right boundaries coincide, we find the target value,
            // that is, the minimum workable eating speed.
            return right;
        }





        static void Main(string[] args)
        {
            int[] piles = { 3, 6, 7, 11 };
            int h = 8;
            Console.WriteLine(Program.MinEatingSpeed(piles, h));
        }
    }
}
