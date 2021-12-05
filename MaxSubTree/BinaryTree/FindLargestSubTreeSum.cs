using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    using System;

    // C# program to find largest 
    // subtree sum in a given binary tree. 

    public class Node
    {
        public int key;
        public Node left, right;
    }

    public class INT
    {
        public int v;
        public INT(int a)
        {
            v = a;
        }
    }

    public class FindLargestSubTreeSum
    {

        // Structure of a tree node. 
        

        // Function to create new tree node. 
        public static Node newNode(int key)
        {
            Node temp = new Node();
            temp.key = key;
            temp.left = temp.right = null;
            return temp;
        }

        // Helper function to find largest 
        // subtree sum recursively. 
        public static int findSubTreeSumRecursive(Node root, INT ans)
        {
            // If current node is null then 
            // return 0 to parent node. 
            if (root == null)
            {
                return 0;
            }

            //DFS - search left sub tree firstly
            // Subtree sum rooted 
            // at current node. 
            int currSum = root.key + findSubTreeSumRecursive(root.left, ans)
                                + findSubTreeSumRecursive(root.right, ans);

            // Update answer if current subtree 
            // sum is greater than answer so far. 
            ans.v = Math.Max(ans.v, currSum);

            // Return current subtree 
            // sum to its parent node. 
            return currSum;
        }

        // Function to find 
        // largest subtree sum. 
        public static int findLargestSubtreeSum(Node root)
        {
            // If tree does not exist, 
            // then answer is 0. 
            if (root == null)
            {
                return 0;
            }

            // Variable to store 
            // maximum subtree sum. 
            INT ans = new INT(-9999999);

            // Call to recursive function 
            // to find maximum subtree sum. 
            findSubTreeSumRecursive(root, ans);

            return ans.v;
        }                
    }    

}
