using System;

namespace union_by_rank
{
    /*
     * O(Log n) in worst case
     * attach smaller depth tree under the root of the deeper tree. This technique is called union by rank.
     * flatten the tree when find() is called
     */
    class Program
    {
        int E, V;
        public Edge[] edge;

        public class Edge
        {
            public int src, dest;
        };
        public Program(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];

            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        class subset
        {
            public int parent;
            public int rank;
        }

        int find(subset[] subsets, int i)
        {
            if (subsets[i].parent != i)
                subsets[i].parent
                = find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        void union(subset[] subsets, int x, int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);

            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[yroot].rank < subsets[xroot].rank)
                subsets[yroot].parent = xroot;
            else
            {
                subsets[xroot].parent = yroot;
                subsets[yroot].rank++;
            }
        }

        public int isCycle(Program graph)
        {
            subset[] subsets = new subset[V];
            for (int v = 0; v < V; v++)
            {
                subsets[v] = new subset();
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            for (int i = 0; i < E; i++)
            {
                int x = find(subsets, edge[i].src);
                int y = find(subsets, edge[i].dest);

                if (x == y)
                    return 1;

                union(subsets, x, y);
            }
            return 0;
        }
        static void Main(string[] args)
        {
            /* Let us create the following graph
            0
            | \
            |  \
            1---2 */
            int V = 3, E = 3;
            Program graph = new Program(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;

            // add edge 1-2
            graph.edge[1].src = 1;
            graph.edge[1].dest = 2;

            // add edge 0-2
            graph.edge[2].src = 0;
            graph.edge[2].dest = 2;

            if (graph.isCycle(graph) == 1)
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine(
                    "Graph doesn't contain cycle");
        }
    }
}
