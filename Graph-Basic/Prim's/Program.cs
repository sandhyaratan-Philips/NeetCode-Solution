using System;

namespace Prim_s
{
    /*
     *  Initialize the minimum spanning tree with a vertex chosen at random.
        Find all the edges that connect the tree to new vertices, find the minimum and add it to the tree
        Keep repeating step 2 until we get a minimum spanning tree
    O(E log V).
     */
    class Program
    {
        void Prim(int[][] G, int V)
        {
            int minWeight = int.MaxValue;

            int noOfEdges = 0;

            bool[] visited = new bool[V];

            visited[0] = true;

            while (noOfEdges < V - 1)
            {
                minWeight = int.MaxValue;
                int x = 0; // row number
                int y = 0; // col number
                for (int i = 0; i < V; i++)
                {
                    if (visited[i] == true)
                    {
                        for (int j = 0; j < V; j++)
                        {
                            if (!visited[j] && G[i][j] != 0)
                            {
                                if (G[i][j] < minWeight)
                                {
                                    minWeight = G[i][j];
                                    x = i;
                                    y = j;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine(x + " - " + y + " :  " + G[x][y]);
                visited[y] = true;
                noOfEdges++;
            }
        }

        static void Main(string[] args)
        {
            Program g = new Program();

            // number of vertices in grapj
            int V = 5;

            // create a 2d array of size 5x5
            // for adjacency matrix to represent graph
            int[][] G = new int[][] { new[] {0, 9, 75, 0, 0 }, new []{9, 0, 95, 19, 42 }, new []{75, 95, 0, 51, 66 }, new []{0, 19, 51, 0, 31 },
        new []{0, 42, 66, 31, 0 } };

            g.Prim(G, V);
        }
    }
}
