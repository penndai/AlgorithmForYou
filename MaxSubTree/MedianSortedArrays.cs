using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class MedianSortedArrays
    {
        /// <summary>
        /// partition 2 个 sorted array
        /// x1 x2 x3 x4 x5 c6
        /// y1 y2 y3 y4 y5 y6 y7 y8
        /// 先计算x 数组的 开始的partition 位置 ---》从x数组的中间位置开始 (0+5)/2 = 2
        /// 所以partitionx = 2, 左边的partition就先从2个元素开始，变成 x1 x2 | x3 x4 x5 x6
        /// 
        /// y数组的partition 就是 （x.length + y.length）/2 - partitionX = (6+8)/2- 2 =5
        /// 所以y数组的partition就是 y1 y2 y3 y4 y5 | y6 y7 y8
        /// 
        /// Found:
        ///  maxleftX <= minrightY && maxleftY <= minrightX
        ///  
        /// else if
        ///     maxleftX > minrightY ---> move toward left in X就是 x数组的partition往左移
        /// else
        ///     move toward right in x x数组的partition往右移
        /// 
        /// partitionx + partitiony = （x 数组的长度 + y数组的长度）/2
        /// 
        /// 
        /// lefx 是 x数组的左 partition, rightx 是 x 数组的右 partition
        /// lefty是y数组的做部分partition,rightx是有数组的右partition
        /// 
        /// 最后如果 merged array 是odd奇数， median 值是 avg(max(leftx, lefty), min(rightx, righy))
        /// 如果最后merged array 是 even偶数, median 是 max(leftx, lefty)
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static double FindMedianIn2SortedArrays(int[] input1, int[] input2)
        {
            //make sure the input1 length is less than input2
            if (input1.Length > input2.Length) FindMedianIn2SortedArrays(input2, input1);

            int x = input1.Length;
            int y = input2.Length;

            //start and end values of the short array
            int low = 0; int high = x;

            while(low <= high)
            {
                //the element numbers on the left side of x 
                int partitionX = (low + high) / 2;
                //the element numbers on the left side of y
                int partitionY = (x + y + 1) / 2 - partitionX;
                //if partitionX is 0, nothing is left on the x, set to -INF
                int maxLeftX = (partitionX == 0) ? int.MinValue : input1[partitionX - 1];
                //if partitionX is length of array, nothing left on the right, set min right value to INF
                int minRightX = (partitionX == x) ? int.MaxValue : input1[partitionX];

                //same to the second array
                int maxLeftY = (partitionY == 0) ? int.MinValue : input2[partitionY - 1];
                int minRightY = (partitionY == y) ? int.MaxValue : input2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    //found - the partition array at right positions
                    //get max of left two arrays, and min of right 2 arrays 
                    if ((x + y) % 2 == 0)
                    {
                        return ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    else
                    {
                        return (double)Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                {
                    //too far on the right side for x array, move left forward
                    high = partitionX - 1;
                }
                else
                    //too far on the left side for x array, move right forward
                    low = partitionX + 1;
            }

            throw new InvalidOperationException();
        }

    }
}
