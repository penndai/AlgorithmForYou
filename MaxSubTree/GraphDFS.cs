using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class GraphDFS
    {
        private int V; // No. of vertices  

        // Array of lists for  
        // Adjacency List Representation  
        // all connected nodes for the specific node
        // 0 [1,2] - node 1 and node 2 are connected to node 0
        // 1 [0,2] - node 0 and node 2 are connected to node 1
        // ....
        private List<int>[] adj;

        // Constructor  
        public GraphDFS(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }
        //Function to Add an edge into the graph  
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Add w to v's list.  
        }

        // A function used by DFS  
        private void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited 
            // and print it  
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices  
            // adjacent to this vertex  
            List<int> vList = adj[v];
            foreach (var n in vList)
            {
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        // The function to do DFS traversal.  
        // It uses recursive DFSUtil()  
        //start from v node
        public void DFS(int v)
        {
            // Mark all the vertices as not visited 
            // (set as false by default in c#)  
            bool[] visited = new bool[V];

            // Call the recursive helper function  
            // to print DFS traversal  
            DFSUtil(v, visited);
        }

    }
}
