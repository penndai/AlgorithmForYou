using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.String_Array
{
    public class ZigZag
    {
        public void zigZag(int[] arr)
        {
            // Flag true indicates relation "<" is expected, 
            // else ">" is expected.  The first expected relation 
            // is "<" 
            bool flag = true;

            int temp = 0;

            for (int i = 0; i <= arr.Length - 2; i++)
            {
                if (flag)  /* "<" relation expected */
                {
                    /* If we have a situation like A > B > C, 
                       we get A > B < C by swapping B and C */
                    if (arr[i] > arr[i + 1])
                    {
                        // swap 
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }

                }
                else /* ">" relation expected */
                {
                    /* If we have a situation like A < B < C, 
                       we get A < C > B by swapping B and C */
                    if (arr[i] < arr[i + 1])
                    {
                        // swap 
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
                flag = !flag; /* flip flag */
            }
        }
    }
}
