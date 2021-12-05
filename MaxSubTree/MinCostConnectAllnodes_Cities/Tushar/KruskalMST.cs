using Algorithm_Multiple.Tushar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.MinCostConnectAllnodes_Cities.Tushar
{
    public class KruskalMST
    {
        public class EdgeComparator : IComparer<Edge> {         
            public int Compare(Edge edge1, Edge edge2)
            {
                if (edge1.getWeight() <= edge2.getWeight())
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        //public List<Edge<int>> getMST(Graph<int> graph)
        //{
        //    List<Edge<int>> allEdges = graph.getAllEdges();
        //    EdgeComparator edgeComparator = new EdgeComparator();

        //    //sort all edges in non decreasing order
        //    Collections.sort(allEdges, edgeComparator);
        //    DisjointSet disjointSet = new DisjointSet();

        //    //create as many disjoint sets as the total vertices
        //    foreach(Vertex<int> vertex in graph.getAllVertex())
        //    {
        //        disjointSet.makeSet(vertex.getId());
        //    }

        //    List<Edge<int>> resultEdge = new List<Edge<int>>();

        //    foreach(Edge<int> edge in allEdges)
        //    {
        //        //get the sets of two vertices of the edge
        //        long root1 = disjointSet.findSet(edge.getVertex1().getId());
        //        long root2 = disjointSet.findSet(edge.getVertex2().getId());

        //        //check if the vertices are in same set or different set
        //        //if verties are in same set then ignore the edge
        //        if (root1 == root2)
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            //if vertices are in different set then add the edge to result and union these two sets into one
        //            resultEdge.Add(edge);
        //            disjointSet.union(edge.getVertex1().getId(), edge.getVertex2().getId());
        //        }

        //    }
        //    return resultEdge;
        //}
    }
}
