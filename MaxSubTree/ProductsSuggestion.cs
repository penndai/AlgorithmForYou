using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class TrieNode
    {
        char data;
        public string LetterAsString => this.data.ToString();
        public TrieNode[] children;
        public Boolean EndOfWord;
        public int count;

        public TrieNode(char data)
        {
            this.data = data;
            children = new TrieNode[26];
            this.EndOfWord = false;
            this.count = 0;
        }
    }

    public class Trie_ProductSearchSuggestion
    {
        public TrieNode root;
        public Trie_ProductSearchSuggestion()
        {
            root = new TrieNode('\0');
        }

        public void add(TrieNode root, string word)
        {
            if (word.Length == 0)
            {
                root.EndOfWord = true;
                root.count++;
                return;
            }

            int childIndex = word[0] - 'a';
            TrieNode child = root.children[childIndex];
            if (child == null)
            {
                child = new TrieNode(word[0]);
                root.children[childIndex] = child;
            }

            add(child, word.Substring(1));

        }

        public void add(String word)
        {
            add(root, word);
        }

        static int currentWordNumber = 0;

        public void GetWordsStartWithWord(TrieNode root, String searchedWord, List<String> words)
        {

            if (root.EndOfWord)
            {
                for (int j = 0; j < root.count; j++)
                {
                    //add the searched word
                    words.Add(searchedWord);
                    currentWordNumber++;
                    //only return first 3 words
                    if (currentWordNumber == 3) return;
                }
            }

            for (int j = 0; j < 26; j++)
            {
                TrieNode child = root.children[j];
                if (child == null) continue;
                //(char)(97 + j)
                GetWordsStartWithWord(child, searchedWord + child.LetterAsString, words); //'a'= 97 char
                if (currentWordNumber == 3) return;
            }

            return; 
        }

        public List<String> search_helper(
            TrieNode trieNode, 
            string searchWord, int searchCharIndex, int searchWordLength)
        {
            // search to the end of the search word
            if (searchCharIndex == searchWordLength)
            {
                currentWordNumber = 0;
                List<String> l = new List<string>();
                //get all words start with word
                GetWordsStartWithWord(trieNode, searchWord, l);
                return l;
            }

            int child_index = searchWord[searchCharIndex] - 'a';
            TrieNode child = trieNode.children[child_index];
            if (child == null) return new List<string>();

            // iterate to the last child TrieNode - 
            //e.g. if search word is "mou", recursive to the child trie node 'u' to find whether the whole word existing or not.
            return search_helper(trieNode.children[child_index], searchWord, searchCharIndex + 1, searchWordLength);
        }

        public List<String> search(String word)
        {
            return search_helper(root, word, 0, word.Length);
        }
    }

    class ProductsSuggestion
    {
        /// <summary>
        /// Given an array of strings products and a string searchWord. 
        /// We want to design a system that suggests at most three product names from products 
        /// after each character of searchWord is typed. Suggested products should have common 
        /// prefix with the searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.
        //Return list of lists of the suggested products after each character of searchWord is typed.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="searchWord"></param>
        /// <returns></returns>
        public static List<List<String>> suggestedProducts(String[] products, String searchWord)
        {
            Trie_ProductSearchSuggestion t = new Trie_ProductSearchSuggestion();
            List<List<String>> ans = new List<List<string>>();
            //build the trie
            for (int i = 0; i < products.Length; i++) t.add(products[i]);

            String prefix = "";

            for (int i = 0; i < searchWord.Length; i++)
            {
                //search entered char - e.g. the search text is mobile : m, mo, mob ...
                prefix += searchWord[i];

                //add each search result to the answer list.
                ans.Add(t.search(prefix));
            }

            return ans;
        }
    }
}
