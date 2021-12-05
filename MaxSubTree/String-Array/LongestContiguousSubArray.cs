using System;

namespace Algorithm_Multiple.String_Array
{
    public class LongestContiguousSubArray
    {
        public int findLength(int[] arr, int n)
        {
            int max_len = 1; // Initialize result 
            for (int i = 0; i < n - 1; i++)
            {
                // Initialize min and max for all  
                // subarrays starting with i 
                int min = arr[i], max = arr[i];

                // Consider all subarrays starting  
                // with i and ending with j 
                for (int j = i + 1; j < n; j++)
                {
                    // Update min and max in this 
                    // subarray if needed 
                    min = Math.Min(min, arr[j]);
                    max = Math.Max(max, arr[j]);

                    // If current subarray has all 
                    // contiguous elements 
                    if ((max - min) == j - i)
                        max_len = Math.Max(max_len,
                                      max - min + 1);
                }
            }
            return max_len; // Return result 
        }
    }
}
