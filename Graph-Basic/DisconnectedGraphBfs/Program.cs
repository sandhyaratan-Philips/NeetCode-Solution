using System;
using System.Collections.Generic;
using System.Linq;

namespace DisconnectedGraphBfs
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

        private void DoBfs(int root, List<Boolean> visited)
        {
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

        private void BfsHelper()
        {
            List<Boolean> visited = new List<Boolean>();
            for (int i = 0; i < _V; i++)
                visited.Add(false);

            for (int i = 0; i < _V; i++)
            {
                // Checking whether the node is visited or not
                if (!visited[i])
                {
                    DoBfs(i, visited);
                }
            }
        }

        static void Main(string[] args)
        {
            Program graph = new Program(5);

            graph.addEdges(0, 4);
            graph.addEdges(1, 2);
            graph.addEdges(1, 3);
            graph.addEdges(1, 4);
            graph.addEdges(2, 3);
            graph.addEdges(3, 4);

            graph.BfsHelper();
        }
    }
}
