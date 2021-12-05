using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Tushar
{
    public class Vertex
    {
        long id;
        private string data;
        private List<Edge> edges = new List<Edge>();
        private List<Vertex> adjacentVertex = new List<Vertex>();

        public Vertex(long id)
        {
            this.id = id;
        }

        public long getId()
        {
            return id;
        }

        public void setData(string data)
        {
            this.data = data;
        }

        public string getData()
        {
            return data;
        }

        public void addAdjacentVertex(Edge e, Vertex v)
        {
            edges.Add(e);
            adjacentVertex.Add(v);
        }

        public String toString()
        {
            return id.ToString();
        }

        public List<Vertex> getAdjacentVertexes()
        {
            return adjacentVertex;
        }

        public List<Edge> getEdges()
        {
            return edges;
        }

        public int getDegree()
        {
            return edges.Count;
        }

        public int hashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + (int)(id ^ (id >> 32));
            return result;
        }

        public bool equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Vertex other = (Vertex)obj;
            if (id != other.id)
                return false;
            return true;
        }
    }
}
