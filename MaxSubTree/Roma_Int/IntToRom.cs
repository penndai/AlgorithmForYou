using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class IntToRom
    {
        public static string IntToRoman(int num)
        {
            int[] values = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] words = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            StringBuilder st = new StringBuilder();
            int count = 0;

            // from end to start, iterate the interger
            for (int i = values.Length - 1; i >= 0 && num > 0; i--)
            {
                // calculat the int value after divided by the interger
                count = num / values[i];
                while (count > 0)
                {
                    st.Append(words[i]);

                    //calculate multiple same Roma words
                    count--;

                    //update the value, by substract the value (1000 or 900 or 500 etc)
                    num -= values[i];
                }
            }

            return st.ToString();
        }
    }
}
