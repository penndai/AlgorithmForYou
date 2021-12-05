using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class ParitionLabel
    {
        public static IList<int> CalculatePartitionLabels(string S)
        {
            var last_index_array = new int[26];
            var collection = new List<int>();
            int i = 0;

            for (i = 0; i < S.Length; i++)
                last_index_array[S[i] - 'a'] = i;
            
            var start = 0;

            while (start < S.Length)
            {
                int next_char_index = start;
                int begin = i;
                int lastindex = last_index_array[S[start] - 'a'];

                while (next_char_index < lastindex)
                {
                    lastindex = Math.Max(last_index_array[S[next_char_index]], lastindex);
                    
                    next_char_index++;                    
                }

                collection.Add(next_char_index - start + 1);

                start = next_char_index + 1;
            }

            return collection;
        }
    }
}
