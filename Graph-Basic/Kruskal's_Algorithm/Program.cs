using System;

namespace Kruskal_s_Algorithm
{

    /*
     *  Sort all the edges in non-decreasing order of their weight. 
        Pick the smallest edge. Check if it forms a cycle with the spanning tree formed so far. If cycle is not formed, include this edge. Else, discard it. 
        Repeat step#2 until there are (V-1) edges in the spanning tree
    time: O(E log E) or O(E log V)

    space: O(v+E)
     */
    class Program
    {

        class Edge : IComparable<Edge>
        {
            public int src, dest, weight;

            // Comparator function used for sorting edges
            // based on their weight
            public int CompareTo(Edge compareEdge)
            {
                return this.weight
                       - compareEdge.weight;
            }
        }
        public class subset
        {
            public int parent, rank;
        };

        int V, E; // V-> no. of vertices & E->no.of edges
        Edge[] edge; // collection of all edges

        // Creates a graph with V vertices and E edges
        Program(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }
        int find(subset[] subsets, int i)
        {
            if (subsets[i].parent != i)
                subsets[i].parent = find(subsets, subsets[i].parent);
            return subsets[i].parent;
        }

        void union(subset[] subsets, int x, int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);
            if (subsets[xroot].rank < subsets[yroot].rank)
            {
                subsets[xroot].parent = yroot;
            }
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        void KruskalMST()
        {
            subset[] subsets = new subset[V];

            Edge[] result = new Edge[V];
            int e = 0; // An index variable, used for result[]
            for (int i = 0; i < V; ++i)
                result[i] = new Edge();

            for (int i = 0; i < V; i++)
            {
                subsets[i] = new subset
                {
                    parent = i,
                    rank = 0
                };
            }

            Array.Sort(edge);

            for (int i = 0; i < E; i++)
            {
                int x = find(subsets, edge[i].src);
                int y = find(subsets, edge[i].dest);

                if (x != y)
                {
                    result[e++] = edge[i];
                    union(subsets, x, y);
                }

            }

            Console.WriteLine("Following are the edges in "
                          + "the constructed MST");

            int minimumCost = 0;
            for (int i = 0; i < e; ++i)
            {
                Console.WriteLine(result[i].src + " -- "
                                  + result[i].dest
                                  + " == " + result[i].weight);
                minimumCost += result[i].weight;
            }

            Console.WriteLine("Minimum Cost Spanning Tree: "
                              + minimumCost);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            /* Let us create following weighted graph
                10
            0--------1
            | \ |
        6| 5\ |15
            | \ |
            2--------3
                4 */
            int V = 4; // Number of vertices in graph
            int E = 5; // Number of edges in graph
            Program graph = new Program(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 10;

            // add edge 0-2
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 6;

            // add edge 0-3
            graph.edge[2].src = 0;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 5;

            // add edge 1-3
            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 15;

            // add edge 2-3
            graph.edge[4].src = 2;
            graph.edge[4].dest = 3;
            graph.edge[4].weight = 4;

            // Function call
            graph.KruskalMST();
        }
    }
}
