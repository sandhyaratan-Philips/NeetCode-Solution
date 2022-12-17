using System;
using System.Collections.Generic;

namespace shortest_paths_between_given_source_and_destination_in_an_undirected_graph
{
    /*
        Start BFS traversal from source vertex.
        While doing BFS, store the shortest distance to each of the other nodes and also maintain a parent vector for each of the nodes.
        Make the parent of source node as “-1”. For each node, it will store all the parents for which it has the shortest distance from the source node.
        Recover all the paths using parent array. At any instant, we will push one vertex in the path array and then call for all its parents.
        If we encounter “-1” in the above steps, then it means a path has been found and can be stored in the paths array.
        
        Time Complexity: O(V + E)
        Auxiliary Space: O(V)
     */
    class Program
    {
        // Function to form edge between
        // two vertices src and dest
        static void add_edge(List<List<int>> adj, int src, int dest)
        {
            adj[src].Add(dest);
            adj[dest].Add(src);
        }

        // Function which finds all the paths
        // and stores it in paths array
        static void find_paths(List<List<int>> paths, List<int> path,
                               List<List<int>> parent, int n, int u)
        {
            // Base Case
            if (u == -1)
            {
                paths.Add(new List<int>(path));
                return;
            }

            // Loop for all the parents
            // of the given vertex
            foreach (int par in parent[u])
            {

                // Insert the current
                // vertex in path
                path.Add(u);

                // Recursive call for its parent
                find_paths(paths, path, parent, n, par);

                // Remove the current vertex
                path.RemoveAt(path.Count - 1);
            }
        }

        // Function which performs bfs
        // from the given source vertex
        static void bfs(List<List<int>> adj, List<List<int>> parent,
                        int n, int start)
        {

            // dist will contain shortest distance
            // from start to every other vertex
            int[] dist = new int[n];
            for (int i = 0; i < n; i++)
                dist[i] = int.MaxValue;

            Queue<int> q = new Queue<int>();

            // Insert source vertex in queue and make
            // its parent -1 and distance 0
            q.Enqueue(start);

            parent[start].Clear();
            parent[start].Add(-1);

            dist[start] = 0;

            // Until Queue is empty
            while (q.Count != 0)
            {
                int u = q.Dequeue();

                foreach (int v in adj[u])
                {
                    if (dist[v] > dist[u] + 1)
                    {

                        // A shorter distance is found
                        // So erase all the previous parents
                        // and insert new parent u in parent[v]
                        dist[v] = dist[u] + 1;
                        q.Enqueue(v);
                        parent[v].Clear();
                        parent[v].Add(u);
                    }
                    else if (dist[v] == dist[u] + 1)
                    {

                        // Another candidate parent for
                        // shortes path found
                        parent[v].Add(u);
                    }
                }
            }
        }

        // Function which prints all the paths
        // from start to end
        static void print_paths(List<List<int>> adj, int n, int start, int end)
        {
            List<List<int>> paths = new List<List<int>>();
            List<int> path = new List<int>();
            List<List<int>> parent = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                parent.Add(new List<int>());
            }

            // Function call to bfs
            bfs(adj, parent, n, start);

            // Function call to find_paths
            find_paths(paths, path, parent, n, end);

            foreach (List<int> v in paths)
            {

                // Since paths contain each
                // path in reverse order,
                // so reverse it
                v.Reverse();

                // Print node for the current path
                foreach (int u in v)
                    Console.Write(u + " ");

                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n = 6;

            // array of vectors is used
            // to store the graph
            // in the form of an adjacency list
            List<List<int>> adj = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<int>());
            }

            // Given Graph
            add_edge(adj, 0, 1);
            add_edge(adj, 0, 2);
            add_edge(adj, 1, 3);
            add_edge(adj, 1, 4);
            add_edge(adj, 2, 3);
            add_edge(adj, 3, 5);
            add_edge(adj, 4, 5);

            // Given source and destination
            int src = 0;
            int dest = n - 1;

            // Function Call
            print_paths(adj, n, src, dest);
            // Console.WriteLine("Hello World!");
        }
    }
}
