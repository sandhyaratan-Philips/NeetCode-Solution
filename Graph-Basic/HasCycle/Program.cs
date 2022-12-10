using System;
using System.Collections.Generic;

namespace HasCycle
{
    class Program
    {
        LinkedList<int>[] edges;
        int _V = 0;
        public Program(int verticesNo)
        {
            _V = verticesNo;
            edges = new LinkedList<int>[verticesNo];
            for (int i = 0; i < verticesNo; i++)
            {
                edges[i] = new LinkedList<int>();
            }
        }

        private void addEdges(int u, int v)
        {
            edges[u].AddLast(v);
        }

        private void isCycle()
        {

            // Create a vector to store indegrees of all
            // vertices. Initialize all indegrees as 0.
            int[] in_degree = new int[this._V];

            // Traverse adjacency lists to fill indegrees
            // of vertices. This step takes O(V+E) time
            for (int u = 0; u < _V; u++)
            {
                foreach (int v in edges[u])
                    in_degree[v]++;
            }

            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Create an queue and enqueue all
            // vertices with indegree 0
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < _V; i++)
                if (in_degree[i] == 0)
                    q.Enqueue(i);

            // Initialize count of visited vertices
            int cnt = 0;

            // Create a vector to store result
            // (A topological ordering of the
            // vertices)
            List<int> top_order = new List<int>();

            // One by one dequeue vertices from
            // queue and enqueue adjacents if
            // indegree of adjacent becomes 0
            while (q.Count != 0)
            {

                // Extract front of queue (or perform
                // dequeue) and add it to topological
                // order
                int u = q.Peek();
                q.Dequeue();
                top_order.Add(u);

                // Iterate through all its neighbouring
                // nodes of dequeued node u and decrease
                // their in-degree by 1
                foreach (int itr in edges[u])
                    if (--in_degree[itr] == 0)
                        q.Enqueue(itr);

                cnt++;
            }

            // Check if there was a cycle
            if (cnt != this._V)
                Console.WriteLine("cycle");
            else
                Console.WriteLine("not cycle");
        }

        static void Main(string[] args)
        {
            Program graph = new Program(6);

            graph.addEdges(0, 1);
            graph.addEdges(1, 2);
            // graph.addEdges(2, 0);
            graph.addEdges(2, 3);
            graph.addEdges(3, 4);
            graph.addEdges(4, 5);

            graph.isCycle();

        }
    }
}
