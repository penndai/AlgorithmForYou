using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class TwoSum
    {
        /**
         * @param nums an integer array
         * @param target an integer
         * @return the difference between the sum and the target
         */
        public static int[] twoSumCloset(int[] nums, int target)
        {
            int[] res = new int[2];
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                //current number 
                if (d.ContainsKey(nums[i]))
                {
                    res[0] = d[nums[i]];
                    res[1] = i;
                    return res;
                }

                //store the value: [target-current number] as the key, current index as value
                //following iteration, if we found the matched [target-current number], it means
                //find the result.
                d[target - nums[i]] = i;
            }
            return res;
        }
    }
}
