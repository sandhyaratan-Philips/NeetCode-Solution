using System;
using System.Linq;

namespace gas_station
{
    class Program
    {
        /*
         * There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].

            You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station. 
        You begin the journey with an empty tank at one of the gas stations.

            Given two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction,
        otherwise return -1. If there exists a solution, it is guaranteed to be unique


        sol:
        the sum(gas) should always be greater than equal to the sum(cost) in order to complete the circle.

        this will be our base case and then:
        for total += gas[i]-cost[i]
        keep changing the start point if total goes below 0.

        T= O(n)
        S=O(1)

        */

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Sum() < cost.Sum())
                return -1;

            int total = 0; int start = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                total += gas[i] - cost[i];
                if (total < 0)
                {
                    total = 0;
                    start = i + 1;
                }
            }
            return start;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("index: " + program.CanCompleteCircuit(new int[] { 3, 1, 1 }, new int[] { 1, 2, 2 }));
        }
    }
}
