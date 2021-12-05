using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.Tushar
{
    public class Edge
    {
        private Boolean _isDirected = false;
        private Vertex vertex1;
        private Vertex vertex2;
        private int weight;

        public Edge(Vertex vertex1, Vertex vertex2)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
        }

        public Edge(Vertex vertex1, Vertex vertex2, Boolean isDirected, int weight)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.weight = weight;
            this._isDirected = isDirected;
        }

        public Edge(Vertex vertex1, Vertex vertex2, Boolean isDirected)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this._isDirected = isDirected;
        }

        public Vertex getVertex1()
        {
            return vertex1;
        }

        public Vertex getVertex2()
        {
            return vertex2;
        }

        public int getWeight()
        {
            return weight;
        }

        public Boolean isDirected()
        {
            return _isDirected;
        }

        public int hashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((vertex1 == null) ? 0 : vertex1.hashCode());
            result = prime * result + ((vertex2 == null) ? 0 : vertex2.hashCode());
            return result;
        }

        public Boolean equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Edge other = (Edge)obj;
            if (vertex1 == null)
            {
                if (other.vertex1 != null)
                    return false;
            }
            else if (!vertex1.equals(other.vertex1))
                return false;
            if (vertex2 == null)
            {
                if (other.vertex2 != null)
                    return false;
            }
            else if (!vertex2.equals(other.vertex2))
                return false;
            return true;
        }
       
        public String toString()
        {
            return "Edge [isDirected=" + _isDirected + ", vertex1=" + vertex1
                    + ", vertex2=" + vertex2 + ", weight=" + weight + "]";
        }
    }
}
