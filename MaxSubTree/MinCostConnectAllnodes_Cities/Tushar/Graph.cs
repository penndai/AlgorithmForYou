using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Multiple.Tushar
{
    public class Graph
    {
        private List<Edge> allEdges;
        private Dictionary<long, Vertex> allVertex;
        bool isDirected = false;

        public Graph(bool isDirected)
        {
            allEdges = new List<Edge>();
            allVertex = new Dictionary<long, Vertex>();
            this.isDirected = isDirected;
        }

        public void addEdge(long id1, long id2)
        {
            addEdge(id1, id2, 0);
        }

        //This works only for directed graph because for undirected graph we can end up
        //adding edges two times to allEdges
        public void addVertex(Vertex vertex)
        {
            if (allVertex.ContainsKey(vertex.getId()))
            {
                return;
            }
            allVertex.Add(vertex.getId(), vertex);
            foreach (Edge edge in vertex.getEdges())
            {
                allEdges.Add(edge);
            }
        }

        public Vertex addSingleVertex(long id)
        {
            if (allVertex.ContainsKey(id))
            {
                return allVertex[id];
            }
            Vertex v = new Vertex(id);
            allVertex.Add(id, v);
            return v;
        }

        public Vertex getVertex(long id)
        {
            return allVertex[id];
        }

        public void addEdge(long id1, long id2, int weight)
        {
            Vertex vertex1 = null;
            if (allVertex.ContainsKey(id1))
            {
                vertex1 = allVertex[id1];
            }
            else
            {
                vertex1 = new Vertex(id1);
                allVertex.Add(id1, vertex1);
                setDataForVertex(id1, id1.ToString());
            }
            Vertex vertex2 = null;
            if (allVertex.ContainsKey(id2))
            {
                vertex2 = allVertex[id2];
            }
            else
            {
                vertex2 = new Vertex(id2);
                allVertex.Add(id2, vertex2);
                setDataForVertex(id2, id2.ToString());
            }

            Edge edge = new Edge(vertex1, vertex2, isDirected, weight);
            allEdges.Add(edge);
            vertex1.addAdjacentVertex(edge, vertex2);
            if (!isDirected)
            {
                vertex2.addAdjacentVertex(edge, vertex1);
            }

        }
        public List<Edge> getAllEdges()
        {
            return allEdges;
        }

        public List<Vertex> getAllVertex()
        {
            return new List<Vertex>(allVertex.Values);
        }
        public void setDataForVertex(long id, string data)
        {
            if (allVertex.ContainsKey(id))
            {
                Vertex vertex = allVertex[id];
                vertex.setData(data);
            }
        }
      
        public String toString()
        {
            StringBuilder buffer = new StringBuilder();
            foreach (Edge edge in getAllEdges())
            {
                buffer.Append(edge.getVertex1() + " " + edge.getVertex2() + " " + edge.getWeight());
                buffer.Append("\n");
            }
            return buffer.ToString();
        }
    }
}
