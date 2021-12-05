using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class BinarySearchTreeFromSortedArray
    {
        public static TreeNode BuildBSTFromSortedArray(int[] num)
        {
            return BuildBSTFromSortedArrayRecursion(num, 0, num.Length - 1);
        }

        private static TreeNode BuildBSTFromSortedArrayRecursion(int[] num, int low, int high)
        {
            if (low > high)
            {
                return null;
            }

            var mid = (high - low) / 2 + low;

            var newRoot = new TreeNode(num[mid])
            {
                left = BuildBSTFromSortedArrayRecursion(num, low, mid - 1),
                right = BuildBSTFromSortedArrayRecursion(num, mid + 1, high)
            };

            return newRoot;
        }
    }
}
