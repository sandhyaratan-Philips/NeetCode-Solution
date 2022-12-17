using System;

namespace Bellman_Ford
{
    /*
     *  Step 1: Make a list of all the graph's edges. This is simple if an adjacency list represents the graph.

        Step 2: "V - 1" is used to calculate the number of iterations. Because the shortest distance to an edge can be adjusted V - 1 time at most, the number of iterations will increase the same number of vertices.

        Step 3: Begin with an arbitrary vertex and a minimum distance of zero. Because you are exaggerating the actual distances, all other nodes should be assigned infinity.

        For each edge u-v, relax the path lengths for the vertices:

        If distance[v] is greater than distance[u] + edge weight uv, then

        distance[v] = distance[u] + edge weight uv

        Step 4:If the new distance is less than the previous one, update the distance for each Edge in each iteration. The distance to each node is the total distance from the starting node to this specific node.

        Step 5: To ensure that all possible paths are considered, you must consider alliterations. You will end up with the shortest distance if you do this.
                https://www.simplilearn.com/tutorials/data-structure-tutorial/bellman-ford-algorithm

    Time Complexity:  O(V * E)
    Auxiliary Space: O(E)
    */
    class Program
    {
        class Edge
        {
            public int src, dest, weight;
            public Edge() { src = dest = weight = 0; }
        };

        int V, E;
        Edge[] edge;
        public Program(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[e];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        void BellmanFord(Program graph, int src)
        {
            int[] distance = new int[V];
            for (int i = 0; i < V; ++i)
                distance[i] = int.MaxValue;
            distance[src] = 0;

            // Step 2: Relax all edges |V| - 1 times. A simple
            // shortest path from src to any other vertex can
            // have at-most |V| - 1 edges
            for (int i = 1; i < V; ++i)
            {
                for (int j = 0; j < E; ++j)
                {
                    int u = graph.edge[j].src;
                    int v = graph.edge[j].dest;
                    int weight = graph.edge[j].weight;
                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                        distance[v] = distance[u] + weight;
                }
            }

            // Step 3: check for negative-weight cycles. The
            // above step guarantees shortest distances if graph
            // doesn't contain negative weight cycle. If we get
            // a shorter path, then there is a cycle.


            for (int j = 0; j < E; ++j)
            {
                int u = graph.edge[j].src;
                int v = graph.edge[j].dest;
                int weight = graph.edge[j].weight;
                if (distance[u] != int.MaxValue
                    && distance[u] + weight < distance[v])
                {
                    Console.WriteLine(
                        "Graph contains negative weight cycle");
                    return;
                }
            }

            Console.WriteLine("Vertex Distance from Source");
            for (int i = 0; i < V; ++i)
                Console.WriteLine(i + "\t\t" + distance[i]);
        }

        static void Main(string[] args)
        {
            int V = 5; // Number of vertices in graph
            int E = 8; // Number of edges in graph

            Program graph = new Program(V, E);

            // add edge 0-1 (or A-B in above figure)
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = -1;

            // add edge 0-2 (or A-C in above figure)
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 4;

            // add edge 1-2 (or B-C in above figure)
            graph.edge[2].src = 1;
            graph.edge[2].dest = 2;
            graph.edge[2].weight = 3;

            // add edge 1-3 (or B-D in above figure)
            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 2;

            // add edge 1-4 (or B-E in above figure)
            graph.edge[4].src = 1;
            graph.edge[4].dest = 4;
            graph.edge[4].weight = 2;

            // add edge 3-2 (or D-C in above figure)
            graph.edge[5].src = 3;
            graph.edge[5].dest = 2;
            graph.edge[5].weight = 5;

            // add edge 3-1 (or D-B in above figure)
            graph.edge[6].src = 3;
            graph.edge[6].dest = 1;
            graph.edge[6].weight = 1;

            // add edge 4-3 (or E-D in above figure)
            graph.edge[7].src = 4;
            graph.edge[7].dest = 3;
            graph.edge[7].weight = -3;

            // Function call
            graph.BellmanFord(graph, 0);
        }
    }
}
