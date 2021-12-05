using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Trie
{
    /// <summary>
    /// Trie is a tree structure used for storing collections of string 
    /// If two strings have same prefix, they will have the same ancestor in this tree
    /// 
    /// for thousands of string, use trie to store them, with high performance to search 
    /// whether a string existing 
    /// e.g. Trie is ideal structure to store the dictionary.
    /// </summary>
    public class Trie
    {
        private class TrieNode
        {
            public Dictionary<Char, TrieNode> children;
            public bool endOfWord;
            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
                endOfWord = false;
            }
        }

        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            // start from the root trie node
            TrieNode current = root;
            for(int i=0;i< word.Length; i++)
            {
                //retrieve the each char in the string
                char ch = word[i];
                TrieNode node = current.children[ch];
                if(node == null) //not existing
                {
                    node = new TrieNode();
                    current.children.Add(ch, node);
                }
                //update the current to newly added node
                current = current.children[ch];
            }

            // set the end flag
            current.endOfWord = true;
        }

        public bool Search(string word)
        {
            //current search node
            TrieNode searchNode = root;
            for(int i = 0; i < word.Length; i++)
            {
                char ch = word[i]; //current search for char
                if(searchNode.children[ch] != null)
                {
                    //is current node contains search char
                    //loop down to next level children for next char
                    searchNode = searchNode.children[ch];
                }
                else
                {
                    //could not find
                    return false;
                }
            }
            //only when the last char node end flag is true
            return searchNode.endOfWord;
        }
        public void InsertRecursive(string word)
        {
            InsertRecursive(root, word, 0);
        }

        private void InsertRecursive(TrieNode node, string word, int index)
        {
            if(index == word.Length)
            {
                node.endOfWord = true;
                return;
            }

            char ch = word[index];
            TrieNode child = node.children[ch];
            if(child == null)
            {
                child.children.Add(ch, new TrieNode());
            }

            //continue search next char
            InsertRecursive(child, word, index+1);
        }

        public bool SearchRecursive(string word)
        {
            return SearchRecursive(word, root, 0);
        }

        private bool SearchRecursive(string word, TrieNode node, int index)
        {
            if (index == word.Length) return node.endOfWord;

            char ch = word[index];
            TrieNode child = node.children[ch];
            if (child == null) return false;

            return SearchRecursive(word, child, index++);
        }

        public void Delete(string word)
        {
            Delete(root, word, 0);
        }

        private bool Delete(TrieNode node, string word, int index)
        {
            if(index == word.Length)
            {
                if (!node.endOfWord) return false; //the word currently searched is not a end word
                else
                {
                    //set the flag to false means delete the word from the dictionary
                    node.endOfWord = false;
                    //if current node has no childre, will delete it
                    return node.children.Count == 0;
                }
            }

            char ch = word[index];
            TrieNode child = node.children[ch];
            if (child == null) return false;

            bool shouldDelete = Delete(child, word, index++);
            if (shouldDelete)
            {
                node.children.Remove(ch);
                return node.children.Count == 0;
            }

            return false;
        }
    }
}
