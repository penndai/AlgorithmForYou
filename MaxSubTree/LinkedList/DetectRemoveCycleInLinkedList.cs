using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.LinkedList
{
    public class DetectRemoveLoopInLinkedList
    {
        public Node head;

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

        // Function that detects loop in the list 
        //Floyd’s Cycle-Finding Algorithm: This is the fastest method and has been described below:
        //Traverse linked list using two pointers.
        //Move one pointer(slow_p) by one and another pointer(fast_p) by two.
        //If these pointers meet at the same node then there is a loop. If pointers do not meet then linked list doesn’t have a loop
        public int detectAndRemoveLoop(Node node)
        {
            Node slow = node, fast = node;
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                // If slow and fast meet at same 
                // point then loop is present 
                if (slow == fast)
                {
                    //removeLoop(slow, node);
                    removeLoop_NotNeedCount_CycleLength(slow, node);
                    return 1;
                }
            }
            return 0;
        }


        public void removeLoop_NotNeedCount_CycleLength(Node detectedNode, Node head)
        {
            var p1 = head;
            while(detectedNode.next != p1.next)
            {
                detectedNode = detectedNode.next;
                p1 = p1.next;
            }

            /* since detectedNode->next is the looping point */
            detectedNode.next = null; /* remove loop */
        }
        // Function to remove loop 
        public void removeLoop(Node loop, Node head)
        {
            Node ptr1 = loop;
            Node ptr2 = loop;

            // Count the number of nodes in loop 
            int k = 1, i;
            while (ptr1.next != ptr2)
            {
                ptr1 = ptr1.next;
                k++;
            }

            // Fix one pointer to head 
            ptr1 = head;

            // And the other pointer to k nodes after head 
            ptr2 = head;
            for (i = 0; i < k; i++)
            {
                ptr2 = ptr2.next;
            }

            /* Move both pointers at the same pace, they will meet at loop starting node */
            while (ptr2 != ptr1)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            // Get pointer to the last node 
            while (ptr2.next != ptr1)
            {
                ptr2 = ptr2.next;
            }

            /* Set the next node of the loop ending node to fix the loop */
            ptr2.next = null;
        }

        // Function to print the linked list 
       public void printList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }
    }
}
