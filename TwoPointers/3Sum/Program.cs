using System;
using System.Collections.Generic;

namespace _3Sum
{
    class Program
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums); //O(nlogn)

            int l = 0;
            int N = nums.Length;
            int r = N - 1;

            IList<IList<int>> ans = new List<IList<int>>();

            for (int i = 0; i < N - 1; i++) //O(n^2)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                if (nums[i] <= 0)
                {
                    l = i + 1;
                    r = N - 1;
                    while (l < r)
                    {
                        if (nums[l] + nums[r] + nums[i] > 0)
                        {
                            r--;
                        }
                        else if (nums[l] + nums[r] + nums[i] < 0)
                        {
                            l++;
                        }
                        else if (nums[l] + nums[r] + nums[i] == 0)
                        {
                            ans.Add(new List<int> { nums[i], nums[l], nums[r] });
                            l++;
                            while (nums[l] == nums[l - 1] && l < r)
                            {
                                l++;
                            }
                        }
                    }
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            int[] n = new int[] { -1, 0, 1, 2, -1, -4 };
            int[] k = new int[] { 0, 0, 0, 0 };
            int[] h = new int[] { -2, 0, 1, 1, 2 };
            Console.WriteLine(Program.ThreeSum(h));//[[-1,-1,2],[-1,0,1]]   O(n^2)
        }
    }
}
