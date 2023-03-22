using System;

namespace maximum_depth_of_binary_tree
{
    /*
     * 104. Maximum Depth of Binary Tree

        Given the root of a binary tree, return its maximum depth.

        A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

 

        Example 1:


        Input: root = [3,9,20,null,null,15,7]
        Output: 3
    */
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
