using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Graph
{
    public class DetectCycleInUndirectedGraph
    {
        public bool hasCycleDFS(Graph<string> graph)
        {
            HashSet<Vertex<string>> visited = new HashSet<Vertex<string>>();

            foreach(var vertex in graph.getAllVertex())
            {
                if (visited.Contains(vertex))
                {
                    continue;
                }
                bool flag = hasCycleDFSUtil(vertex, visited, null);
                if (flag)
                {
                    return true;
                }
            }
            return false;
        }


        public bool hasCycleDFSUtil(Vertex<string> vertex, HashSet<Vertex<string>> visited, Vertex<string> parent)
        {
            visited.Add(vertex);
            foreach (var adjacent_vertex in vertex.getAdjacentVertexes())
            {
                if (adjacent_vertex.equals(parent))
                {
                    continue;
                }
                if (visited.Contains(adjacent_vertex))
                {
                    return true;
                }
                bool hasCycle = hasCycleDFSUtil(adjacent_vertex, visited, vertex);
                if (hasCycle)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
