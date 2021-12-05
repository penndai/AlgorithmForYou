using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    // C# program to find Intersection of 
    // two sorted arrays 

    using System;

    class DuplicateNumbersInSortedArray
    {
        /* Function prints Intersection of arr1[] 
        and arr2[] m is the number of elements in arr1[] 
        n is the number of elements in arr2[] */
        public static void printIntersection(int[] arr1,
                            int[] arr2, int m, int n)
        {
            int i = 0, j = 0;

            while (i < m && j < n)
            {
                if (arr1[i] < arr2[j])
                    i++;
                else if (arr2[j] < arr1[i])
                    j++;
                else
                {
                    Console.Write(arr2[j++] + " ");
                    i++;
                }
            }
        }       
    }    

}
