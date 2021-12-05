using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Multiple
{
    class TopKWordsFrequency
    {
               
        private static Dictionary<string, int> d = new Dictionary<string, int>();
        
        public static IList<string> GetTopKeywords(string[] words, int k)
        {

            // populate frequency map
            foreach (string w in words)
            {
                if (d.Keys.Contains(w))
                {
                    d[w]++;
                }
                else
                {
                    d.Add(w, 1);
                }
            }

            List<string> allKeywords = new List<string>(d.Keys);

            // sort all strings with custom comparison
            allKeywords.Sort(myComp);

            List<string> res = new List<string>();

            // take first k strings
            for (int i = 0; i < k; i++)
            {
                res.Add(allKeywords[i]);
            }

            return res;
        }

        private static int myComp(string x, string y)
        {
            if (d[x] > d[y]) return -1;
            if (d[x] < d[y]) return 1;
            return string.Compare(x, y);
        }
    
        public static string[] GetTopKeywords_simple(int k, string[] keywords, string[] reviews)
        {
            var keywordsDictionary = new Dictionary<string, int>();
            foreach (var key in keywords)
            {
                int count = reviews.Count(x => x.ToLower().Contains(key.ToLower()));
                List<string> v = new List<string>();
                
                keywordsDictionary.Add(key, count);
            }

            return keywordsDictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).Take(k).ToArray();

        }
    }
}
