using System;

namespace red_black_tree
{
    //https://www.growingwiththeweb.com/data-structures/red-black-tree/overview/

    //    Here are the set of rules that a red-black tree must follow:

    //      Each node is either red or black
    //      The root node is black
    //      All leaf nodes(nil) are black
    //      Both children of every red node are black
    //      For each node, all paths from the node to descendant leaves contain the same number of black nodes

    class RedBlack
    {
        public int val { get; set; }
        public RedBlack parent { get; set; }
        public RedBlack left { get; set; }
        public RedBlack right { get; set; }
        public int color { get; set; }

        public RedBlack(int value, int isRed, RedBlack parent = null, RedBlack left = null, RedBlack right = null)
        {
            this.val = value;
            this.color = isRed;
            this.parent = parent;
            this.right = right;
            this.left = left;
        }
    }

    class Program
    {
        RedBlack root = null;

        public void leftRotate(RedBlack node)
        {
            //set the node as the left child node of the current node's right node

            RedBlack right_node = node.right;
            if (right_node != null)
            {
                // right node's left node become the right node of current node

                node.right = right_node.left;
                if (right_node.left != null)
                    right_node.left.parent = node;
                right_node.parent = node.parent;

                // check the parent case
                if (node.parent == null)
                    root = right_node;
                else if (node == node.parent.left)
                    node.parent.left = right_node;
                else
                    node.parent.right = right_node;
                right_node.left = node;
                node.parent = right_node;
            }
        }


        public void rightRotate(RedBlack node)
        {
            // set the node as the right child node of the current node's left node
            RedBlack left_node = node.left;
            if (left_node != null)
            {
                node.left = left_node.right;
                if (left_node.right != null)
                    left_node.right.parent = node;
                left_node.parent = node.parent;

                //check the parent case
                if (node.parent == null)
                    root = left_node;
                else if (node == node.parent.left)
                    node.parent.left = left_node;
                else
                    node.parent.right = left_node;
                left_node.right = node;
                node.parent = left_node;
            }
        }

        void insert(RedBlack node)
        {
            RedBlack root = this.root;
            RedBlack insert_node_parent = null;
            //# find the position of inserted node
            while (root != null)
            {
                insert_node_parent = root;
                if (insert_node_parent.val < node.val)
                    root = root.right;
                else
                    root = root.left;
            }

            //set the n ode's parent node
            node.parent = insert_node_parent;
            if (insert_node_parent == null)
                // case 1  inserted tree is null
                this.root = node;
            else if (insert_node_parent.val > node.val)
                //case 2 not null and find left or right
                insert_node_parent.left = node;
            else
                insert_node_parent.right = node;

            node.left = null;
            node.right = null;
            node.color = 1;
            //fix tree
            fix_insert(node);
        }

        void fix_insert(RedBlack node)
        {
            //case 1 the parent is null, then set the inserted node as root and color = 0
            if (node.parent == null)
            {
                node.color = 0;
                this.root = node;
                return;
            }

            //case 2 the parent color is black, do nothing
            // case 3 the parent color is red

            while (node.parent != null && node.parent.color == 1)
            {
                if (node.parent == node.parent.parent.left)
                {
                    RedBlack uncle_node = node.parent.parent.right;
                    if (uncle_node != null && uncle_node.color == 1)
                    {
                        // case 3.1 the uncle node is red
                        // then set parent and uncle color is black and grandparent is red
                        //then node => node.parent
                        node.parent.color = 0;
                        node.parent.parent.right.color = 0;
                        node.parent.parent.color = 1;
                        node = node.parent.parent;
                        continue;
                    }
                    else if (node == node.parent.right)
                    {
                        //# case 3.2 the uncle node is black or null, and the node is right of parent
                        //# then set his parent node is current node
                        //# left rotate the node and continue the next
                        node = node.parent;
                        leftRotate(node);
                    }

                    //# case 3.3 the uncle node is black and parent node is left
                    //# then parent node set black and grandparent set red
                    node.parent.color = 0;
                    node.parent.parent.color = 1;
                    rightRotate(node.parent.parent);
                }
                else
                {
                    RedBlack uncle_node = node.parent.parent.left;
                    if (uncle_node != null && uncle_node.color == 1)
                    {
                        //# case 3.1 the uncle node is red
                        //# then set parent and uncle color is black and grandparent is red
                        //# then node => node.parent
                        node.parent.color = 0;
                        node.parent.parent.left.color = 0;
                        node.parent.parent.color = 1;
                        node = node.parent.parent;
                        continue;
                    }
                    else if (node == node.parent.left)
                    {
                        //# case 3.2 the uncle node is black or null, and the node is right of parent
                        //# then set his parent node is current node
                        //# left rotate the node and continue the next
                        node = node.parent;
                        rightRotate(node);
                    }
                    //# case 3.3 the uncle node is black and parent node is left
                    //# then parent node set black and grandparent set red
                    node.parent.color = 0;
                    node.parent.parent.color = 1;
                    leftRotate(node.parent.parent);
                }
            }
            this.root.color = 0;

        }

