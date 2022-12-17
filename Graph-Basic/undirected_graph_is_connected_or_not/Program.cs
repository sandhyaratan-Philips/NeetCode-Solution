using System;
using System.Collections.Generic;
using System.Linq;

namespace undirected_graph_is_connected_or_not
{
    class Program
    {
        LinkedList<int>[] adjLists;
        bool[] visited;

        Program(int vertices)
        {
            adjLists = new LinkedList<int>[vertices];


            for (int i = 0; i < vertices; i++)
                adjLists[i] = new LinkedList<int>();
        }
        void AddEdge(int src, int dest)
        {
            adjLists[src].AddLast(dest);
        }

        public void DFS(int u, LinkedList<int>[] adjLists, bool[] visited)
        {
            visited[u] = true;
            // Console.Write(u + " ");

            // Recur for all the vertices
            // adjacent to this vertex
            LinkedList<int> vList = adjLists[u];
            foreach (var n in vList)
            {
                if (!visited[n])
                    DFS(n, adjLists, visited);
            }
        }

        void isConnected(int vertices)
        {
            visited = new bool[vertices];
            DFS(0, adjLists, visited);

            int count = visited.Where(x => x == true).Count();

            if (visited.Count() == count)
            {
                Console.WriteLine("Given graph is connected");
            }
            else
            {
                Console.WriteLine("Given graph is not connected");
            }
        }
        static void Main(string[] args)
        {
            Program graph = new Program(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 3);
            graph.AddEdge(3, 2);


            graph.isConnected(5);

            graph.AddEdge(3, 4);
            graph.isConnected(5);

            Program g = new Program(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            //g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            // g.AddEdge(3, 3);
            g.isConnected(4);
        }
    }
}
