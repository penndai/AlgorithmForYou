using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class TreeNode
    {

        public int data;
        public TreeNode left, right;

        public TreeNode(int d)
        {
            data = d;
            left = right = null;
        }
    }

    class BinarySearchTree
    {    
        public static Boolean SearchBST(TreeNode node, int key)
        {
            if (node == null) return false;

            if (node.data == key) return true;

            if (node.data > key) return SearchBST(node.left, key);
            if (node.data < key) return SearchBST(node.right, key);

            return false;
        }
               
        public static TreeNode InsertTreeNode(TreeNode root, int val)
        {
            if(root == null)
            {
                return new TreeNode(val);
            }

            if (val > root.data) return InsertTreeNode(root.right, val);
            if (val < root.data) return InsertTreeNode(root.left, val);

            return root;
        }
        public static TreeNode InitializeAnExampleTree()
        {
            /*
         *      10
         *      / \
         *     5   15
         *         /\
         *        11  20
         */

            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(15);
            root.right.left = new TreeNode(11);
            root.right.right = new TreeNode(20);

            return root;
        }
    }
}
