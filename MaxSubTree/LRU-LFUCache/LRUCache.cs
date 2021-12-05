using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class LRUCache
    {
        private int capacity;
        private int count;
        //map stores the values in the LRU cache
        Dictionary<int, LRUNode> map;
        LRUDoubleLinkedList doubleLinkedList;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.count = 0;
            map = new Dictionary<int, LRUNode>();
            doubleLinkedList = new LRUDoubleLinkedList();
        }

        // each time when access the node, we move it to the top
        public int Get(int key)
        {
            if (!map.ContainsKey(key)) return -1;
            LRUNode node = map[key];
            doubleLinkedList.RemoveNode(node);
            doubleLinkedList.AddToTop(node);
            return node.Value;
        }
        public void Add(int key, int value)
        {
            // just need to update value and move it to the top
            if (map.ContainsKey(key))
            {
                LRUNode node = map[key];
                doubleLinkedList.RemoveNode(node);
                node.Value = value;
                doubleLinkedList.AddToTop(node);
            }
            else
            {
                // if cache is full, then remove the least recently used node
                if (count == capacity)
                {
                    LRUNode lru = doubleLinkedList.RemoveLRUNode();
                    map.Remove(lru.Key);
                    count--;
                }

                // add a new node
                LRUNode node = new LRUNode(key, value);
                doubleLinkedList.AddToTop(node);
                map[key] = node;
                count++;
            }

        }
    }
    public class LRUNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public LRUNode Previous { get; set; }
        public LRUNode Next { get; set; }
        public LRUNode() { }
        public LRUNode(int k, int v)
        {
            this.Key = k;
            this.Value = v;
        }
    }

    //the reason using Double Linked List is 
    //when insert the node into the top, remove from the tail, double linked list is O(1)
    //head points to the most recently accessed. tail points to the least recently accessed   
    public class LRUDoubleLinkedList
    {
        private LRUNode Head;
        private LRUNode Tail;

        public LRUDoubleLinkedList()
        {
            Head = new LRUNode();
            Tail = new LRUNode();
            Head.Next = Tail;
            Tail.Previous = Head;
        }

        public void AddToTop(LRUNode node)
        {
            node.Next = Head.Next;
            Head.Next.Previous = node;
            node.Previous = Head;
            Head.Next = node;
        }

        public void RemoveNode(LRUNode node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.Next = null;
            node.Previous = null;
        }

        public LRUNode RemoveLRUNode()
        {
            LRUNode target = Tail.Previous;
            RemoveNode(target);
            return target;
        }
    }
}
