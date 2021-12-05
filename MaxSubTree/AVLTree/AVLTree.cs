using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class AVLTree
    {
        //each rotation cares about only grandparent - parent -child 3 nodes
        //current node is the root of these 3 levels - grandparent
        private Node LeftRotation(Node node)
        {
            var newRoot = node.right;
            newRoot.left = node;
            node.right = newRoot.left;

            node.Height = SetHeight(node);
            newRoot.Height = SetHeight(newRoot);
            return newRoot;
        }

        private Node RightRotation(Node node)
        {
            var newRoot = node.left;
            newRoot.right = node;
            node.left = newRoot.right;

            node.Height = SetHeight(node);
            newRoot.Height = SetHeight(newRoot);
            return newRoot;
        }

        private int SetHeight(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(node.left.Height != 0 ? node.left.Height : 0, node.right.Height != 0 ? node.right.Height : 0);
        }

        private int Balance(Node left, Node right)
        {
            return left.Height - right.Height;
        }

        private int Height(Node node)
        {
            return Node.Height;
        }
        public Node Insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node() { key = data};
            }

            //Insertion
            if (data > root.key) root.right = Insert(root.right, data);
            if (data < root.key) root.left = Insert(root.left, data);

            //Get balance: left.banalce - right balance
            int balance = Balance(root.left, root.right);

            //if necessory rebalance
            if(balance > 1) //
            {
                if(Height(root.left.left) > Height(root.left.right))
                {
                    root = RightRotation(root);
                }
                else
                {
                    root.left = LeftRotation(root.left);
                    root = RightRotation(root);
                }
            }
            else if(balance <-1)
            {
                if(Height(root.right.right) > Height(root.right.left))
                {
                    root = LeftRotation(root);
                }
                else
                {
                    root.right = RightRotation(root.right);
                    root = LeftRotation(root);
                }
            }
            else
            {
                root.height = setHeight(root);
            }

            return root;
        }
    }
}
