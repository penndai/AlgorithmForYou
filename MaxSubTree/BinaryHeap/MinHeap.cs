using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class MinHeap
    {
        // store all nodes in the heap
        List<int> Nodes = new List<int>();
        // hash map for each nodes in the heap, node-index pair
        Dictionary<int, int> hashMap = new Dictionary<int, int>();

        public void PrintNodes()
        {
            foreach(var n in Nodes)
            {
                Console.WriteLine(n);
            }
        }
        public int PopMin()
        {
            if(Nodes.Count > 0)
            {
                var result = Nodes[0];
                //swap the min top node with last node
                Swap(Nodes[0], Nodes[Nodes.Count - 1]);

                //remove min top from Nodes and Hashmap                
                hashMap.Remove(Nodes[Nodes.Count - 1]);
                Nodes.RemoveAt(Nodes.Count - 1);

                //swap the new top with its left and right child
                var currentIndex = hashMap[Nodes[0]];
                var leftChildIndex = currentIndex * 2 + 1;
                var rightChildIndex = currentIndex * 2 + 2;

                //heap is completed BT, so only check the left child existing or not
                while(leftChildIndex < Nodes.Count)
                {
                    var minIndex = leftChildIndex;
                    if (rightChildIndex < Nodes.Count)
                    {
                        minIndex = Nodes[leftChildIndex] > Nodes[rightChildIndex] ? rightChildIndex : leftChildIndex;
                    }
                    Swap(Nodes[currentIndex], Nodes[minIndex]);

                    currentIndex = minIndex;
                    leftChildIndex = currentIndex * 2 + 1;
                    rightChildIndex = currentIndex * 2 + 2;
                }

                return result;
            }
            else
            {
                return int.MinValue;
            }

        }

        public void Add(int value)
        {
            Nodes.Add(value);
            // each time, add at the end of the heap
            int currentIndex = Nodes.Count - 1;
            // add the hash map value for current new node
            hashMap.Add(value, currentIndex);

            int parentIndex = (currentIndex - 1) / 2;
            //compare with parent, if current node < parent, swap
            while(parentIndex >= 0 && Nodes[parentIndex] > Nodes[currentIndex])
            {
                Swap(Nodes[currentIndex], Nodes[parentIndex]);

                parentIndex = (hashMap[value] - 1) / 2;
                currentIndex = hashMap[value];
            }
        }

        private void Swap(int current, int parent)
        {
            int currentIndex = hashMap[current];
            int parentIndex = hashMap[parent];

            //swap the locations/index of current and parent nodes
            Nodes[currentIndex] = parent;
            Nodes[parentIndex] = current;
            //update the hashmap for current-index, parent-index pairs
            hashMap[current] = parentIndex;
            hashMap[parent] = currentIndex;
        }
    }
}
