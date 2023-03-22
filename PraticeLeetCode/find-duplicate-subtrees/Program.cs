using System;
using System.Collections.Generic;

namespace find_duplicate_subtrees
{
    /*
     * 652. Find Duplicate Subtrees

        Given the root of a binary tree, return all duplicate subtrees.

        For each kind of duplicate subtrees, you only need to return the root node of any one of them.

        Two trees are duplicate if they have the same structure with the same node values.

        Example 1:

        Input: root = [1,2,3,4,null,2,4,null,null,4]
        Output: [[2,4],[4]]
    */

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
    class Program
    {
        Dictionary<string, List<TreeNode>> subTree = new Dictionary<string, List<TreeNode>>();
        List<TreeNode> res = new List<TreeNode>();
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            preorder(root);
            return res;
        }

        string preorder(TreeNode node)
        {
            if (node == null)
                return "null";
            string s = string.Join(',', new string[] { node.val.ToString(), preorder(node.left), preorder(node.right) });

            if (subTree.ContainsKey(s) && subTree[s].Count == 1)
            {
                res.Add(node);
            }
            if (subTree.ContainsKey(s))
                subTree[s].Add(node);
            else
                subTree.Add(s, new List<TreeNode> { node });
            return s;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            TreeNode root = new TreeNode(2, new TreeNode(2), new TreeNode(2));
            root.left.left = new TreeNode(3);
            root.right.left = new TreeNode(3);
            Console.WriteLine(program.FindDuplicateSubtrees(root));
        }
    }
}
