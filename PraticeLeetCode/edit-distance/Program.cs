using System;

namespace edit_distance
{
    /*
     * 72. Edit Distance

        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

        You have the following three operations permitted on a word:

        Insert a character
        Delete a character
        Replace a character

        Example 1:

        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
    */
    class Program
    {
        public int MinDistance(string word1, string word2)
        {
            int[,] cache = new int[word1.Length + 1, word2.Length + 1];

            for (int i = 0; i < word1.Length + 1; i++)
            {
                for (int j = 0; j < word2.Length + 1; j++)
                {
                    cache[i, j] = int.MaxValue;
                }
            }

            for (int i = 0; i < word2.Length + 1; i++)
            {
                cache[word1.Length, i] = word2.Length - i;
            }
            for (int i = 0; i < word1.Length + 1; i++)
            {
                cache[i, word2.Length] = word1.Length - i;
            }

            for (int i = word1.Length - 1; i > -1; i--)
            {
                for (int j = word2.Length - 1; j > -1; j--)
                {
                    if (word1[i] == word2[j])
                        cache[i, j] = cache[i + 1, j + 1];
                    else
                        cache[i, j] = 1 + Math.Min(cache[i + 1, j], Math.Min(cache[i, j + 1], cache[i + 1, j + 1]));
                }
            }
            return cache[0, 0];
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MinDistance("horse", "ros"));
        }
    }
}
