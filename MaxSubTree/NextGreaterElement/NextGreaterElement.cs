using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.NextGreaterElement
{
    public class NextGreaterElement
    {
        public class stack
        {
            public int top;
            public int[] items = new int[100];

            // Stack functions to be used by printNGE  
            public virtual void push(int x)
            {
                if (top == 99)
                {
                    Console.WriteLine("Stack full");
                }
                else
                {
                    items[++top] = x;
                }
            }

            public virtual int pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Underflow error");
                    return -1;
                }
                else
                {
                    int element = items[top];
                    top--;
                    return element;
                }
            }

            public virtual bool Empty
            {
                get
                {
                    return (top == -1) ? true : false;
                }
            }
        }

        public void Stack_EfficientWay(int[] arr, int n)
        {
            int i = 0;
            stack s = new stack();
            s.top = -1;
            int element, next;
            /* push the first element to stack */
            s.push(arr[0]);
            // iterate for rest of the elements 
            for (i = 1; i < n; i++)
            {
                next = arr[i];

                //一次打印所有比当前的element小的元素
                //并将它们都pop出去
                //print all previous elments in the stack which is < next
                if (s.Empty == false)
                {
                    // if stack is not empty, then   
                    // pop an element from stack  
                    element = s.pop();

                    /* If the popped element is smaller than next, then a) print the pair b) keep   
                       popping while elements are smaller and   
                       stack is not empty */
                    while (element < next)
                    {
                        Console.WriteLine(element + " --> " + next);
                        if (s.Empty == true)
                        {
                            break;
                        }

                        //continue寻找前面仍然比next小的元素
                        element = s.pop();
                    }

                    //因为最后一个元素被pop出来了，所有把它再push回去
                    /* If element is greater than next, then   
                       push the element back */
                    if (element > next)
                    {
                        s.push(element);
                    }
                }

                /* push next to stack so that we can find next  
                   greater for it */
                s.push(next);
            }
        }

        /// <summary>
        /// Use two loops: The outer loop picks all the elements one by one. 
        /// The inner loop looks for the first greater element for the element picked by the 
        /// outer loop. If a greater element is found then that element is printed as next, 
        /// otherwise -1 is printed.
        /// O(n^2). The worst case occurs when all elements are sorted in decreasing order.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        public void SimpleNestedLoop(int[] arr, int n)
        {
            int next, i, j;
            for (i = 0; i < n; i++)
            {
                next = -1;
                for (j = i + 1; j < n; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        next = arr[j];
                        break;
                    }
                }
                Console.WriteLine(arr[i] + " -- " + next);
            }
        }
    }
}
