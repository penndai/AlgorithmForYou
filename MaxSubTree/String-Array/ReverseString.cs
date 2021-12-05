using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.String_Array
{
    public class ReverseString
    {
        public string Reverse(char[] str)
        {
            // Initialize left and right pointers  
            int r = str.Length - 1, l = 0;

            // Traverse string from both ends until  
            // 'l' and 'r'  
            while (l < r)
            {
                // Ignore special characters  
                if (!char.IsLetter(str[l]))
                    l++;
                else if (!char.IsLetter(str[r]))
                    r--;

                // Both str[l] and str[r] are not spacial  
                else
                {
                    char tmp = str[l];
                    str[l] = str[r];
                    str[r] = tmp;
                    l++;
                    r--;
                }
            }

            return new string(str);
        }
    }
}
