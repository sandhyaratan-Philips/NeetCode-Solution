using System;

namespace minimum_distance_between_bst_nodes
{
    /*
     * 783. Minimum Distance Between BST Nodes

        Given the root of a Binary Search Tree (BST), return the minimum difference between the values of any two different nodes in the tree.

 

        Example 1:


        Input: root = [4,2,6,1,3]
        Output: 1
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

        int prv = -1;
        int res = int.MaxValue;
        public int MinDiffInBST(TreeNode root)
        {
            inOrder(root);
            return res;
        }

        void inOrder(TreeNode root)
        {
            if (root == null) return;

            inOrder(root.left);
            if (prv >= 0)
            {
                res = Math.Min(res, Math.Abs(prv - root.val));
            }
            prv = root.val;
            inOrder(root.right);

        }
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            root.right = new TreeNode(6);
            Program program = new Program();
            Console.WriteLine(program.MinDiffInBST(root));
        }
    }
}
