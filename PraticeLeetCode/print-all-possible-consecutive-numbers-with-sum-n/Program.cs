using System;

namespace print_all_possible_consecutive_numbers_with_sum_n
{
    /*
     * Given a number N. The task is to print all possible consecutive numbers that add up to N.

        Examples : 

        Input: N = 100
        Output:
        9 10 11 12 13 14 15 16 
        18 19 20 21 22 
    */
    class Program
    {
        void printSums(int N)
        {
            int l = 1;
            int r = 1;
            int sum = 1;
            while (l <= N / 2)
            {
                if (sum < N)
                {
                    r++;
                    sum += r;
                }
                else if (sum > N)
                {
                    sum -= l;
                    l++;
                }
                else if (sum == N)
                {
                    for (int i = l; i <= r; ++i)
                    {
                        Console.Write(i + " ");
                    }

                    Console.WriteLine();
                    sum -= l;
                    l += 1;
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.printSums(100);
            Console.WriteLine();
        }
    }
}
