using System;
using System.Linq;

namespace capacity_to_ship_packages_within_d_days
{
    /*
     * 1011. Capacity To Ship Packages Within D Days

        A conveyor belt has packages that must be shipped from one port to another within days days.

        The ith package on the conveyor belt has a weight of weights[i]. Each day, we load the ship with packages on the conveyor belt (in the order given by weights). We may not load more weight than the maximum weight capacity of the ship.

        Return the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within days days.

 

        Example 1:

        Input: weights = [1,2,3,4,5,6,7,8,9,10], days = 5
        Output: 15
    */
    class Program
    {
        public int ShipWithinDays(int[] weights, int days)
        {
            int l = weights.Max();
            int r = weights.Sum();
            int res = r;

            while (l <= r)
            {
                int capacity = (l + r) / 2;
                if (canShip(capacity, weights, days))
                {
                    res = Math.Min(res, capacity);
                    r = capacity - 1;
                }
                else
                {
                    l = capacity + 1;
                }

            }

            return res;
        }

        private bool canShip(int capacity, int[] weights, int days)
        {
            int ship = 1;
            int currentCapacity = capacity;
            foreach (var w in weights)
            {
                if (currentCapacity - w < 0)
                {
                    ship++;
                    currentCapacity = capacity;
                }
                currentCapacity -= w;
            }
            return ship <= days;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ShipWithinDays(new int[] { 3, 2, 2, 4, 1, 4 }, 3));
        }
    }
}
