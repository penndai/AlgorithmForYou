using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    //寻找 sum 最大的 sub array
    //关键是 设置两个 sum 变量
    // 一个是 当前 最大 sum: max_sum
    // 一个是 动态变化的 截止目前的sum: so_far_sum, 如果 so_far_sum > max_sum, max_sum 更新
    // 更重要的是 如果 so_far_sum <0,要将so_far_sum reset 成0
    // 这样表示 后面重新 累加的时候，有没有可能 大过前面已经存在的 max_sum
    // 为了保存最大 sub array的位置，在每次 reset so_far_sum =0的时候，要记录下 后一个 使得 so_far_sum >0的
    //元素的位置，因为这可能是最大 sub array的起始位置
    //而最大sub array的终止位置是在每次 更新 max_sum的时候的当前元素位置
    public class MaximumSumContigousSubArray
    {
        public void FindMaxSumContigousSubArray(int[] arr)
        {
            //max value so far - not change if searching see minus value
            int max_so_far = 0;

            //dynamically changed value - in searching process
            int sumValue_ending_here_in_searching = 0;

            //max sub array start pointer
            int maxSubArray_Start = 0;

            //max sub array end pointer
            int maxSubArray_End = 0;

            //if dynamically updated value is back to 0, the next element could be the 
            //potentially start of max sub array
            int potential_start = 0;

            max_so_far = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                sumValue_ending_here_in_searching = max_so_far + arr[i];
                if(sumValue_ending_here_in_searching > max_so_far)
                {
                    max_so_far = sumValue_ending_here_in_searching;
                    maxSubArray_Start = potential_start;
                    maxSubArray_End = i;
                }

                if(sumValue_ending_here_in_searching < 0)
                {
                    potential_start = i + 1;
                    sumValue_ending_here_in_searching = 0;
                }
            }

            //in the end, the maxSubArray_Start and maxSubArray_End identify the sub array
            //max_so_far is the max value of sub array
        }
    }
}
