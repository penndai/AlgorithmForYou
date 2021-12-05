using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class DetectCycleInUnDirectedGrapy_BFS
    {
        private List<Vertex<string>> visitedNodes;
        private Queue<Vertex<string>> queueNodes;
        public bool ContainsCycle(Graph<string> g)
        {
            var vertex = g.getAllVertex();
            if (vertex != null && vertex.Count > 0)
                queueNodes.Enqueue(vertex[0]);

            while(queueNodes.Count > 0)
            {
                var popNode = queueNodes.Dequeue();
                visitedNodes.Add(popNode);

                //enqueue the adjacent vertex
                var adjacentVertex = popNode.getAdjacentVertexes();
                foreach(var adjacent in adjacentVertex)
                {
                    //skip if already visited
                    if (visitedNodes.Contains(adjacent)) continue;

                    //if already in the queue, found the cycle
                    if (queueNodes.Contains(adjacent)) return true;

                    //else enqueue the adjacent vertex
                    queueNodes.Enqueue(adjacent);
                }
            }

            return false;
        }
    }
}
