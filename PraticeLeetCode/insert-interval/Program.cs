using System;
using System.Collections.Generic;

namespace insert_interval
{
    /*
     * You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the 
     * ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents 
     * the start and end of another interval.

        Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals
        (merge overlapping intervals if necessary).

        Return intervals after the insertion.
    Time: O(n)
    space: O(n)
    */
    class Program
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int n = intervals.Length;

            List<int[]> res = new List<int[]>();

            int i = 0;

            while (i < n && intervals[i][1] < newInterval[0])
            {
                res.Add(intervals[i++]);
            }

            while (i < n && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                ++i;
            }
            res.Add(newInterval);

            while (i < n)
                res.Add(intervals[i++]);

            return res.ToArray();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Insert(new int[][] { new[] { 1, 3 }, new[] { 6, 9 } }, new int[] { 2, 5 });
            Console.WriteLine("Hello World!");
        }
    }
}
