using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class Vertex<T>
    {
        long id;
        public T data;
        private List<Edge<T>> edges = new List<Edge<T>>();
        private List<Vertex<T>> adjacentVertex = new List<Vertex<T>>();

        public Vertex(long id)
        {
            this.id = id;
        }
        public List<Vertex<T>> getAdjacentVertexes()
        {
            return adjacentVertex;
        }

        public void addAdjacentVertex(Edge<T> e, Vertex<T> v)
        {
            edges.Add(e);
            adjacentVertex.Add(v);
        }
        public bool equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            
            Vertex<T> other = (Vertex<T>)obj;
            if (id != other.id)
                return false;
            return true;
        }
    }   
}
