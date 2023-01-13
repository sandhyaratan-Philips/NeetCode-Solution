using System;
using System.Collections.Generic;

namespace longest_path_with_different_adjacent_characters
{
    class Program
    {
        /*
         * You are given a tree (i.e. a connected, undirected graph that has no cycles) rooted at node 0 consisting of n nodes numbered from 0 to n - 1.
         * The tree is represented by a 0-indexed array parent of size n, where parent[i] is the parent of node i. Since node 0 is the root, parent[0] == -1.

            You are also given a string s of length n, where s[i] is the character assigned to node i.

            Return the length of the longest path in the tree such that no pair of adjacent nodes on the path have the same character assigned to them.
         Time: O(n)O(n)
        Space: O(n)O(n)
        */
        public int LongestPath(int[] parent, string s)
        {
            int n = parent.Length;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 1; i < n; i++)
            {
                graph[parent[i]].Add(i);
            }
            dfs(graph, 0, s);
            return ans;
        }
        int ans = 0;
        int dfs(List<int>[] graph, int u, string s)
        {
            int max1 = 0;
            int max2 = 0;
            foreach (var v in graph[u])
            {
                int res = dfs(graph, v, s);
                if (s[u] == s[v])
                    continue;
                if (res > max1)
                {
                    max2 = max1;
                    max1 = res;
                }
                else if (res > max2)
                {
                    max2 = res;
                }
            }
            ans = Math.Max(ans, 1 + max1 + max2);
            return 1 + max1;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("ans: " + program.LongestPath(new int[] { -1, 0, 0, 0 }, "aabc"));
        }
    }
}
