using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class StringToInt
    {
        public static int MyAtoi(string str)
        {
            long result = 0;
            var sign = 1;
            str = str.Trim();
            if (string.IsNullOrEmpty(str)) return 0;
            int index = 0;

            //determine the sign positive or negative according to the first char
            if (str[0] == '+' || str[0] == '-')
            {
                sign = str[0] == '+' ? 1 : -1;
                index++;
            }

            //iterate the string until first non-number char
            while (index < str.Length)
            {
                if (char.IsNumber(str[index]))
                {
                    //calculate the number value of num char by using minus '0' char
                    result = result * 10 + str[index] - '0';
                    if (result * sign > int.MaxValue) return int.MaxValue;
                    if (result * sign < int.MinValue) return int.MinValue;
                }
                else
                {
                    break;
                }
                index++;
            }
            return (int)result * sign;
        }
    }
}
