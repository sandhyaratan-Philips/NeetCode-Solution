using System;

namespace flip_string_to_monotone_increasing
{
    /*
     * A binary string is monotone increasing if it consists of some number of 0's (possibly none), followed by some number of 1's (also possibly none).

        You are given a binary string s. You can flip s[i] changing it from 0 to 1 or from 1 to 0.

        Return the minimum number of flips to make s monotone increasing.
    */
    class Program
    {
        public int MinFlipsMonoIncr(string s)
        {
            int ones = 0;
            int flips = 0;
            foreach (var charactor in s)
            {
                if (charactor == '1')
                {
                    ones++;
                }
                else
                {
                    flips++;
                }
                flips = Math.Min(ones, flips); ;
            }
            return flips;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("steps: " + program.MinFlipsMonoIncr("0101100011"));
        }
    }
}
