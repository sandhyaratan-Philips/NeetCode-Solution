using System;

namespace Dijkstra_s
{
    class Program
    {
        /*
         * Bellman Ford algorithm helps us find the shortest path from a vertex to all other vertices of a weighted graph.

            It is similar to Dijkstra's algorithm but it can work with graphs in which edges can have negative weights.
            doesnt include all the vertices
            Time Complexity: O(V2)
            Auxiliary Space: O(V)
        */

        void dijkstra(int[][] graph, int src)
        {
            int vertices = graph.Length;

            bool[] visited = new bool[vertices];
            int[] distance = new int[vertices];

            for (int i = 0; i < vertices; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[src] = 0;

            for (int i = 0; i < vertices; i++)
            {
                // Update the distance between neighbouring vertex and source vertex
                int u = FindDistance(distance, visited, vertices);
                visited[u] = true;

                // Update all the neighbouring vertex distances
                for (int v = 0; v < vertices; v++)
                {
                    if (!visited[v] && graph[u][v] != 0 && (distance[u] + graph[u][v] < distance[v]))
                    {
                        distance[v] = distance[u] + graph[u][v];
                    }
                }
            }

            for (int i = 0; i < vertices; i++)
            {
                Console.WriteLine(string.Format("Distance from " + src + " to " + i + " is " + distance[i]));
            }

        }

        int FindDistance(int[] distance, bool[] visited, int vertices)
        {
            int minDistance = int.MaxValue;
            int minDistanceVertex = -1;

            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i] && distance[i] < minDistance)
                {
                    minDistance = distance[i];
                    minDistanceVertex = i;
                }
            }
            return minDistanceVertex;
        }

        static void Main(string[] args)
        {
            int[][] graph = new int[][] {new [] { 0, 0, 1, 2, 0, 0, 0 }, new []{ 0, 0, 2, 0, 0, 3, 0 },new [] { 1, 2, 0, 1, 3, 0, 0 },
        new []{ 2, 0, 1, 0, 0, 0, 1 },new [] { 0, 0, 3, 0, 0, 2, 0 },new [] { 0, 3, 0, 0, 2, 0, 1 },new [] { 0, 0, 0, 1, 0, 1, 0 } };
            Program T = new Program();
            T.dijkstra(graph, 0);
            //Console.WriteLine("Hello World!");
        }
    }
}
