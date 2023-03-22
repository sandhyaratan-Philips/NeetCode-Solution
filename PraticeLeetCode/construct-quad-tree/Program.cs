using System;

namespace construct_quad_tree
{
    /*
     * 427. Construct Quad Tree

            Given a n * n matrix grid of 0's and 1's only. We want to represent the grid with a Quad-Tree.

            Return the root of the Quad-Tree representing the grid.

            Notice that you can assign the value of a node to True or False when isLeaf is False, and both are accepted in the answer.

            A Quad-Tree is a tree data structure in which each internal node has exactly four children. Besides, each node has two attributes:

            val: True if the node represents a grid of 1's or False if the node represents a grid of 0's.
            isLeaf: True if the node is leaf node on the tree or False if the node has the four children.
            class Node {
                public boolean val;
                public boolean isLeaf;
                public Node topLeft;
                public Node topRight;
                public Node bottomLeft;
                public Node bottomRight;
            }
            We can construct a Quad-Tree from a two-dimensional area using the following steps:

            If the current grid has the same value (i.e all 1's or all 0's) set isLeaf True and set val to the value of the grid and set the four children to Null and stop.
            If the current grid has different values, set isLeaf to False and set val to any value and divide the current grid into four sub-grids as shown in the photo.
            Recurse for each of the children with the proper sub-grid.

            If you want to know more about the Quad-Tree, you can refer to the wiki.

            Quad-Tree format:

            The output represents the serialized format of a Quad-Tree using level order traversal, where null signifies a path terminator where no node exists below.

            It is very similar to the serialization of the binary tree. The only difference is that the node is represented as a list [isLeaf, val].

            If the value of isLeaf or val is True we represent it as 1 in the list [isLeaf, val] and if the value of isLeaf or val is False we represent it as 0.

 

            Example 1:


            Input: grid = [[0,1],[1,0]]
            Output: [[0,1],[1,0],[1,1],[1,1],[1,0]]
            Explanation: The explanation of this example is shown below:
            Notice that 0 represnts False and 1 represents True in the photo representing the Quad-Tree.

    */

    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }


    class Program
    {
        int[][] Grid;
        public Node Construct(int[][] grid)
        {
            Grid = grid;
            return dfs(Grid.Length, 0, 0);
        }
        Node dfs(int n, int r, int c)
        {
            bool allSame = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Grid[r][c] != Grid[r + i][c + j])
                    {
                        allSame = false;
                        break;
                    }
                }
            }
            if (allSame)
            {
                return new Node(Grid[r][c] == 1 ? true : false, true);
            }
            n = n / 2;
            Node topLeft = dfs(n, r, c);
            Node topRight = dfs(n, r, c + n);
            Node bottemLeft = dfs(n, r + n, c);
            Node bottomRight = dfs(n, r + n, c + n);

            return new Node(false, false, topLeft, topRight, bottemLeft, bottomRight);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.Construct(new int[][] { new[] { 0, 1 }, new[] { 1, 0 } }));
        }
    }
}
