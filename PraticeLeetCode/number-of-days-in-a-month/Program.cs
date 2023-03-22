using System;

namespace number_of_days_in_a_month
{
    /*
     * 1118. Number of Days in a Month

        Given a year year and a month month, return the number of days of that month.

 

        Example 1:

        Input: year = 1992, month = 7
        Output: 31
    */
    class Program
    {
        public int NumberOfDays(int year, int month)
        {

            string date1 = null;
            string date2 = null;

            int diff = Math.Abs((int)(Convert.ToDateTime(date1) - Convert.ToDateTime(date2)).TotalDays);

            return DateTime.DaysInMonth(year, month);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.NumberOfDays(2000, 2));
        }
    }
}
