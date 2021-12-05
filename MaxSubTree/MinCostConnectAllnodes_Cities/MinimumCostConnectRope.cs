// C# program to connect n ropes with minimum cost 
using System;

// A class for Min Heap 
//put smallest ropes down the tree so that they can be repeated multiple times rather than the longer ropes.
class MinHeap
{
    public int[] Elements; // elements in heap 
    public int HeapSize; // Current number of elements in min heap 
    public int capacity; // maximum possible size of min heap 

    // Constructor: Builds a heap from 
    // a given array a[] of given size 
    public MinHeap(int[] a, int size)
    {
        HeapSize = size;
        capacity = size;
        Elements = a;
        int i = (HeapSize - 1) / 2;
        while (i >= 0)
        {
            MinHeapify(i);
            i--;
        }
    }

    // A recursive method to heapify a subtree 
    // with the root at given index 
    // This method assumes that the subtrees 
    // are already heapified 
    void MinHeapify(int i)
    {
       //initially the heap tree looks like
        //    4
        //   / \
        //  3   2
        // / \
        // 6

        // calculate the left and right nodes, according to the current node index in the array
        int l = left(i);
        int r = right(i);

        // to build the Min Heap, swap the node with smallest left or right node
        int smallest = i;
        if (l < HeapSize && Elements[l] < Elements[i])
            smallest = l;
        if (r < HeapSize && Elements[r] < Elements[smallest])
            smallest = r;
        if (smallest != i)
        {
            swap(i, smallest);
            MinHeapify(smallest);
        }
    }

    int parent(int i) { return (i - 1) / 2; }

    // assume the current array already created a heap tree
    // to get index of left child of node at index i 
    int left(int i) { return (2 * i + 1); }

    // assume the current array already created a heap tree
    // to get index of right child of node at index i 
    int right(int i) { return (2 * i + 2); }

    // Method to remove minimum element (or root) from min heap 
    public int GetMinimum()
    {
        if (HeapSize <= 0)
            return int.MaxValue;
        if (HeapSize == 1)
        {
            HeapSize--;
            return Elements[0];
        }

        // Store the minimum value, and remove it from heap 
        int root = Elements[0];
        // move the last element of the heap tree to the top root
        Elements[0] = Elements[HeapSize - 1];
        HeapSize--;
        // rebuild the min heap tree from root
        MinHeapify(0);

        return root;
    }

    // Inserts a new key 'k' 
    public void InsertNewKey(int k)
    {
        if (HeapSize == capacity)
        {
            Console.WriteLine("Overflow: Could not insertKey");
            return;
        }

        // First insert the new key at the end 
        HeapSize++;
        int i = HeapSize - 1;
        Elements[i] = k;

        // Fix the min heap property if it is violated 
        while (i != 0 && Elements[parent(i)] > Elements[i])
        {
            swap(i, parent(i));
            i = parent(i);
        }
    }    

    // A utility function to swap two elements 
    private void swap(int x, int y)
    {
        int temp = Elements[x];
        Elements[x] = Elements[y];
        Elements[y] = temp;
    }
};

class MinumumCostConnectRope
{
    // The main function that returns the 
    // minimum cost to connect n ropes of 
    // lengths stored in len[0..n-1] 
    private static int minCost(int[] len, int n)
    {
        int cost = 0; // Initialize result 

        // Create a min heap of capacity equal 
        // to n and put all ropes in it 
        MinHeap minHeap = new MinHeap(len, n);

        // Iterate while size of heap doesn't become 1 
        while (minHeap.HeapSize != 1)
        {
            // Extract two minimum length ropes from min heap 
            int min = minHeap.GetMinimum();
            int sec_min = minHeap.GetMinimum();

            cost += (min + sec_min); // Update total cost 

            // Insert a new rope in min heap with length equal to sum 
            // of two extracted minimum lengths 
            minHeap.InsertNewKey(min + sec_min);
        }

        // Finally return total minimum 
        // cost for connecting all ropes 
        return cost;
    }

    public static void Calculate()
    {
        int[] len = { 2, 2, 3, 3 };
        int size = len.Length;

        Console.WriteLine("Total cost for connecting ropes is " +
                                            minCost(len, size));
    }
}
