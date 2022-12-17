using System;
using System.Collections.Generic;

namespace DFS
{
    /*
        Start by putting any one of the graph's vertices on top of a stack.
        Take the top item of the stack and add it to the visited list.
        Create a list of that vertex's adjacent nodes. Add the ones which aren't in the visited list to the top of the stack.
        Keep repeating steps 2 and 3 until the stack is empty.
     */
    class Program
    {
        LinkedList<int>[] adjLists;
        bool[] visited;

        Program(int vertices)
        {
            adjLists = new LinkedList<int>[vertices];
            visited = new bool[vertices];

            for (int i = 0; i < vertices; i++)
                adjLists[i] = new LinkedList<int>();
        }
        void AddEdge(int src, int dest)
        {
            adjLists[src].AddLast(dest);
        }

        public void DFS(int u)
        {
            visited[u] = true;
            Console.Write(u + " ");

            // Recur for all the vertices
            // adjacent to this vertex
            LinkedList<int> vList = adjLists[u];
            foreach (var n in vList)
            {
                if (!visited[n])
                    DFS(n);
            }
        }
        static void Main(string[] args)
        {
            Program g = new Program(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Depth First Traversal");
            g.DFS(2);
        }
    }
}
