using System;
using System.Collections.Generic;
using System.Linq;

namespace number_of_good_paths
{
    /*
    There is a tree(i.e.a connected, undirected graph with no cycles) consisting of n nodes numbered from 0 to n - 1 and exactly n - 1 edges.

        You are given a 0-indexed integer array vals of length n where vals[i] denotes the value of the ith node.You are also given a 2D integer array edges where
            edges[i] = [ai, bi] denotes that there exists an undirected edge connecting nodes ai and bi.


        A good path is a simple path that satisfies the following conditions:


        The starting node and the ending node have the same value.
        All nodes between the starting node and the ending node have values less than or equal to the starting node (i.e.the starting node's value should be the maximum 
        value along the path).
        Return the number of distinct good paths.

        Note that a path and its reverse are counted as the same path.For example, 0 -> 1 is considered to be the same as 1 -> 0. A single node is also considered as a valid path.


    Time: O(nlogn)
    space: O(n)

    */
    class UnionFind
    {
        public UnionFind(int n)
        {
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; ++i)
                parent[i] = i;
        }

        public void unionByRank(int u, int v)
        {
            int i = find(u);
            int j = find(v);
            if (i == j)
                return;
            if (rank[i] < rank[j])
            {
                parent[i] = parent[j];
            }
            else if (rank[i] > rank[j])
            {
                parent[j] = parent[i];
            }
            else
            {
                parent[i] = parent[j];
                ++rank[j];
            }
        }

        public int find(int u)
        {
            return parent[u] == u ? u : (parent[u] = find(parent[u]));
        }

        private int[] parent;
        private int[] rank;
    }

    class Program
    {
        public int NumberOfGoodPaths(int[] vals, int[][] edges)
        {
            int n = vals.Length;
            int ans = n;
            UnionFind uf = new UnionFind(n);
            List<int>[] graph = new List<int>[n];
            Dictionary<int, List<int>> valToNodes = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; ++i)
                graph[i] = new List<int>();

            foreach (int[] edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                if (vals[v] <= vals[u])
                    graph[u].Add(v);
                if (vals[u] <= vals[v])
                    graph[v].Add(u);
            }

            for (int i = 0; i < vals.Length; ++i)
            {
                if (!valToNodes.ContainsKey(vals[i]))
                    valToNodes.Add(vals[i], new List<int>());
                valToNodes[vals[i]].Add(i);
            }

            var arr = valToNodes.ToList();
            var sortedDic = arr.OrderBy(x => x.Key);

            foreach (var entry in sortedDic)
            {
                int val = entry.Key;
                List<int> nodes = entry.Value;
                foreach (int u in nodes)
                    foreach (int v in graph[u])
                        uf.unionByRank(u, v);
                Dictionary<int, int> rootCount = new Dictionary<int, int>();
                foreach (int u in nodes)
                {
                    var asd = uf.find(u);
                    if (!rootCount.ContainsKey(asd))
                        rootCount.Add(asd, 0);
                    rootCount[asd] += 1;
                }
                foreach (int count in rootCount.Values)
                    ans += count * (count - 1) / 2; //so that the single elements doesn't get added again
            }

            return ans;
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("paths: " + program.NumberOfGoodPaths(new int[] { 1, 3, 2, 1, 3 }, new int[][] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 3 }, new[] { 2, 4 } }));
        }
    }
}
