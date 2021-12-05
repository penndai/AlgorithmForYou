using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class Edge<T>
    {
        private bool isDirected = false;
        private Vertex<T> vertex1;
        private Vertex<T> vertex2;
        private int weight;

        public Edge(Vertex<T> vertex1, Vertex<T> vertex2)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
        }

        public Edge(Vertex<T> vertex1, Vertex<T> vertex2, bool isDirected, int weight)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.weight = weight;
            this.isDirected = isDirected;
        }

        public Edge(Vertex<T> vertex1, Vertex<T> vertex2, bool isDirected)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.isDirected = isDirected;
        }
    }
}
