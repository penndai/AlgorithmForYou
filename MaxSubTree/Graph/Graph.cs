using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Multiple
{
    public class Graph<T>
    {
        private List<Edge<T>> allEdges;
        private Dictionary<long, Vertex<T>> allVertex;
        bool isDirected = false;

        public Graph(bool isDirected)
        {
            allEdges = new List<Edge<T>>();
            allVertex = new Dictionary<long, Vertex<T>>();
            this.isDirected = isDirected;
        }
        public List<Vertex<T>> getAllVertex()
        {
            return allVertex.Values.ToList();
        }
        public List<Edge<T>> getAllEdges()
        {
            return allEdges;
        }

        public void addEdge(long id1, long id2)
        {
            addEdge(id1, id2, 0);
        }

        public void addEdge(long id1, long id2, int weight)
        {
            Vertex<T> vertex1 = null;
            if (allVertex.ContainsKey(id1))
            {
                vertex1 = allVertex[id1];
            }
            else
            {
                vertex1 = new Vertex<T>(id1);
                allVertex.Add(id1, vertex1);
            }
            Vertex<T> vertex2 = null;
            if (allVertex.ContainsKey(id2))
            {
                vertex2 = allVertex[id2];
            }
            else
            {
                vertex2 = new Vertex<T>(id2);
                allVertex.Add(id2, vertex2);
            }

            Edge<T> edge = new Edge<T>(vertex1, vertex2, isDirected, weight);
            allEdges.Add(edge);
            vertex1.addAdjacentVertex(edge, vertex2);
            if (!isDirected)
            {
                vertex2.addAdjacentVertex(edge, vertex1);
            }

        }
    }
}
