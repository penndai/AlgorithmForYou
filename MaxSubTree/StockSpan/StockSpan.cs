using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class StockSpan
    {
        //    index  0  1  2  3  4  5  6  7  8
        //          75 70 60 85 90 45 65 100 90
        //Span[1]
        //index_stack[0]
        //i=1 stack[0,1]
        //i=2 stack[0,1,2]
        //i=3 stack[] :pop all elements, stack is empty, span[3] = i+1 ==> stack[3]
        //i=4 stack[]: pop all, stack is empty, span[4] = i+1 =5 staci=>stack[4]
        //i=5 stack[4,5]
        //i=6 stack[4,6], pop index[5], because [5 -> 45] < [6 -> 65] span = index 6 - index 4 = 2
        //i=7 stack[], pop all elments, stack is empaty, span[7] = 7+1 = 8; stack[7]
        //i=8 stack[7, 8] span[8] = 1
        // a linear time solution for 
        // stock span problem A stack 
        // based efficient method to calculate 
        // stock span values 
        public void CalculateSpan_Stack(int[] price, int n, int[] S)
        {
            // Create a stack and Push index of element to it 
            Stack st = new Stack();
            st.Push(0);

            // Span value of first element is always 1 
            S[0] = 1;

            // Calculate span values for rest of the elements 
            for (int i = 1; i < n; i++)
            {
                // Pop elements from stack while stack is not empty and top of stack is smaller 
                // than price[i] 
                while (st.Count > 0 && price[(int)st.Peek()] <= price[i])
                    st.Pop();

                // If stack becomes empty, then price[i] is 
                // greater than all elements on left of it, i.e., 
                // price[0], price[1], ..price[i-1]. Else price[i] 
                // is greater than elements after top of stack 
                S[i] = (st.Count == 0) ? (i + 1) : (i - (int)st.Peek());

                // Push this element index to stack 
                st.Push(i);
            }
        }

        // method to calculate stock span values 
        //O(n^2)
        public void calculateSpan_InEfficient(int[] price,
                                  int n, int[] S)
        {

            // Span value of first day is always 1 
            S[0] = 1;

            // Calculate span value of remaining 
            // days by linearly checking previous 
            // days 
            for (int i = 1; i < n; i++)
            {
                S[i] = 1; // Initialize span value 

                // Traverse left while the next 
                // element on left is smaller 
                // than price[i] 
                // only loop through when price[i] > price[j]
                // if any time price[j] > price[i], break the iteration
                for (int j = i - 1; (j >= 0) && (price[i] >= price[j]); j--)
                    S[i]++;
            }
        }
    }
}
