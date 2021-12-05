// C# program to determine if array arr[] 
// can be split into three equal sum sets. 
using System;
using System.Collections.Generic;
using System.Linq;

namespace Equal3Subset
{
    class Dynamicprogramming_Partition
    {
        public bool partition(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            if (sum % 3 != 0)
            {
                return false;
            }
            sum = sum / 3;

            List<bool[]> T = new List<bool[]>();


            for (int i = 0; i <= arr.Length; i++)
            {
                T.Add(new bool[sum + 1]);
                T[i][0] = true;
            }

            List<int> selectedNumber = new List<int>();
            for (int i = 1; i <= arr.Length; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (j - arr[i - 1] >= 0)
                    {
                        //上一行的同列值 || 后者是上一行往前 arr[i-1] 个数的值的 
                        T[i][j] = T[i - 1][j - arr[i - 1]] || T[i - 1][j];
                    }
                    else
                    {
                        //针对array[i-1]比 sum 大的之前的数，都copy上一行的
                        T[i][j] = T[i - 1][j];
                    }

                    if (T[i][j])
                    {
                        selectedNumber.Add(arr[i-1]);
                        selectedNumber.Add(sum - arr[i-1]);
                       
                        //when find sum = arr[i] + arr[another_index];
                        //return or update the array
                        //var index = Array.FindIndex(arr, x => x == sum - arr[i]);
                        //arr[index] = int.MaxValue;
                        //arr[i] = int.MaxValue;
                        
                    }
                }
            }

            return T[arr.Length][sum];
        }

        /// <summary>
        ///   0 1 2 3 4 5 6 7 8
        /// 1 T T F F F F F F f
        /// 2 T T T T F F F F F 
        /// 4 T T T T T T T T F
        /// 5 T T T T T T T T T
        /// T[i][j] = T[i-1][j] || T[i-1][j-currntNum]
        /// </summary>
        /// <param name="input"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public bool subsetSum_dynamicProgramming(int[] input, int total)
        {

            List<bool[]> T = new List<bool[]>();
            for (int i = 0; i <= input.Length; i++)
            {
                T.Add(new bool[total + 1]);
                T[i][0] = true;
            }

            for (int i = 1; i <= input.Length; i++)
            {
                for (int j = 1; j <= total; j++)
                {
                    if (j - input[i - 1] >= 0)
                    {
                        T[i][j] = T[i - 1][j] || T[i - 1][j - input[i - 1]];
                    }
                    else
                    {
                        T[i][j] = T[i - 1][j];
                    }
                }
            }
            return T[input.Length][total];

        }
    }
    class PartitionEqualSubsetSum
    {
        public bool canPartition(int[] nums)
        {
            int total = 0;
            foreach (var n in nums) total += n;

            if (total % 3 != 0) return false;

            return canPartitionUtil_Recursive(nums, 0, 0, total, new Dictionary<string, bool>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index"></param>
        /// <param name="currentSum"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        private bool canPartitionUtil_Recursive(int[] nums, int index, 
            int currentSum, int total, Dictionary<string, bool> state)
        {
            string currentKey = index + " " + currentSum;
            if (state.ContainsKey(currentKey))
            {
                return state[currentKey];
            }

            if (currentSum * 3 == total) return true;

            if (currentSum > total / 3 || index >= nums.Length) return false;

            //first recursion method for each single number, check
            //如果只考虑单个number,是否能满足partition的条件。
            //成功的例子是  有一个大数 它的值正好 等于 sum / 3
            var canPartitionBySingleNumber = canPartitionUtil_Recursive(nums, index + 1, currentSum, total, state);


            //second recursion method for current sum + next number
            //考虑当前sum加上 下一个 数字，是否能满足partition的条件
            var canPartitionByAccumulationAfterNumber =
                canPartitionUtil_Recursive(nums, index + 1, currentSum + nums[index], total, state);

            state.Add(currentKey, canPartitionBySingleNumber|| canPartitionByAccumulationAfterNumber);

            return canPartitionBySingleNumber || canPartitionByAccumulationAfterNumber;
        }
    }
    class Equal3Subset
    {
        // First segment's end index 
        public int pos1 = -1;

        // Third segment's start index 
        public int pos2 = -1;

        public bool equiSum(int[] arr)
        {
            int n = arr.Length;

            // Prefix Sum Array 
            int[] pre = new int[n];
            int sum = 0, i;
            for (i = 0; i < n; i++)
            {
                sum += arr[i];
                pre[i] = sum;
            }

            // Suffix Sum Array 
            int[] suf = new int[n];
            sum = 0;
            for (i = n - 1; i >= 0; i--)
            {
                sum += arr[i];
                suf[i] = sum;
            }

            // Stores the total sum of the array 
            int total_sum = sum;

            int j = n - 1;
            i = 0;
            while (i < j - 1)
            {
                if (pre[i] == total_sum / 3)
                {
                    pos1 = i;
                }

                if (suf[j] == total_sum / 3)
                {
                    pos2 = j;
                }

                if (pos1 != -1 && pos2 != -1)
                {

                    // We can also take pre[pos2 - 1] - pre[pos1] == 
                    // total_sum / 3 here. 
                    if (suf[pos1 + 1] - suf[pos2] == total_sum / 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (pre[i] < suf[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return false;

        }

        public bool CanThreePartsEqualSum_way2(int[] A)
        {
            int sum = 0;
            for (int i = 0; i < A.Length; i++) sum += A[i];

            if (sum % 3 != 0) return false;

            int portion = sum / 3;

            int headSum = 0;
            int sumFound = 0;

            for (int i = 0; i < A.Length; i++)
            {
                headSum += A[i];
                if (headSum == portion)
                {
                    sumFound++;
                    headSum = 0;
                }
            }
            return sumFound == 3;
        }

        // Function to determine if array arr[] 
        // can be split into three equal sum sets. 
        public bool CanThreePartsEqualSum(int[] arr)
        {
            int sum = 0;
            //dynamic sum for each element
            // array : 2, 4 3 3 2 2 2
            // sum: 2 6 9 12 14 16 18
            // when TotalSum(18)/3 =6, 2*TotalSum/3 = 12 in the sum array, means 
            // must have two sub set

            int[] idx2Sum = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                idx2Sum[i] = sum;
            }

            if (sum % 3 != 0)
            {
                return false;
            }

            int targetSumPart = sum / 3;
            bool part1Found = false;
            bool part2Found = false;

            // array : 2, 4 3 3 2 2 2
            // sum: 2 6 9 12 14 16 18
            for (int i = 0; i < arr.Length; i++)
            {
                if (idx2Sum[i] == targetSumPart)
                {
                    part1Found = true;
                    continue;
                }

                if (idx2Sum[i] == 2 * targetSumPart)
                {
                    //accumulation total = 2 * target sum
                    //and part 1 already found, means part 2 also found
                    if (part1Found)
                    {
                        part2Found = true;
                    }
                }
            }

            return part1Found && part2Found;
        }
    }

}
