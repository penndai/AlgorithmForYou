using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class BinaryHeap
    {
        public int capacity;
        public int heapSize = 0;
        // store the heap node - key value paire.
        // key - unique value to identify the node
        // value - the value decide the location in the heap tree. Top first one is the minimul
        public HeapNode[] heap;
        // store the node position in the array
        //key - the same key in the binary heap tree
        //value - the index value in the array
        public Dictionary<int, int> map = new Dictionary<int, int>();
        public BinaryHeap(int capacity)
        {
            this.capacity = capacity;
            heap = new HeapNode[capacity];
            for (int i = 0; i < capacity; i++)
            {
                heap[i] = new HeapNode(int.MinValue, int.MinValue);
            }
        }
        public bool IsEmpty()
        {
            return heapSize == 0;
        }
        public int GetValue(int key)
        {
            return heap[map[key]].value;
        }
        public bool Contains(int key)
        {
            return map.ContainsKey(key);
        }
        public void Insert(int key, int value)
        {
            HeapNode node = new HeapNode(key, value);
            if (heapSize == 0)
            {
                heap[0] = node;
                map[node.key] = 0;
                heapSize++;
            }
            else
            {
                heapSize++;
                heap[heapSize - 1] = node;
                map[node.key] = heapSize - 1;
                int index = heapSize - 1;
                int parent = (index - 1) / 2;
                while ((parent >= 0) && (index >= 0) && (heap[parent].value > heap[index].value))
                {
                    HeapNode temp = heap[parent];
                    heap[parent] = heap[index];
                    heap[index] = temp;
                    map[heap[parent].key] = parent;
                    map[heap[index].key] = index;
                    index = parent;
                    parent = (index - 1) / 2;
                }
            }
        }
        //downheap - switch with the smaller child
        public void Heapify(int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int smallest = index;
            if ((left < heapSize) && (heap[left].value < heap[index].value))
            {
                smallest = left;
            }
            if ((right < heapSize) && (heap[right].value < heap[smallest].value))
            {
                smallest = right;
            }
            if (smallest != index)
            {
                HeapNode temp = heap[smallest];
                heap[smallest] = heap[index];
                heap[index] = temp;
                map[heap[smallest].key] = smallest;
                map[heap[index].key] = index;
                Heapify(smallest);
            }
        }

        public int GetMin()
        {
            return heap[0].value;
        }

        public int ExtractMin()
        {
            HeapNode min = heap[0];
            map.Remove(min.key);
            heap[0] = heap[heapSize - 1];
            map[heap[0].key] = 0;
            heapSize--;
            Heapify(0);
            return min.key;
        }

        public void Decreasekey(int key, int value)
        {
            int index = map[key];
            heap[index].value = value;
            int parent = (index - 1) / 2;
            while ((parent >= 0) && (index >= 0) && (heap[parent].value > heap[index].value))
            {
                HeapNode temp = heap[parent];
                heap[parent] = heap[index];
                heap[index] = temp;
                map[heap[parent].key] = parent;
                map[heap[index].key] = index;
                index = parent;
                parent = (index - 1) / 2;
            }
        }
    };
    public class HeapNode
    {
        public int key;
        public int value;
        public HeapNode(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    };
}
