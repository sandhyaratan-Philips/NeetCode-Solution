using System;

namespace Union_Find_hascycle
{
    class Program
    {
        /*
         *  Initially create a parent[] array to keep track of the subsets.
            Traverse through all the edges:
            Check to which subset each of the nodes belong to by finding the parent[] array till the node and the parent are the same.
            If the two nodes belong to the same subset then they belong to a cycle.
                Otherwise, perform union operation on those two subsets.
            If no cycle is found, return false.

        O(n)
         */

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
        int find(int[] parent, int i)
        {
            if (parent[i] == i)
                return i;
            return find(parent, parent[i]);
        }

        void Union(int[] parent, int x, int y)
        {
            parent[x] = y;
        }

        public int isCycle(Program graph)
        {
            int[] parent = new int[V];

            for (int i = 0; i < V; i++)
            {
                parent[i] = i;
            }

            for (int i = 0; i < E; i++)
            {
                int x = find(parent, edge[i].src);
                int y = find(parent, edge[i].dest);

                if (x == y)
                    return 1;

                Union(parent, x, y);
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
