using System;

namespace avl_tree
{
    class Program
    {
        /*
         *  type of self-balancing binary search tree. The tree re-organises itself after every insert and delete so that the tree height is approximately \log nlogn nodes high,
         *  allowing search in O(\log n)O(logn) time. The re-organising does not guarantee a perfectly balanced tree, it is however good enough to guarantee O(\log n)O(logn) search.
         *  
         *  https://www.growingwiththeweb.com/data-structures/avl-tree/overview/
         */

        public class AVLTreeNode : IComparable<AVLTreeNode>
        {
            /**
             * The left child node.
             */
            public AVLTreeNode left;

            /**
             * The right child node.
             */
            public AVLTreeNode right;

            /**
             * The key of the node.
             */
            public int key;

            /**
             * The height of the node.
             */
            public int height;

            /**
             * Creates a new {@link AVLTreeNode}.
             *
             * @param key The key of the new node.
             */
            public AVLTreeNode(int key)
            {
                this.key = key;
            }

            public int CompareTo(AVLTreeNode other)
            {
                return key.CompareTo(other.key);
            }
            /**
     * Performs a right rotate on this node.
     *
     *       b                           a
     *      / \                         / \
     *     a   e -> b.rotateRight() -> c   b
     *    / \                             / \
     *   c   d                           d   e
     *
     * @return The root of the sub-tree; the node where this node used to be.
     */
            public AVLTreeNode rotateRight()
            {
                AVLTreeNode other = this.left;
                this.left = (other != null && other.right != null ? other.right : null);
                if (other != null) other.right = (this);
                this.height = (Math.Max(this.left != null ? this.left.height : -1, this.right != null ? this.right.height : -1) + 1);
                if (other != null) other.height = (Math.Max(other.left.height, this.height) + 1);
                return other;
            }

            /**
             * Performs a left rotate on this node.
             *
             *     a                              b
             *    / \                            / \
             *   c   b   -> a.rotateLeft() ->   a   e
             *      / \                        / \
             *     d   e                      c   d
             *
             * @return The root of the sub-tree; the node where this node used to be.
             */
            public AVLTreeNode rotateLeft()
            {
                AVLTreeNode other = this.right;
                this.right = (other != null && other.left != null ? other.left : null);
                if (other != null) other.left = (this);
                this.height = (Math.Max(this.left != null ? this.left.height : -1, this.right != null ? this.right.height : -1) + 1);
                if (other != null) other.height = (Math.Max(other.right.height, this.height) + 1);
                return other;
            }
        }

        AVLTreeNode root = null;

        void insert(int key)
        {
            root = insert(key, root);
        }

        AVLTreeNode insert(int key, AVLTreeNode root)
        {
            if (root == null)
            {
                return new AVLTreeNode(key);
            }

            if (key.CompareTo(root.key) < 0)
            {
                root.left = insert(key, root.left);
            }
            else if (key.CompareTo(root.key) > 0)
            {
                root.right = insert(key, root.right);
            }
            else
            {
                return root;
            }

            root.height = Math.Max(root.left != null ? root.left.height : -1, root.right != null ? root.right.height : -1) + 1;

            BalanceState balanceState = getBalanceState(root);

            if (balanceState == BalanceState.UNBALANCED_LEFT)
            {
                // Left left case
                if (getBalanceState(root.left) == BalanceState.BALANCED ||
                        getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_LEFT)
                {
                    return root.rotateRight();
                }
                // Left right case
                if (getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_RIGHT)
                {
                    root.left = (root.left.rotateLeft());
                    return root.rotateRight();
                }
            }

            // Right right case
            if (balanceState == BalanceState.UNBALANCED_RIGHT)
            {
                if (getBalanceState(root.left) == BalanceState.BALANCED ||
                        getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_RIGHT)
                {
                    return root.rotateLeft();
                }
                // Right left case
                if (getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_LEFT)
                {
                    root.right = (root.right.rotateRight());
                    return root.rotateLeft();
                }
            }

            return root;


        }

        private BalanceState getBalanceState(AVLTreeNode node)
        {
            if (node == null)
            {
                return BalanceState.BALANCED;
            }
            int heightDifference = (node.left != null ? node.left.height : -1) - (node.right != null ? node.right.height : -1);
            switch (heightDifference)
            {
                case -2: return BalanceState.UNBALANCED_RIGHT;
                case -1: return BalanceState.SLIGHTLY_UNBALANCED_RIGHT;
                case 1: return BalanceState.SLIGHTLY_UNBALANCED_LEFT;
                case 2: return BalanceState.UNBALANCED_LEFT;
            }
            return BalanceState.BALANCED;
        }

        /**
         * Represents how balanced a node's left and right children are.
         */
        private enum BalanceState
        {
            UNBALANCED_RIGHT,
            SLIGHTLY_UNBALANCED_RIGHT,
            BALANCED,
            SLIGHTLY_UNBALANCED_LEFT,
            UNBALANCED_LEFT
        }

        public void delete(int key)
        {
            root = delete(key, root);
        }

        private AVLTreeNode delete(int key, AVLTreeNode root)
        {
            if (root == null)
                return root;

            if (key.CompareTo(root.key) < 0)
            {
                root.left = delete(key, root.left);
            }
            else if (key.CompareTo(root.key) > 0)
            {
                root.right = delete(key, root.right);
            }
            else
            {
                // root is the node to be deleted
                if (root.left == null && root.right == null)
                {
                    root = null;
                }
                else if (root.left == null && root.right != null)
                {
                    root = root.right;
                }
                else if (root.left != null && root.right == null)
                {
                    root = root.left;
                }
                else
                {
                    // Node has 2 children, get the in-order successor
                    AVLTreeNode inOrderSuccessor = minValueNode(root.right);
                    root.key = (inOrderSuccessor.key);
                    root.right = (delete(inOrderSuccessor.key, root.right));
                }
            }

            if (root == null)
            {
                return root;
            }

            root.height = Math.Max(root.left != null ? root.left.height : -1, root.right != null ? root.right.height : -1) + 1;

            BalanceState balanceState = getBalanceState(root);

            if (balanceState == BalanceState.UNBALANCED_LEFT)
            {
                // Left left case
                if (getBalanceState(root.left) == BalanceState.BALANCED ||
                        getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_LEFT)
                {
                    return root.rotateRight();
                }
                // Left right case
                if (getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_RIGHT)
                {
                    root.left = (root.left.rotateLeft());
                    return root.rotateRight();
                }
            }

            // Right right case
            if (balanceState == BalanceState.UNBALANCED_RIGHT)
            {
                if (getBalanceState(root.left) == BalanceState.BALANCED ||
                        getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_RIGHT)
                {
                    return root.rotateLeft();
                }
                // Right left case
                if (getBalanceState(root.left) == BalanceState.SLIGHTLY_UNBALANCED_LEFT)
                {
                    root.right = (root.right.rotateRight());
                    return root.rotateLeft();
                }
            }

            return root;

        }

        private AVLTreeNode minValueNode(AVLTreeNode p)
        {
            while (p.left != null)
            {
                p = p.left;
            }
            return p;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.insert(3);
            program.insert(2);
            program.insert(6);
            program.insert(1);
            program.insert(7);
            program.insert(5);
            program.insert(4);


            program.delete(6);



            Console.WriteLine("root:" + program.root);
        }
    }
}
