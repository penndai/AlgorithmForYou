// C# program to implement a stack 
// that supports getMinimum() in O(1) 
// time and O(1) extra space. 
using System;
using System.Collections;
using System.Collections.Generic;

public class SpecialStack_MinO1Time : Stack
{
    //    Push(int x) // inserts an element x to Special Stack
    //1) push x to the first stack(the stack with actual elements)
    //2) compare x with the top element of the second stack(the auxiliary stack). Let the top element be y.
    //…..a) If x is smaller than y then push x to the auxiliary stack.
    //…..b) If x is greater than y then push y to the auxiliary stack.


    //int Pop() // removes an element from Special Stack and return the removed element
    //1) pop the top element from the auxiliary stack.
    //2) pop the top element from the actual stack and return it.

    //The step 1 is necessary to make sure that the auxiliary stack is also updated for future operations.

    //int getMin() // returns the minimum element from Special Stack
    //1) Return the top element of auxiliary stack.

    Stack<int> min = new Stack<int>();

    /* SpecialStack's member method to insert an element to it. This method 
   makes sure that the min stack is also updated with appropriate minimum 
   values */
    public void push(int x)
    {
        if (Count ==0)
        {
            Push(x);
            min.Push(x);
        }
        else
        {
            Push(x);
            int y = min.Peek();
            
            if (x < y)
            {
                //pop out the previous min y
                min.Pop();
                min.Push(x);
            }
            else
                min.Push(y);
        }
    }

    /* SpecialStack's member method to insert an element to it. This method 
    makes sure that the min stack is also updated with appropriate minimum 
    values */
    public int pop()
    {
        int x = (int)Pop();

        //every time pop from value stack, pop as well from min stack
        min.Pop();
        return x;
    }

    /* SpecialStack's member method to get minimum element from it. */
    int getMin()
    {
        int x = min.Peek();        
        return x;
    }

    public void push_only_store_small_min_stack(int x)
    {
        if (Count == 0)
        {
            Push(x);
            min.Push(x);
        }
        else
        {
            Push(x);
            int y = min.Peek();

            /* push only when the incoming element of main stack is smaller  
            than or equal to top of auxiliary stack */
            if (x <= y)
            {
                min.Push(x);
            }
        }
    }

    public int Pop_only_store_small_min_stack()
    {
        int x = (int)Pop();
        int y = min.Peek();

        /* Push the popped element y back only if it is not equal to x */
        if (y == x)        
        {
            min.Pop();
        }

        return x;
    }
}
