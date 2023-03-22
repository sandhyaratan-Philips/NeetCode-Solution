using System;
using System.Collections.Generic;
using System.Linq;

namespace most_frequent_subtree_sum
{
    /*
        508. Most Frequent Subtree Sum

            Given the root of a binary tree, return the most frequent subtree sum. If there is a tie, return all the values with the highest frequency in any order.

            The subtree sum of a node is defined as the sum of all the node values formed by the subtree rooted at that node (including the node itself).

 

            Example 1:


            Input: root = [5,2,-3]
            Output: [2,-3,4]
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
        int maxi = -1;
        Dictionary<int, int> m = new Dictionary<int, int>();

        int dfs(TreeNode node)
        {
            if (node == null)
                return 0;
            int total = dfs(node.left) + dfs(node.right) + node.val;

            if (!m.ContainsKey(total)) m.Add(total, 0);

            maxi = Math.Max(maxi, ++m[total]);
            return total;
        }


        public int[] FindFrequentTreeSum(TreeNode root)
        {
            dfs(root);

            int[] arr = new int[m.Count];

            return m.Where(x => x.Value == maxi).Select(x => x.Key).ToArray();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            TreeNode node = new TreeNode(5, new TreeNode(2), new TreeNode(-5));
            Console.WriteLine(program.FindFrequentTreeSum(node));
        }
    }
}
