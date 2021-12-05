using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class PrintBinaryTreeMinDepth
    {
        /// <summary>
        /// each node return itself depth to its parent
        /// the leaf node returns 1
        /// the parent of leaf node return 1+1
        /// the other parent returns min(leftChildMinDepth, rightChildMinDepth) + 1
        /// in the end, when it processes back to the root node, 
        /// return min(root_left_child_minDepth, root_right_child_minDepth) + root itself 1
        /// </summary>
        /// <param name="root"></param>
        /// <returns>O(n) -- need iterate all nodes</returns>
        public int FindBinaryTreeMinDepth_Recursive(TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null)
            {
                return 1;
            }

            if (root.left == null)
            {
                return 1+ FindBinaryTreeMinDepth_Recursive(root.right);
            }

            if (root.right == null)
                return 1+ FindBinaryTreeMinDepth_Recursive(root.left);

            return Math.Min(FindBinaryTreeMinDepth_Recursive(root.left), FindBinaryTreeMinDepth_Recursive(root.right)) + 1;
        }

        // A queue element (Stores pointer to node and an depth)  
        public class qItem
        {
            public TreeNode node;
            public int depth;

            public qItem(TreeNode node, int depth)
            {
                this.node = node;
                this.depth = depth;
            }
        }

        public int FindBinaryTreeMinDepth_LevelOrder(TreeNode root)
        {
            // Corner Case  
            if (root == null) return 0;
            // Create an empty queue for level order tarversal  
            Queue<qItem> q = new Queue<qItem>();

            // Enqueue Root and initialize depth as 1  
            qItem qi = new qItem(root, 1);
            q.Enqueue(qi);

            // Do level order traversal  
            while (q.Count != 0)
            {
                // Remove the front queue item  
                qi = q.Peek();
                q.Dequeue();

                // Get details of the remove item  
                TreeNode node = qi.node;
                int depth = qi.depth;

                // If this is the first leaf node seen so far. Then return its depth as answer 
                if (node.left == null && node.right == null)
                    return depth;

                // If left subtree is not null, add it to queue  
                if (node.left != null)
                {
                    qi.node = node.left;
                    qi.depth = depth + 1;
                    q.Enqueue(qi);
                }

                // If right subtree is not null,  add it to queue  
                if (node.right != null)
                {
                    qi.node = node.right;
                    qi.depth = depth + 1;
                    q.Enqueue(qi);
                }
            }

            return 0;
        }
    }
}
