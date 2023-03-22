using System;

namespace powx_n
{
    /*
     * 50. Pow(x, n)

        Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

 

        Example 1:

        Input: x = 2.00000, n = 10
        Output: 1024.00000
    */
    class Program
    {
        public double MyPow(double x, int n)
        {
            double res = helper(x, n);
            return n < 0 ? 1 / res : res;
        }
        double helper(double x, int n)
        {
            if (x == 0)
                return 0;
            if (n == 0)
                return 1;

            double res = helper(x, n / 2);
            res = res * res;

            return n % 2 != 0 ? res * x : res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MyPow(8.88023, 3));
        }
    }
}
