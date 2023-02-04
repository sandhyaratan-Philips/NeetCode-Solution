using Helper;
using System;

namespace diameter_of_binary_tree
{
    /*
     * Given the root of a binary tree, return the length of the diameter of the tree.

        The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

        The length of a path between two nodes is represented by the number of edges between them.

         */
    class Program
    {
        int depth = -1;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            dfs(root);
            return depth;

        }
        int dfs(TreeNode current)
        {
            if (current == null)
            {
                return -1;
            }
            int left = 1 + dfs(current.left);
            int right = 1 + dfs(current.right);
            depth = Math.Max(depth, (left + right));
            return Math.Max(left, right);
        }
        static void Main(string[] args)
        {
            CommonHelper helper = new CommonHelper();
            CommonHelper.root = new TreeNode(1);
            CommonHelper.root.left = new TreeNode(2);
            CommonHelper.root.right = new TreeNode(3);
            CommonHelper.root.left.left = new TreeNode(4);
            CommonHelper.root.left.right = new TreeNode(5);

            Program program = new Program();
            Console.WriteLine("height: " + program.DiameterOfBinaryTree(CommonHelper.root));
        }
    }
}
