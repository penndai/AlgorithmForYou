using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class PairsWithGivenSumInArray
    {
        public void FindPairsWithGivenSum(int[] arry, int sum)
        {
            if (arry.Length == 0) return; //couldn't find for empty array

            int left_index = 0;
            int right_index = arry.Length - 1;

            Array.Sort(arry);
            int count = 0;
            while(left_index < right_index)
            {
                //sum of current two numbers > target, move right index to left
                if (arry[left_index] + arry[right_index] > sum) right_index--;
                //sum of current two numbers < target, move left to right
                else if (arry[left_index] + arry[right_index] < sum) left_index++;
                else
                {
                    //find 
                    count++;
                    Console.WriteLine($"{left_index}, {right_index}");
                    left_index++;
                    right_index--;
                }

            }
        }
    }
}
