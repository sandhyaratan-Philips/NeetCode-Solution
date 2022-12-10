using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS
{
    class Program
    {
        //connected graph
        /*
        Yes you are correct. The outer loop iterates over all vertices at most once so is in O(|V|). The inner portion is the BFS for connected graphs, that is O(|V|+|E|).
        Then, overall it stays in O(|V|+|E|) since you look at every vertex and every edge at most O(1) times.

            Total time complexity: O(V + E).
         */
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

        private void DoBfs(int root)
        {
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;


            LinkedList<int> queue = new LinkedList<int>();

            visited[root] = true;
            queue.AddLast(root);

            while (queue.Any())
            {
                root = queue.First();
                Console.Write(root + " ");
                queue.RemoveFirst();

                LinkedList<int> list = edges[root];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            Program graph = new Program(4);

            graph.addEdges(0, 1);
            graph.addEdges(0, 2);
            graph.addEdges(1, 2);
            graph.addEdges(2, 0);
            graph.addEdges(2, 3);
            graph.addEdges(3, 3);

            graph.DoBfs(2);

        }
    }
}
