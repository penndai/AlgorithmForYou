using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Graph
{
    public class DetectCycleInDirectedGraph_White_Grey_Black
    {
        //white list
        private List<Vertex<string>> UnVisited;
        //black list
        private List<Vertex<string>> Visited;
        //current visiting list
        private List<Vertex<string>> Visiting;

        public bool HasCycle(Graph<string> g)
        {
            var vertex = g.getAllVertex();
            foreach(var v in vertex)
            {
                UnVisited.Add(v);
            }

            while(UnVisited.Count > 0)
            {
                var unVisit_Vertex = UnVisited[0];

                if (HasCycle(unVisit_Vertex, UnVisited, Visiting, Visited))
                {
                    return true;
                }                
            }

            return false;
        }

        private bool HasCycle(
            Vertex<string> unVisit_Vertex, 
            List<Vertex<string>> unVisited, 
            List<Vertex<string>> visiting, 
            List<Vertex<string>> visited)
        {
            //move current from unvisited to visiting
            unVisited.Remove(unVisit_Vertex);
            visiting.Add(unVisit_Vertex);

            //dfs for each adjacent vertex
            var adjacents = unVisit_Vertex.getAdjacentVertexes();
            foreach(var v in adjacents)
            {
                if (visited.Contains(v)) continue;
                if (visiting.Contains(v)) return true;

                if (HasCycle(v, unVisited, visiting, visited))
                    return true;
            }

            //move current vertext to the visited list            
            visited.Add(unVisit_Vertex);

            return false;
        }
    }
}
