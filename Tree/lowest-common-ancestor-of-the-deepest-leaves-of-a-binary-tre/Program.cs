using Common;
using System;

namespace lowest_common_ancestor_of_the_deepest_leaves_of_a_binary_tre
{
    class Program
    {
        static int findDepth(Node root)
        {
            if (root == null)
                return 0;

            int left = findDepth(root.LeftNode);

            int right = findDepth(root.RightNode);

            return 1 + Math.Max(left, right);
        }

        static Node DFS(Node root, int curr,
                           int depth)
        {

            if (root == null)
                return null;

            // If curr is equal to depth
            if (curr == depth)
                return root;

            // Left recursive subtree
            Node left = DFS(root.LeftNode, curr + 1, depth);

            // Right recursive subtree
            Node right = DFS(root.RightNode, curr + 1, depth);

            // If left and right are not null
            if (left != null && right != null)
                return root;

            // Return left, if left is not null
            // Otherwise return right
            return (left != null) ? left : right;
        }

        static Node lcaOfDeepestLeaves(Node root)
        {

            // If root is null
            if (root == null)
                return null;

            // Stores the deepest depth
            // of the binary tree
            int depth = findDepth(root) - 1;

            // Return the LCA of the
            // nodes at level depth
            return DFS(root, 0, depth);
        }

        static void Main(string[] args)
        {
            Node root = new Node(3);
            root.LeftNode = new Node(5);
            root.RightNode = new Node(1);
            root.LeftNode.LeftNode = new Node(6);
            root.LeftNode.RightNode = new Node(2);
            root.RightNode.LeftNode = new Node(0);
            root.RightNode.RightNode = new Node(8);
            root.LeftNode.RightNode.LeftNode = new Node(7);
            root.LeftNode.RightNode.RightNode = new Node(4);

            Console.WriteLine(lcaOfDeepestLeaves(root).data);
        }
    }
}
