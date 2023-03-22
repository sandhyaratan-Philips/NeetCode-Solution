using System;
using System.Collections.Generic;

namespace binary_tree_zigzag_level_order_traversal
{
    /*
     * 103. Binary Tree Zigzag Level Order Traversal

            Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).

 

            Example 1:


            Input: root = [3,9,20,null,null,15,7]
            Output: [[3],[20,9],[15,7]]
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


        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            LinkedList<TreeNode> queue = new LinkedList<TreeNode>();

            if (root != null)
                queue.AddFirst(root);

            while (queue.Count > 0)
            {
                List<int> level = new List<int>();
                int N = queue.Count;
                for (int i = 0; i < N; i++)
                {
                    TreeNode node = queue.Last.Value;
                    queue.RemoveLast();
                    level.Add(node.val);
                    if (node.left != null)
                        queue.AddFirst(node.left);
                    if (node.right != null)
                        queue.AddFirst(node.right);
                }
                if (res.Count % 2 == 1)
                    level.Reverse();
                res.Add(level);
            }
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20, new TreeNode(15), new TreeNode(7));

            Console.WriteLine(program.ZigzagLevelOrder(root));
        }
    }
}
