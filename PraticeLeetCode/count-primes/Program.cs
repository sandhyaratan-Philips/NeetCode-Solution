using System;

namespace count_primes
{
    /*
     * 204. Count Primes

        Given an integer n, return the number of prime numbers that are strictly less than n.

 

        Example 1:

        Input: n = 10
        Output: 4
        Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
    */
    class Program
    {
        public int CountPrimes(int n)
        {
            if (n <= 2)
                return 0;
            bool[] isPrime = sieveEratosthenes(n);
            int ans = 0;
            foreach (bool p in isPrime)
            {
                if (p)
                    ++ans;
            }
            return ans;
        }

        private bool[] sieveEratosthenes(int n)
        {
            bool[] isPrime = new bool[n];
            //bool[] isPrime = Enumerable.Repeat(true, n).ToArray();
            Array.Fill(isPrime, true);
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i * i < n; ++i)
                if (isPrime[i])
                    for (int j = i * i; j < n; j += i)
                        isPrime[j] = false;
            return isPrime;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CountPrimes(10));
        }
    }
}
