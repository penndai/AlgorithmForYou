using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class BinaryTreePathSumToTarget
    {
        /// <summary>
     /// subtract the node value from the  
     /// sum when recurring down, and check to see if the sum is 0 when you run out of tree.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="treeNode"></param>
    /// <returns></returns>
        private bool RecursiveFindPathSum(int target, Node treeNode)
        {
            var result = false;
            if (treeNode == null) return target == 0;

            var subsum = target - treeNode.key;
            if (subsum == 0 && treeNode.left == null && treeNode.right == null) return true;

            if(treeNode.left !=null)
            {
                result = RecursiveFindPathSum(subsum, treeNode.left);
            }

            if (!result)
            {
                if (treeNode.right != null)
                {
                    result = RecursiveFindPathSum(subsum, treeNode.right);
                }
            }

            return result;
        }        

        public bool FindPathSumEqualsTo(int target, Node root)
        {
            var result = RecursiveFindPathSum(target, root);
            return result;
        }
    }
}
