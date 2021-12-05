using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class BubbleSorting
    {
        public static int[] BubbleSort(int[] values)
        {
            int t;
            
            for (int j = 0; j < values.Length - 1; j++)
            {
                for (int i = 0; i < values.Length -j - 1; i++)
                {
                    if (values[i] > values[i + 1])
                    {
                        t = values[i + 1];
                        values[i + 1] = values[i];
                        values[i] = t;
                    }
                }
            }
            return values;
        }
    }
}
