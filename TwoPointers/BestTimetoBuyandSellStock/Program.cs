using System;

namespace BestTimetoBuyandSellStock
{
    class Program
    {
        public static int MaxProfit(int[] prices)
        {
            int l = 0;
            int r = l + 1;
            int profit = 0;

            while (r < prices.Length)
            {
                if (prices[r] > prices[l])
                {
                    profit = Math.Max(profit, prices[r] - prices[l]);
                }
                else
                {
                    l = r; //found lowest at r
                }
                r++;
            }
            return profit;
        }
        static void Main(string[] args)
        {
            int[] a = { 7, 1, 5, 3, 6, 4 }; //5
            int[] b = { 1, 2 }; //1
            int[] c = { 2, 1, 2, 1, 0, 1, 2 }; //2
            Console.WriteLine(Program.MaxProfit(a));
        }
    }
}
