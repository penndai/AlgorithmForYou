using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.SlidWindow
{
    public class MinimumWindowContainsSubstring
    {
        public string FindMinimumWindowContainsCharsInPatternString(string source, string pattern)
        {
            if (source == null || source.Length == 0 ||
                pattern == null || pattern.Length == 0)
            {
                return "";
            }
            //support all character, not just number, so here define 256.
            var patternCharTimes = new int[256];

            int left = 0;
            int right = 0;
            int count = 0;


            int min = Int32.MaxValue;
            string minString = "";

            var patternLength = pattern.Length;
            var stringLength = source.Length;

            //set all pattern char appear times
            for (int i = 0; i < patternLength; i++)
            {
                patternCharTimes[pattern[i]]++;
            }

            while (right < stringLength)
            {
                var rightChar = source[right];

                right++; // always advance one to next iteration 
                if (patternCharTimes[rightChar] > 0)
                {
                    //find how many chars in the patter string?
                    //when count == pattern string length, means find all patter string
                    //count value should be equal to the patter string length in the end
                    //when count == pattern string, means found the substring in the source string
                    count++;
                }

                // for those char not in the patter string, the value here will be minus value
                patternCharTimes[rightChar]--; // always decrement one no matter char is in pattern t or not 
                
                //shrink from left side, to find the min substring
                // move left pointer until missing one char from string t
                while (count == patternLength)
                {
                    //record currently searched min-matched substring contains pattern string
                    var size = right - left;
                    if (min > size)
                    {
                        min = size;
                        minString = source.Substring(left, right - left);
                    }
                    //record currently searched min-matched substring contains pattern string

                    // shift our window
                    var leftChar = source[left];
                    left++;  // always move left pointer
                    patternCharTimes[leftChar]++; // always increment one no matter char is in pattern t or not                    

                    if (patternCharTimes[leftChar] > 0) // that means left char is one of chars in pattern, also count as one
                    {
                        count--; //at this point, lose the matched substring to the pattern string
                    }
                }
            }

            return minString;
        }
    }
}
