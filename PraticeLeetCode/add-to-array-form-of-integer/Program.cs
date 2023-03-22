using System;
using System.Collections.Generic;
using System.Linq;

namespace add_to_array_form_of_integer
{
    /*
     * 989. Add to Array-Form of Integer

        The array-form of an integer num is an array representing its digits in left to right order.

        For example, for num = 1321, the array form is [1,3,2,1].
        Given num, the array-form of an integer, and an integer k, return the array-form of the integer num + k.

 

        Example 1:

        Input: num = [1,2,0,0], k = 34
        Output: [1,2,3,4]
        Explanation: 1200 + 34 = 1234
    */
    class Program
    {
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            IList<int> ans = new List<int>();
            int val = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                val += num[i] + k % 10;
                ans.Add(val % 10);
                k /= 10;
                val /= 10;
            }

            while (k > 0 || val > 0)
            {
                val += k % 10;
                ans.Add(val % 10);
                k /= 10;
                val /= 10;
            }
            var asd = ans.Reverse<int>().ToList();
            return asd;
        }
        public int pickingNumbers(List<int> a)
        {
            a.Sort();
            int count = 0;
            int l = 0;
            for (int r = 1; r < a.Count; r++)
            {
                if (Math.Abs(a[l] - a[r]) <= 1)
                {
                    count = Math.Max(count, r - l + 1);
                }
                else
                {
                    l++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //Console.WriteLine(program.AddToArrayForm(new int[] { 7 }, 993));

            List<int> a = new List<int>();

            Console.WriteLine(program.pickingNumbers(new List<int> { 1, 2, 2, 3, 1, 2 }));

        }
    }
}
