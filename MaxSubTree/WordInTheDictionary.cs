using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    /// <summary>
    /// 
    /// </summary>
    class WordInTheDictionary
    {
        public static bool DoWordBreak(string s, IList<string> wordDict)
        {
            var trie = new WordTrie('#');
            foreach (var word in wordDict)
            { // load dict to trie
                var tmp = trie;
                foreach (var c in word)
                {
                    var index = c - 'a';
                    if (tmp.Chars[index] == null)
                    {
                        tmp.Chars[index] = new WordTrie(c);
                    }
                    tmp = tmp.Chars[index];
                }
                tmp.End = true;   // mark word end, it is important so when you have one Trie chain of h->e->l->l->o and 
            }                     // you know it contains "hell" and "hello" 2 words if the 2nd l and o are marked as End = true

            var cache = new Dictionary<string, bool>();   // init memoisation
            return Dfs(s, trie, cache);
        }
        private static bool Dfs(string s, WordTrie trie, Dictionary<string, bool> cache)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;  // when this happens means the original string can be broken to the word dict
            }

            if (cache.ContainsKey(s)) return cache[s]; // if the string is searched before, no need search again

            var tmp = trie;
            var match = false;
            for (var i = 0; i < s.Length; i++)
            {  // check every char through the Trie chain from the beginning
                var index = s[i] - 'a';
                if (tmp.Chars[index] == null)
                {   // if no char exist in its Trie positio then there is no match for the input string
                    match = false;
                    break;
                }
                else
                {
                    tmp = tmp.Chars[index];
                    if (tmp.End)
                    {
                        // if reach a End == true means we matched a word, then from here we
                        match |= (Dfs(s.Substring(i + 1), trie, cache));  // start a dfs search for the sub string. If the recursion return true
                        if (match) break;                                 // then break the loop since we have positive result.
                    }                                                     // otherwise the loop continue to find the next word End in this Trie chain
                }
            }

            cache[s] = match;   // save search result to memoistion
            return match;
        }

    }

    class WordTrie
    {
        public WordTrie(char c)
        {
            Char = c;
        }
        public char Char;
        public WordTrie[] Chars = new WordTrie[26];
        public bool End;
    }
}
