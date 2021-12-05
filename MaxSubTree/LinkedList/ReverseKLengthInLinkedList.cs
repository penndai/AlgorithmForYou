using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.LinkedList
{
    public class LinkedListReverseKNodes
    {
        public Node head; // head of list  

        /* Linked list Node*/
        public class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }
        //O(n) where n is the number of nodes in the given list
        public Node Reverse(Node firstNodeOfKNodes, int k)
        {
            Node current = firstNodeOfKNodes;
            Node previous = null;
            Node next = null;
            var count = 0;

            //1 -->2 --->3--->4--->5
            //move next to current.next
            //cut current.next, change current.next to previous
            //move previous to current
            //move current to next
            while(count <k && current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
                count++;
            }

            ///* next is now a pointer to (k+1)th node  
            //Recursively call for the list starting from current.
            //And make rest of the list as next of first node */
            if (next != null)
                //update the head.next every time so in the end, the head point to the first node 
                // of first K subset
                //head.next = Reverse(next, k);
                firstNodeOfKNodes.next = Reverse(next, k);  
            
            return previous;
        }

        /* Inserts a new Node at front of the list. */
        public void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &  
                    Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        /* Function to print linked list */
        public void printList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }
}
