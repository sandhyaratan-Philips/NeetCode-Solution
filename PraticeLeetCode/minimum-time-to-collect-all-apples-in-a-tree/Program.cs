using System;
using System.Collections.Generic;

namespace minimum_time_to_collect_all_apples_in_a_tree
{
    class Program
    {
        /*
         * Given an undirected tree consisting of n vertices numbered from 0 to n-1, which has some apples in their vertices.
         * You spend 1 second to walk over one edge of the tree.
         * Return the minimum time in seconds you have to spend to collect all apples in the tree, starting at vertex 0 and coming back to this vertex.

            The edges of the undirected tree are given in the array edges, where edges[i] = [ai, bi] means that exists an edge connecting the vertices ai and bi.
        Additionally, there is a boolean array hasApple, where hasApple[i] = true means that vertex i has an apple; otherwise, it does not have any apple.
        Time: O(n)O(n)
        Space: O(n)O(n)
        */

        public int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            List<int>[] graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                graph[u].Add(v);
                graph[v].Add(u);
            }
            return dfs(graph, 0, new bool[n], hasApple);
        }

        private int dfs(List<int>[] graph, int u, bool[] seen, IList<bool> hasApple)
        {
            seen[u] = true;

            int totalCost = 0;

            foreach (var v in graph[u])
            {
                if (seen[v])
                    continue;
                int cost = dfs(graph, v, seen, hasApple);
                if (cost > 0 || hasApple[v])
                    totalCost += cost + 2; //2 because we will go to the node =1 and come back to parent=1 therfore 1+1=2
            }

            return totalCost;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("time: " + program.MinTime(7, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 4 }, new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 2, 6 } }, new bool[] { false, false, true, false, true, true, false }));



        }
    }
}
