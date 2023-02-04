using Helper;
using System;

namespace maximum_depth_of_binary_tree
{
    /*
     * Given the root of a binary tree, return its maximum depth.

        A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    */

    class Program
    {

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
        static void Main(string[] args)
        {
            CommonHelper helper = new CommonHelper();
            CommonHelper.root = new TreeNode(3);
            CommonHelper.root.left = new TreeNode(9);
            CommonHelper.root.right = new TreeNode(20);
            CommonHelper.root.right.left = new TreeNode(15);
            CommonHelper.root.right.right = new TreeNode(7);

            Program program = new Program();
            Console.WriteLine("height: " + program.MaxDepth(CommonHelper.root));
        }
    }
}
