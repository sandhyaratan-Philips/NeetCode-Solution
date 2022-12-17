using System;
using System.Collections.Generic;

namespace Singl__Source_Shortest_Path_in_Undirected_Graph
{
    /*
        Using Bellman-Ford [ TC = O(VE) ]
        Using Dijkstra's Algorithm [ TC = O(E + Vlog(V)) ]
        Since the graph is Unweighted, we can solve this problem using Modified BFS. [ TC = O(V + E) ]
     */
    class Program
    {
        private List<int>[] adj;
        private int V;

        public Program(int v)
        {
            V = v;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        private void addEdges(int u, int v)
        {
            adj[u].Add(v);
        }

        void BFS(int src)
        {
            int[] dist = new int[V];
            bool[] visited = new bool[V];
            Queue<int> q = new Queue<int>();
            dist[0] = 0;
            visited[src] = true;
            q.Enqueue(src);

            while (q.Count > 0)
            {
                int u = q.Dequeue();

                foreach (var v in adj[u])
                {
                    if (!visited[v])
                    {
                        dist[v] = dist[u] + 1;
                        visited[v] = true;
                        q.Enqueue(v);
                    }
                }



            }

            for (int i = 0; i < V; i++)
            {
                Console.WriteLine("from " + i + "  " + dist[i]);
            }


        }

        static void Main(string[] args)
        {
            Program graph = new Program(4);

            graph.addEdges(0, 1);
            graph.addEdges(1, 2);
            graph.addEdges(2, 3);
            graph.addEdges(0, 2);
            graph.addEdges(1, 3);


            graph.BFS(0);




        }
    }
}
