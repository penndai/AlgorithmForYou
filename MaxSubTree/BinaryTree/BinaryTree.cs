using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class BinaryTree
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="node"></param>
        /// <param name="index">current index in the array</param>
        /// <returns></returns>
        public TreeNode CreateBinaryTreeFromArray(int[] array, int index)
        {
            TreeNode newNode = null;
            if (index < array.Length)
            {
                newNode = new TreeNode(array[index]);

                newNode.left = CreateBinaryTreeFromArray(array, 2*index+1);
                newNode.right = CreateBinaryTreeFromArray(array, 2*index+2);
            }

            return newNode;
        }

        // Function to print tree 
        // nodes in InOrder fashion 
        public void PrintOut(TreeNode root)
        {
            if (root != null)
            {
                PrintOut(root.left);
                Console.Write(root.data + " ");
                PrintOut(root.right);
            }
        }        
        

       
    }
}
