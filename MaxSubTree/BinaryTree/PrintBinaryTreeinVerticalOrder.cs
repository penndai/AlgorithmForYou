using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm_Multiple
{   
    // A binary tree node 
    public class PrintTreeInVerticalOrder_Node
    {
        public int data;
        public PrintTreeInVerticalOrder_Node left, right;

        public PrintTreeInVerticalOrder_Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
   
    public class BinaryTree_PrintVerticalOrder
    {
        public PrintTreeInVerticalOrder_Node root;

        //store the level - List<Node> keyvaluepair.
        public Dictionary<int, List<PrintTreeInVerticalOrder_Node>> Hd_NodeHashMap = new Dictionary<int, List<PrintTreeInVerticalOrder_Node>>();
        
        /// <summary>
        /// For root, Hd=0. For Left child, Hd = -1, For right child Hd = 1
        /// The algorithm is Level Order + hash table
        /// if(Hashmap does not contain the level)
        ///     New list of node for this level -- add new key value pair (level, List<node>)
        ///     Enqueue the node - put the current node to the hash map (dictionary)
        ///     Add the current node to the dictionary, level is key, node is the value
        /// else
        ///     Append the current node to the last List<Node>, according to the level key
        ///     
        /// Recursion for the left node (node.left, level-1)
        /// Recursion for the right node (node.right, level +1)
        ///     
        /// </summary>
        /// <param name="root"></param>
        /// <param name="level"></param>
        public void VerticalTree(PrintTreeInVerticalOrder_Node root, int level)
        {
            if (root == null) return;
            if (!Hd_NodeHashMap.ContainsKey(level))
                // dictionary does not contain the level as key
                // insert into the dictionary with level as key
            {
                var nodes = new List<PrintTreeInVerticalOrder_Node>();
                nodes.Add(root);

                Hd_NodeHashMap.Add(level, nodes);
            }
            else
            {
                //update the node list
                Hd_NodeHashMap[level].Add(root);
            }

            VerticalTree(root.left, level-1);
            VerticalTree(root.right, level+1);
        }

        public void printResult()
        {
            var keys = Hd_NodeHashMap.Keys.OrderBy(x=>x).ToList();
            foreach(var k in keys)
            {
                var listOfNodes = Hd_NodeHashMap[k].ToList();
                foreach(var node in listOfNodes)
                {
                    Console.WriteLine(node.data);
                }
            }
        }
    }

    /* This code is contributed PrinciRaj1992 */

}
