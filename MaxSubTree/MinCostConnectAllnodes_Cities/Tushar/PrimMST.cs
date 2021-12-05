using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Tushar
{
    class PrimMST
    {
        public List<Edge> primMST(Graph graph)
        {

            //binary heap + map data structure
            BinaryMinHeap<Vertex> minHeap = new BinaryMinHeap<Vertex>();

            //map of vertex to edge which gave minimum weight to this vertex.
            Dictionary<Vertex, Edge> vertexToEdge = new Dictionary<Vertex, Edge>();

            //stores final result
            List<Edge> result = new List<Edge>();

            //insert all vertices with infinite value initially.
            foreach (Vertex v in graph.getAllVertex())
            {
                minHeap.add(int.MaxValue, v);
            }

            //start from any random vertex
            Vertex startVertex = graph.getAllVertex()[0];

            //for the start vertex decrease the value in heap + map to 0
            minHeap.decrease(startVertex, 0);

            //iterate till heap + map has elements in it
            while (!minHeap.empty())
            {
                //extract min value vertex from heap + map
                Vertex current =graph.getVertex(minHeap.extractMin().getId());

                //get the corresponding edge for this vertex if present and add it to final result.
                //This edge wont be present for first vertex.
                Edge spanningTreeEdge;
                vertexToEdge.TryGetValue(current, out spanningTreeEdge);
                if (spanningTreeEdge != null)
                {
                    result.Add(spanningTreeEdge);
                }

                //iterate through all the adjacent vertices
                foreach (Edge edge in current.getEdges())
                {
                    Vertex adjacent = getVertexForEdge(current, edge);
                    //check if adjacent vertex exist in heap + map and weight attached with this vertex is greater than this edge weight
                    if (minHeap.containsData(adjacent) && minHeap.getWeight(adjacent) > edge.getWeight())
                    {
                        //decrease the value of adjacent vertex to this edge weight.
                        minHeap.decrease(adjacent, edge.getWeight());
                        //add vertex->edge mapping in the graph.

                        if (vertexToEdge.ContainsKey(adjacent)) vertexToEdge[adjacent] = edge;
                        else
                            vertexToEdge.Add(adjacent, edge);
                    }
                }
            }
            return result;
        }

        private Vertex getVertexForEdge(Vertex v, Edge e)
        {
            return e.getVertex1().equals(v) ? e.getVertex2() : e.getVertex1();
        }
    }
}
