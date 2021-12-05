using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class ValidateBinaryTreeIsBinarySearchTree
    {
        public bool isBSTUtil(TreeNode node, int min, int max)
        {
            // each node has to compare the related min and max value, 
            // min and max value definition:
            // if current node on the left side, doesn't care much about the min value so
            //min value inherites from its parent, max value is parent
            // if current node on the right side, min value is parent, 不关心 max 值 max value inherites from parent
            /* an empty tree is BST */
            if (node == null)
            {
                return true;
            }

            /* false if this node violates the min/max constraints */
            if (node.data <= min || node.data >= max)
            {
                return false;
            }

            /* otherwise check the subtrees recursively  
            tightening the min/max constraints */
            // Allow only distinct values  
            return (isBSTUtil(node.left, min, node.data) &&
                isBSTUtil(node.right, node.data, max));
        }
    }
}
