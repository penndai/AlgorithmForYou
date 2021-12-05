using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class LeftSideViewOfBinaryTree
    {
        /// <summary>
        ///             7        
        ///            / \
        ///           6   5
        ///          / \  / \
        ///         4   3 2  1
        /// </summary>
        /// <param name="node"></param>
        public void PrintLeftSideView(TreeNode node)
        {
            if (node == null) return;

            //queue  = 7 6 5  4  3  2  1
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(node);

            //queue: 7
            //queue: 6 5
            //queue: 4 3 2 1
            //so each time the i= 0 is the first element which is also the left side node
            while(queue.Count >0)
            {
                var len = queue.Count;

                // key point: the count of queue won't be changed until the 
                // previous level nodes all be travelled.
                for(int i=0;i < len; i++)
                {
                    //each time dequeue, if current node is first one in the level,
                    //print it and enqueue the left and right children.
                    var cNode = queue.Dequeue();
                    if(i == 0)                    
                    {
                        Console.WriteLine(cNode.data);
                    }

                    if(cNode.left != null)
                    {
                        queue.Enqueue(cNode.left);
                    }

                    if(cNode.right != null)
                    {
                        queue.Enqueue(cNode.right);
                    }
                }
            }
        }

        public  void PrintTreeLevelByLevelNewLine(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(null);

            while(queue.Count > 0)
            {
                var currentNode = queue.Dequeue();                

                if(currentNode != null)
                {                    
                    Console.WriteLine(currentNode.data);
                    if (currentNode.left != null) queue.Enqueue(currentNode.left);
                    if (currentNode.right != null) queue.Enqueue(currentNode.right);
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        Console.WriteLine("New Line");
                        queue.Enqueue(null);
                    }
                    else break;
                }
                
            }
        }
    }
}