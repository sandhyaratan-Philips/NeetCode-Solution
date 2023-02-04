using System;

namespace Helper
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
    public class CommonHelper
    {
        public static TreeNode root = null;

        public void insertnode(int value)
        {
            TreeNode newNode = new TreeNode(value);
            if (root == null)
                root = newNode;
            TreeNode current = root;
            TreeNode prev = current;

            while (current != null)
            {
                if (value < current.val)
                {
                    prev = current;
                    current = current.left;
                }
                else if (value > current.val)
                {
                    prev = current;
                    current = current.right;
                }
            }

            if (value < prev.val)
            {
                prev.left = newNode;
            }
            else
            {
                prev.right = newNode;
            }
        }

        public void printNodes(TreeNode node)
        {
            if (node == null)
                return;
            printNodes(node.left);
            Console.Write(node.val + "-> ");
            printNodes(node.right);

        }
    }
}
