using System;

namespace splay_tree
{
    class Program
    {
        //https://www.growingwiththeweb.com/data-structures/splay-tree/overview/

        public class SplayTreeNode
        {

            public string nullNodeString = "_";
            public SplayTreeNode left;
            public SplayTreeNode right;
            public SplayTreeNode parent;

            public int key;
            public bool isDeleted = false;

            public SplayTreeNode(int key, SplayTreeNode parent)
            {
                this.key = key;
                this.parent = parent;
            }
        }

        SplayTreeNode root = null;

        void insert(int key)
        {
            if (root == null)
            {
                root = new SplayTreeNode(key, null);
                return;
            }
            insert(key, root);
            search(key);
        }

        void insert(int key, SplayTreeNode root)
        {
            if (key.CompareTo(root.key) < 0)
            {
                if (root.left != null)
                    insert(key, root.left);
                else
                    root.left = new SplayTreeNode(key, root);
            }
            if (key.CompareTo(root.key) > 0)
            {
                if (root.right != null)
                    insert(key, root.right);
                else
                    root.right = new SplayTreeNode(key, root);
            }
        }
        public SplayTreeNode search(int key, SplayTreeNode root)
        {
            if (key == root.key)
                return root;

            if (key.CompareTo(root.key) < 0)
            {
                if (root.left != null)
                    return search(key, root.left);
                else
                    return null;
            }
            if (key.CompareTo(root.key) > 0)
            {
                if (root.right != null)
                    return search(key, root.right);
                else
                    return null;
            }
            return null;
        }


        public bool search(int key)
        {
            if (root == null)
                return false;

            SplayTreeNode node = search(key, root);
            splay(node);
            return node != null;
        }


        void splay(SplayTreeNode node)
        {
            while (node.parent != null)
            {
                SplayTreeNode parent = node.parent;
                if (parent.parent == null)
                {
                    if (parent.left == node)
                        rotateRight(parent);
                    else
                        rotateLeft(parent);
                }
                else
                {
                    SplayTreeNode gparent = parent.parent;
                    if (parent.left == node && gparent.left == parent)
                    {
                        rotateRight(gparent);
                        rotateRight(node.parent);
                    }
                    else if (parent.right == node &&
                          gparent.right == parent)
                    {
                        rotateLeft(gparent);
                        rotateLeft(node.parent);
                    }
                    else if (parent.left == node &&
                          gparent.right == parent)
                    {
                        rotateRight(parent);
                        rotateLeft(node.parent);
                    }
                    else
                    {
                        rotateLeft(parent);
                        rotateRight(node.parent);
                    }
                }
            }
        }

        void rotateLeft(SplayTreeNode x)
        {
            SplayTreeNode y = x.right;
            x.right = y.left;
            if (y.left != null)
            {
                y.left.parent = x;
            }
            y.parent = x.parent;
            if (x.parent == null)
                root = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;
            y.left = x;
            x.parent = y;
        }

        void rotateRight(SplayTreeNode x)
        {
            SplayTreeNode y = x.left;
            x.left = y.right;
            if (y.right != null)
                y.right.parent = x;
            y.parent = x.parent;
            if (x.parent == null)
                root = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;
            y.right = x;
            x.parent = y;
        }

        public void delete(int key)
        {
            if (root == null)
            {
                return;
            }

            search(key);
            delete(key, root);
        }

        private void delete(int key, SplayTreeNode node)
        {
            if (key.CompareTo(node.key) < 0)
            {
                if (node.left != null)
                {
                    delete(key, node.left);
                }
                if (node.left.isDeleted)
                {
                    node.left = null;
                }
                return;
            }

            if (key.CompareTo(node.key) > 0)
            {
                if (node.right != null)
                {
                    delete(key, node.right);
                }
                if (node.right.isDeleted)
                {
                    node.right = null;
                }
                return;
            }

            delete(node);
        }

        private void delete(SplayTreeNode node)
        {
            if (node.left == null || node.right == null)
            {
                node.isDeleted = true;
                return;
            }

            if (node.left != null && node.right == null)
            {
                node.key = (node.left.key);
                if (node.left.right != null)
                {
                    node.right = (node.left.right);
                }
                if (node.left.left != null)
                {
                    node.left = (node.left.left);
                }
                else
                {
                    node.left = (null);
                }
                return;
            }

            if (node.right != null && node.left == null)
            {
                node.key = (node.right.key);
                if (node.right.left != null)
                {
                    node.left = (node.left.left);
                }
                if (node.right.right != null)
                {
                    node.right = (node.left.right);
                }
                else
                {
                    node.right = (null);
                }
                return;
            }

            // both exist, replace with minimum from right sub-tree
            int min = findMin(node.right);
            node.key = (min);
        }

        private int findMin(SplayTreeNode node)
        {
            if (node.left == null)
            {
                node.isDeleted = true;
                return node.key;
            }

            int min = findMin(node.left);
            if (node.left.isDeleted)
            {
                node.left = null;
            }
            return min;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.insert(4);
            program.insert(3);
            program.insert(2);
            program.insert(1);

            program.search(2);

            program.delete(3);


            Console.WriteLine(program.root);
        }
    }
}