        RedBlack minimum(RedBlack node)
        {
            //find the minimum node when node regard as a root node   
            //:param node:
            //:return: minimum node 
            RedBlack temp_node = node;
            while (temp_node.left != null)
                temp_node = temp_node.left;
            return temp_node;
        }

        RedBlack maximum(RedBlack node)
        {
            //    find the max node when node regard as a root node
            //:param node: 
            //:return: max node
            RedBlack temp_node = node;
            while (temp_node.right != null)
                temp_node = temp_node.right;
            return temp_node;
        }

        void transplant(RedBlack node_u, RedBlack node_v)
        {
            //replace u with v
            //:param node_u: replaced node
            //:param node_v: 
            //:return: None

            if (node_u.parent == null)
                this.root = node_v;
            else if (node_u == node_u.parent.left)
                node_u.parent.left = node_v;
            else if (node_u == node_u.parent.right)
                node_u.parent.right = node_v;
            // check is node_v is None 
            if (node_v != null)
                node_v.parent = node_u.parent;
        }

        void delete(RedBlack node)
        {
            // find the node position
            int node_color = node.color;
            RedBlack temp_node;
            if (node.left == null)
            {
                temp_node = node.right;
                transplant(node, node.right);
            }
            else if (node.right == null)
            {
                temp_node = node.left;
                transplant(node, node.left);
            }
            else
            {
                //# both child exits ,and find minimum child of right child
                RedBlack node_min = minimum(node.right);
                node_color = node_min.color;
                temp_node = node_min.right;

                if (node_min.parent != node)
                {
                    transplant(node_min, node_min.right);
                    node_min.right = node.right;
                    node_min.right.parent = node_min;
                }
                transplant(node, node_min);
                node_min.left = node.left;
                node_min.left.parent = node_min;
                node_min.color = node.color;
                //# when node is black, then need to fix it with 4 cases
            }
            if (node_color == 0)
                delete_fixup(temp_node);

        }

        void delete_fixup(RedBlack node)
        {
            //# 4 cases
            while (node != this.root && node.color == 0)
                //    # node is not root and color is black
                if (node == node.parent.left)
                {

                    //# node is left node
                    RedBlack node_brother = node.parent.right;

                    //                # case 1: node's red, can not get black node
                    //# set brother is black and parent is red 
                    if (node_brother.color == 1)
                    {
                        node_brother.color = 0;
                        node.parent.color = 1;
                        this.leftRotate(node.parent);
                        node_brother = node.parent.right;
                    }

                    //  # case 2: brother node is black, and its children node is both black
                    if ((node_brother.left == null || node_brother.left.color == 0) && (
                             node_brother.right == null || node_brother.right.color == 0))
                    {
                        node_brother.color = 1;
                        node = node.parent;
                    }
                    else
                    {

                        //   # case 3: brother node is black , and its left child node is red and right is black
                        if (node_brother.right == null || node_brother.right.color == 0)
                        {
                            node_brother.color = 1;
                            node_brother.left.color = 0;
                            rightRotate(node_brother);
                            node_brother = node.parent.right;
                        }

                        // # case 4: brother node is black, and right is red, and left is any color
                        node_brother.color = node.parent.color;
                        node.parent.color = 0;
                        node_brother.right.color = 0;
                        leftRotate(node.parent);
                        node = this.root; ;
                    }
                }
                else
                {
                    RedBlack node_brother = node.parent.left;
                    if (node_brother.color == 1)
                    {
                        node_brother.color = 0;
                        node.parent.color = 1;
                        leftRotate(node.parent);
                        node_brother = node.parent.right;
                    }
                    if ((node_brother.left == null || node_brother.left.color == 0) && (
                                node_brother.right == null || node_brother.right.color == 0))
                    {
                        node_brother.color = 1;
                        node = node.parent;
                    }
                    else
                    {
                        if (node_brother.left == null || node_brother.left.color == 0)
                        {
                            node_brother.color = 1;
                            node_brother.right.color = 0;
                            leftRotate(node_brother);
                            node_brother = node.parent.left;
                        }
                        node_brother.color = node.parent.color;
                        node.parent.color = 0;
                        node_brother.left.color = 0;
                        rightRotate(node.parent);
                        node = this.root;
                    }
                }
            node.color = 0;
        }

        static void Main(string[] args)
        {
            var obj = new RedBlack(4, 1);
            Program program = new Program();
            program.insert(new RedBlack(5, 1));
            program.insert(new RedBlack(3, 1));
            program.insert(obj);
            program.insert(new RedBlack(9, 1));

            program.delete(obj);
            Console.WriteLine(program.root); ;
        }
    }
}
