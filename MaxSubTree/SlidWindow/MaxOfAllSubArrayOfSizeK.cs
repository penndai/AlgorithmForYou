using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    /// <summary>
    /// Input: arr[] = {1, 2, 3, 1, 4, 5, 2, 3, 6}, K = 3 
    //Output: 3 3 4 5 5 5 6
    //Explanation: 
    //Maximum of 1, 2, 3 is 3
    //Maximum of 2, 3, 1 is 3
    //Maximum of 3, 1, 4 is 4
    //Maximum of 1, 4, 5 is 5
    //Maximum of 4, 5, 2 is 5 
    //Maximum of 5, 2, 3 is 5
    //Maximum of 2, 3, 6 is 6
    /// </summary>
    class MaxOfAllSubArrayOfSizeK
    {
        /// <summary>
        /// Create a nested loop, the outer loop from starting index to n – k th elements. 
        /// The inner loop will run for k iterations.
        //Create a variable to store the maximum of k elements traversed by the inner loop.
        //Find the maximum of k elements traversed by the inner loop.
        //Print the maximum element in every iteration of outer loop
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// Time Complexity: O(N * K).
        public void printKMax_NestedLoop(int[] arr, int n, int k)
        {
            int j, max;

            for (int i = 0; i <= n - k; i++)
            {

                max = arr[i];

                for (j = 1; j < k; j++)
                {
                    if (arr[i + j] > max)
                        max = arr[i + j];
                }
                Console.Write(max + " ");
            }
        }

        //Time Complexity: O(n).
        public void pirntKmax_Deque(int[] arr, int n, int k)
        {
            // Create a Double Ended Queue, Qi will store indexes of array elements 
            // The queue will store indexes of useful  
            // elements in every window and it will 
            // keep the front value is the max one in current window

            LinkedList<int> Qi = new LinkedList<int>();
            

            /* Process first k elements of array */
            int i;
            for (i = 0; i < k; ++i)
            {
                // For every element, the previous  
                // smaller elements are useless so 
                // remove them from Qi 
                while (Qi.Count > 0 && arr[i] >= arr[Qi.Last.Value])
                {
                    Qi.RemoveLast(); // Remove from rear 
                }

                // Add new element at rear of queue 
                Qi.AddLast(i);
            }

            // Process rest of the elements,  
            // i.e., from arr[k] to arr[n-1] 
            for (; i < n; ++i)
            {
                // The element at the front of  
                // the queue is the largest element of 
                // previous window, so print it 
                Console.Write(arr[Qi.First.Value] + " ");

                //对所有过期window的元素进行删除 --从front删除
                // Remove the elements which are out of this window 
                while ((Qi.Count > 0) && Qi.First.Value <= i - k)
                {
                    Qi.RemoveFirst();
                }

                //从尾部删除 所有比当前 value 小的元素
                // Remove all elements smaller than the currently 
                // being added element (remove useless elements) 
                while ((Qi.Count > 0) && arr[i] >= arr[Qi.Last.Value])
                {
                    Qi.RemoveLast();
                }

                // Add current element at the rear of Qi 
                Qi.AddLast(i);
            }

            // Print the maximum element of last window 
            Console.Write(arr[Qi.First.Value]);

        }
    }
}
