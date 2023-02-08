using System;
using System.Collections.Generic;

namespace fruit_into_baskets
{
    /*
     * 904. Fruit Into Baskets
     You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.

        You want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:

        You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.
        Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right. The picked fruits must fit in one of your baskets.
        Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
        Given the integer array fruits, return the maximum number of fruits you can pick.

 

        Example 1:

        Input: fruits = [1,2,1]
        Output: 3
        Explanation: We can pick from all 3 trees.
     */
    class Program
    {
        public int TotalFruit(int[] fruits)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();

            int l = 0;
            int res = 0; int total = 0;

            for (int r = 0; r < fruits.Length; r++)
            {
                if (pairs.ContainsKey(fruits[r]))
                    pairs[fruits[r]]++;
                else
                    pairs.Add(fruits[r], 1);
                total++;
                while (pairs.Count > 2)
                {
                    pairs[fruits[l]]--;
                    total--;
                    if (pairs[fruits[l]] == 0)
                        pairs.Remove(fruits[l]);
                    l++;
                }
                res = Math.Max(res, total);
            }

            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.TotalFruit(new int[] { 1, 2, 3, 2, 2 }));
        }
    }
}
