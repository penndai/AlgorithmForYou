using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class Graph_DetectCycleInDirectedGraph
    {
        //count of vertex
        public readonly int V;
        //Adjancents - edges
        public readonly List<List<int>> Adjacents;

        public Graph_DetectCycleInDirectedGraph(int V)
        {
            this.V = V;
            Adjacents = new List<List<int>>(V);

            for (int i = 0; i < V; i++)
                Adjacents.Add(new List<int>());
        }

        public void addEdge(int source, int destination)
        {
            Adjacents[source].Add(destination);
        }
    }
    public class DetectCycleInGraph
    {
        private Graph_DetectCycleInDirectedGraph graph = new Graph_DetectCycleInDirectedGraph(4);
        
        public DetectCycleInGraph()
        {
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(1, 2);
            graph.addEdge(2, 0);
            graph.addEdge(2, 3);
            graph.addEdge(3, 3);
        }

        /// <summary>
        /// Algorithm:
        /// Create the graph using the given number of edges and vertices.
        /// Create a recursive function that that current index or vertex, visited, and recusrsion stack.
        /// Mark the current node as visited and also mark the index in recursion stack.
        /// Find all the vertices which are not visited and are adjacent to current node. 
        /// Recursively call the function for those vertices, 
        /// If the recursive function returns true return true.
        /// If the adjacent vertices are already marked in the recursion stack then return true.
        /// Create a wrapper class, that calls the recursive function for all the vertices and if any function returns true return true. Else if for all vertices the function returns false return false.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="visited"></param>
        /// <param name="recursiveStack"></param>
        /// <returns></returns>
        private bool IsCycleInGraphRecursive(int i, bool[] visited, 
            bool[] recursiveStack, List<List<int>> adjacents)
        {
            // Mark the current node as visited and  
            // part of recursion stack 

            //If current vertex already in the recursion stack, means found the cycle
            if (recursiveStack[i])
                return true;

            // already visited - maybe some other edges also have this vertex as destination
            // on the other word, other edges have same destination which is current i vertex
            if (visited[i])
                return false;

            visited[i] = true;

            recursiveStack[i] = true;
            List<int> children = adjacents[i];

            foreach (int c in children)
                if (IsCycleInGraphRecursive(c, visited, recursiveStack, adjacents))
                    return true;

            // if the vertex has no children, means this vertex is impossible the part of 
            // cycle, set to false
            // if all children of the node are not recursive cycle, reset the current node
            // to false in the recursive stack
            recursiveStack[i] = false;

            return false;
        }
        public bool isCycleInGraph()
        {
            // Mark all the vertices as not visited and  
            // not part of recursion stack  
            bool[] visited = new bool[graph.V];
            bool[] recStack = new bool[graph.V];

            // Call the recursive helper function to  
            // detect cycle in different DFS trees  
            for (int i = 0; i < graph.V; i++)
                if (IsCycleInGraphRecursive(i, visited, recStack, graph.Adjacents))
                    return true;

            return false;
        }
    }
}
