// C# program to find the 
// longest substring of vowels. 
using System;
namespace LongestVowels
{
    /// <summary>
    /// Longest string made up of only vowels
    /// 
    /// You are given with a string . 
    /// Your task is to remove atmost two substrings of any length from the given string 
    /// such that the remaining string contains vowels('a','e','i','o','u') only. 
    /// Your aim is the maximise the length of the remaining string. 
    /// Output the length of remaining string after removal of atmost two substrings.
    /// </summary>
    class LongestVowels
    {
        private bool isVowel(char c)
        {
            return (c == 'a' || c == 'e' || c == 'i'
                    || c == 'o' || c == 'u');
        }

        public int longestVowel(String s)
        {
            int start = 0;
            int end = s.Length - 1;
            while(start <= end && isVowel(s[start]))
            {
                start++;
            }

            if (start >= end) return s.Length;

            while (end >= 0 && isVowel(s[end])) end--;

            //alreadyFound_FromStartAndEnd is after moving start and end, 
            //already found the number of vowel letters
            int alreadyFound_FromStartAndEnd = s.Length - end + start - 1;

            //now iterate the remaining words, to find the max lenth vowel letters
            int sum = 0;
            int max = 0;

            for(int i = start; i <= end; i++)
            {
                if (isVowel(s[i]))
                {
                    sum++;
                }
                else //as long as the current letter is not vowel, reset the sum to 0
                {
                    sum = 0;
                }

                max = Math.Max(sum, max);
            }

            return max + alreadyFound_FromStartAndEnd;
        }


    }
}

// This code is contributed by nitin mittal 
