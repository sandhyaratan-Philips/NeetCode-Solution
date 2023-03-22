using System;

namespace best_time_to_buy_and_sell_stock
{
    /*
     * 121. Best Time to Buy and Sell Stock

        You are given an array prices where prices[i] is the price of a given stock on the ith day.

        You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

        Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

 

        Example 1:

        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
    */
    class Program
    {
        public int MaxProfit(int[] prices)
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
                    l = r;
                }
                r++;
            }
            return profit;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
