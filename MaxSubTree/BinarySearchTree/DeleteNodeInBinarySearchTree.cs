using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class DeleteNodeInBinarySearchTree
    {
        /// <summary>
        /// if (currentNode > deleted node value)
        ///     search from left child of current node
        ///     delete(currentNode.left, value)
        /// if (currentNode < deleted node value
        ///     search from right child of current node
        ///     delete(currentNode.right. value)
        /// currentNode == node value ---> current node is exactly need to be deleted
        ///     if(currentNode.left is not null && currentNode.right is null)
        ///         return currentNode.left
        ///     if(currentNode.left is null && currentNode.right is not null)
        ///         return current.right
        ///     else ---> currentNode has both left and right nodes
        ///         Find min node from right child, and return this min node
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode DeleteTreeNode(TreeNode root, int val)
        {
            if (root == null) return null;
            if (val < root.data) root.left = DeleteTreeNode(root.left, val);
            else if (val > root.data) root.right = DeleteTreeNode(root.right, val);
            else
            {
                //find the node to be deleted
                //case 1: leaf node
                if (root.left == null && root.right == null)
                {
                    return null;
                }
                else if (root.left == null) // case 2: the left child of node is null, link the riht child directly
                {
                    root = root.right;
                }
                else if (root.right == null)//case 2: the right child of node is null, link the left child directly
                {
                    root = root.left;
                }
                else // case 3: deleted node has 2 children, find the min node of the right sub tree
                {
                    var rightMinNode = FindMin(root.right);
                    if (rightMinNode != null)
                    {
                        //attach this min node as deleted node
                        root.data = rightMinNode.data;

                        //delete the same min node from current node right sub tree
                        root.right = DeleteTreeNode(root.right, rightMinNode.data);

                    }
                    else
                    {
                        var leftMaxNode = FindMax(root.left);
                        root.data = leftMaxNode.data;
                        root.left = DeleteTreeNode(root.left, root.data);
                    }
                }
            }

            return root;
        }

        /// <summary>
        /// the min node is always on the left sub tree, so DFS search to the last one leaf on the left tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static TreeNode FindMin(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            else if (root.left == null)
            {
                return root;
            }
            else
            {
                return FindMin(root.left);
            }
        }

        private static TreeNode FindMax(TreeNode node)
        {
            if (node == null) return null;
            else if (node.right == null) return node;
            else return FindMax(node.right);
        }
    }
}
