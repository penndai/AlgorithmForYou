using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class LargestBSTResult
    {
        public int Size { get; set; }
        public bool IsBST { get; set; }
        //min value of the right children tree
        public int Min { get; set; }
        //max value of the left children tree
        public int Max { get; set; }
    }
    public class LargestBSTInBinaryTree
    {
        public LargestBSTResult FindLargestBST(Node node)
        {
            if(node == null)
            {
                return new LargestBSTResult() { IsBST = true, Max = int.MinValue, Min = int.MaxValue, Size = 0 };
            }

            var leftResult = FindLargestBST(node.left);
            var rightResult = FindLargestBST(node.right);

            if(!leftResult.IsBST || !rightResult.IsBST || node.key < leftResult.Max || node.key > rightResult.Min)
            {
                return new LargestBSTResult()
                {
                    IsBST = false,
                    Size = 0
                };
            }
            else
            {
                var currentNodeResult = new LargestBSTResult();
                currentNodeResult.IsBST = true;
                currentNodeResult.Max = node.right !=null ? rightResult.Max:node.key;
                currentNodeResult.Min = node.left !=null ?leftResult.Min : node.key;
                currentNodeResult.Size = leftResult.Size + rightResult.Size + 1;

                return currentNodeResult;
            }
        }
    }
}
