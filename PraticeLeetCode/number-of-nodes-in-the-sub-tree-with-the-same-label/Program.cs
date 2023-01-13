using System;
using System.Collections.Generic;

namespace number_of_nodes_in_the_sub_tree_with_the_same_label
{
    class Program
    {
        /*
         * You are given a tree (i.e. a connected, undirected graph that has no cycles) consisting of n nodes numbered from 0 to n - 1 and exactly n - 1 edges. 
         * The root of the tree is the node 0, and each node of the tree has a label which is a lower-case character given in the string labels
         * (i.e. The node with the number i has the label labels[i]).

            The edges array is given on the form edges[i] = [ai, bi], which means there is an edge between nodes ai and bi in the tree.

            Return an array of size n where ans[i] is the number of nodes in the subtree of the ith node which have the same label as node i.

            A subtree of a tree T is the tree consisting of a node in T and all of its descendant nodes.

        Time: O(n)O(n)
        Space: O(n)O(n)
        */

        public int[] CountSubTrees(int n, int[][] edges, string labels)
        {
            int[] ans = new int[n];
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

            dfs(graph, 0, -1, labels, ans);
            return ans;
        }

        int[] dfs(List<int>[] graph, int u, int parent, string labels, int[] ans)
        {
            int[] count = new int[26];
            // Count of letters down from this u
            //count will have the count of same labels in a sub tree which is returned to childCount

            foreach (var v in graph[u])
            {
                if (v == parent)
                    continue;
                int[] childCount = dfs(graph, v, u, labels, ans);
                for (int i = 0; i < 26; i++)
                {
                    count[i] += childCount[i];
                }
            }
            ans[u] = ++count[labels[u] - 'a'];  // The u itself as forloop calcutate the subtree
            return count;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CountSubTrees(4, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 0, 3 } }, "bbbb");
            Console.WriteLine("Hello World!");
        }
    }
}
