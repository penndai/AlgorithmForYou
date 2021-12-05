using Algorithm_Multiple.Tushar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class Dijkstra_MinHeap
    {
        //min heap
        public BinaryMinHeap<Vertex> minHeap = new BinaryMinHeap<Vertex>();
        //vertex distance mapping
        public Dictionary<Algorithm_Multiple.Tushar.Vertex, int> distance = new Dictionary<Algorithm_Multiple.Tushar.Vertex, int>();
        //vertex - path parent vertex mapping
        public Dictionary<Algorithm_Multiple.Tushar.Vertex, Algorithm_Multiple.Tushar.Vertex> path_parent = 
            new Dictionary<Algorithm_Multiple.Tushar.Vertex, Algorithm_Multiple.Tushar.Vertex>();

        public Dictionary<Vertex, int> FindMinPathCost_Dijkstra(Algorithm_Multiple.Tushar.Graph graph, Vertex sourceVertex)
        {
            //initialize all vertex with infinite distance from source vertex
            foreach(var vertex in graph.getAllVertex())
            {
                minHeap.add(int.MaxValue, vertex);
            }


            //set distance of source vertex to 0
            minHeap.decrease(sourceVertex, 0);

            //put it in map
            distance.Add(sourceVertex, 0);
            //source vertex parent is null
            path_parent[sourceVertex] = null;

            //iterate till heap is not empty
            while (!minHeap.empty())
            {
                //get the min value from heap node which has vertex and distance of that vertex from source vertex.
                var heapNode = minHeap.extractMinNode();
                Vertex current = heapNode.key;

                //update shortest distance of current vertex from source vertex
                distance[current] = heapNode.weight;

                //iterate through all edges of current vertex
                foreach(Edge edge in current.getEdges())
                {

                    //get the adjacent vertex
                    Vertex adjacent = getVertexForEdge(current, edge);

                    //if heap does not contain adjacent vertex means adjacent vertex already has shortest distance from source vertex
                    if (!minHeap.containsData(adjacent))
                    {
                        continue;
                    }

                    //add distance of current vertex to edge weight to get distance of adjacent vertex from source vertex
                    //when it goes through current vertex
                    int newDistance = distance[current] + edge.getWeight();

                    //see if this above calculated distance is less than current distance stored for adjacent vertex from source vertex
                    if (minHeap.getWeight(adjacent) > newDistance)
                    {
                        minHeap.decrease(adjacent, newDistance);
                        path_parent[adjacent] = current;
                    }
                }
            }

            return distance;
        }

        private Vertex getVertexForEdge(Vertex v, Edge e)
        {
            return e.getVertex1().equals(v) ? e.getVertex2() : e.getVertex1();
        }
    }
}
