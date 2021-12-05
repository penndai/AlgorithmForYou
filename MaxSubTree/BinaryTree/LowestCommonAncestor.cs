using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class LowestCommonAncestor
    {
        public static TreeNode BuildBTree()
        {
            //      3
            //     / \
            //    6   8
            //   / \   \
            //  2  11   13 
            //    /  \  / 
            //   9   8  7
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(6);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(11);

            root.left.right.left = new TreeNode(9);
            root.left.right.right = new TreeNode(8);
            
            root.right.right = new TreeNode(13);
            root.right.right.left = new TreeNode(7);            
            return root;
        }
       
        public static TreeNode CommonAncestor(TreeNode node, TreeNode node1, TreeNode node2)
        {
            if (node == null) return null;

            // if current node data equals to node1 or node2, means find one target
            // if second one node is the children of this found one, good, return find one
            //
            // otherwise, continue search current find one's parent
            if (node.data == node1.data || node.data == node2.data) return node;

            //If current node doesn't match any of target, continue search left firstly
            //
            var left = CommonAncestor(node.left, node1, node2);

            //continue search right
            var right = CommonAncestor(node.right, node1, node2);

            // return the current node if find both targets from its two way sub tree
            if (left != null && right != null) return node;

            if (left == null && right == null) return null;

            // current node is not the parent of targets, return left or right to current node's parent and 
            // continue find another target.
            return left != null ? left : right;
        }
    }
}
