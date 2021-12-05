using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Parlindrome
{
    public class FindLongestSubstringParlindrome
    {
        public int FindMethod(string s)
        {
            if (s == null || s.Length == 0) return 0;

            int maxResult = 0;
            int start = 0;

            int parlinedrome_start;
            int parlinedrome_end;

            while(start <= s.Length - 1)
            {
                //abcdcba
                var v1 = LongestParlindrome(start, start, s);
                //abcddcba
                var v2 = LongestParlindrome(start, start + 1, s);

                var v_max = Math.Max(v1, v2);
                if (v_max > maxResult)
                {
                    maxResult = v_max;
                    parlinedrome_start = start - (v_max - 1) / 2;
                    parlinedrome_end = start + (v_max) / 2;
                }

                start++;
            }

            return maxResult;
        }
        public int LongestParlindrome(int start, int end, string s)
        {
            if (s.Length == 0 || start > end) return 0;
            while(start >=0 && end <= s.Length - 1 && s[start] == s[end])
            {
                start--;
                end++;
            }

            //abcdcba
            return end - start - 1;
        }
    }
}
