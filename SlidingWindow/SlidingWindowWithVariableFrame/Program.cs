using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingWindowWithVariableFrame
{
    class Program
    {
        //Longest substring with length k distinct characters
        public static int CHAR_RANGE = 128;
        public static char[] LongestSubstring(char[] arr, int k)
        {
            if (arr.Length <= k)
            {
                return arr;
            }
            else if (arr.Length == 0)
            {
                return null;
            }
            else
            {
                char[] longestSubstring = { };
                int low = 0;
                // stores the longest substring boundaries
                int end = 0, begin = 0;

                HashSet<char> window = new HashSet<char>();

                Dictionary<char, int> frequency = new Dictionary<char, int>();

                for (int high = 0; high < arr.Length; high++)
                {
                    window.Add(arr[high]);
                    if (frequency.ContainsKey(arr[high]))
                    {
                        frequency[arr[high]] = frequency[arr[high]]++;
                    }
                    else
                    {
                        frequency.Add(arr[high], 1);
                    }

                    if (window.Count > k)
                    {
                        if (--frequency[arr[low]] == 0)
                        {
                            window.Remove(arr[low]);
                        }
                        low++;
                    }
                    if (end - begin < high - low)
                    {
                        end = high;
                        begin = low;
                    }
                }
                return arr.Skip(begin).Take(end + 1 - begin).ToArray();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("LongestSubstring: " + new string(LongestSubstring(new char[] { 'A', 'A', 'A', 'H', 'H', 'I', 'B', 'C', 'B', 'C', 'B', 'C', 'B', 'C', 'B', 'C' }, 2)));
        }
    }
}
