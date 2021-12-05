using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class PrintTreeInLevelOrder
    {
        public void PrintOutTreeInLevelOrder(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var element = queue.Dequeue();

                Console.WriteLine(element.data);
                if(element.left != null)
                {
                    queue.Enqueue(element.left);
                }

                if(element.right != null)
                {
                    queue.Enqueue(element.right);
                }
            }            
        }
    }
}
