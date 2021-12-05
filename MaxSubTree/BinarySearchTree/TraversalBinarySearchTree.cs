using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class TraversalBinarySearchTree
    {
        public static void Preorder(TreeNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node.data);
                Preorder(node.left);
                Preorder(node.right);
            }
        }

        public static void InnerOrder(TreeNode node)
        {
            if (node != null)
            {
                InnerOrder(node.left);
                Console.WriteLine(node.data);
                InnerOrder(node.right);
            }
        }

        public static void postOrder(TreeNode node)
        {
            if (node != null)
            {
                postOrder(node.right);
                Console.WriteLine(node.data);
                postOrder(node.left);
            }
        }
    }
}
