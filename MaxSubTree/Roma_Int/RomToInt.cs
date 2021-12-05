using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Roma_Int
{
    class RomToInt
    {
        private Dictionary<char, int>  dict = 
            new Dictionary<char, int> {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
        public int RomanToInt(string s)
        {
            //result is the int
            var result = dict[s[s.Length - 1]];

            //
            for (int i = 0; i < s.Length - 1; i++)
            {
                int num = dict[s[i]];

                //后面的数大，后面的前去前面的数，就是结果
                //后面的小，后面的加前面的数 就是结果
                result += num * (dict[s[i + 1]] > num ? -1 : 1);
            }
            return result;
        }
    }
}
