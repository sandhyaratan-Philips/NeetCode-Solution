using System;

namespace candy
{
    class Program
    {
        /*
         * There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.

            You are giving candies to these children subjected to the following requirements:

            Each child must have at least one candy.
            Children with a higher rating get more candies than their neighbors.
            Return the minimum number of candies you need to have to distribute the candies to the children.
        */
        public int Candy(int[] ratings)
        {
            if (ratings.Length == 0)
                return 0;

            int[] left = new int[ratings.Length];
            int[] right = new int[ratings.Length];

            for (int i = 0; i < ratings.Length; i++)
            {
                left[i] = 1;
                right[i] = 1;
            }

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    left[i] = left[i - 1] + 1;
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    right[i] = right[i + 1] + 1;
            }
            int sum = 0;
            for (int i = 0; i < ratings.Length; i++)
            {
                sum += Math.Max(left[i], right[i]);
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("candy: " + program.Candy(new int[] { 1, 0, 2 }));
        }
    }
}
