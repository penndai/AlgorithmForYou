using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Multiple
{
    public class TopologySorting
    {
        public Stack<Vertex<int>> TopologySorting_Recursive(Graph<int> graph)
        {
            Stack<Vertex<int>> stack = new Stack<Vertex<int>>();
            HashSet<Vertex<int>> visitedSet = new HashSet<Vertex<int>>();

            //loop through its children
            foreach(var vertex in graph.getAllVertex())
            {
                if (visitedSet.Contains(vertex)) continue;

                Topology_RecursiveUtil(vertex, stack, visitedSet);
            }

            //when all children all traversal, put the vertex to the stack
            return stack;
        }

        private void Topology_RecursiveUtil(Vertex<int> vertex, Stack<Vertex<int>> stack, HashSet<Vertex<int>> visitedSet)
        {
            visitedSet.Add(vertex);
            foreach(var linkedVertex in vertex.getAdjacentVertexes())
            {
                if (visitedSet.Contains(linkedVertex))
                {
                    continue;
                }

                Topology_RecursiveUtil(linkedVertex, stack, visitedSet);
            }

            //当处理完当前vertex的所有children后，将该vertext放入stack
            stack.Push(vertex);
        }
        public List<int> TopologySortingOut(HashSet<int> nodes, HashSet<Tuple<int, int>> edges)
        {
            var result = new List<int>();
            // Set of all nodes with no incoming edges
            var allStartNodes = new HashSet<int>(nodes.Where(n => edges.All(e => e.Item2 == n) == false));

            // while there is still start node
            while (allStartNodes.Any())
            {
                //  remove a node n from S
                var n = allStartNodes.First();
                allStartNodes.Remove(n);

                // add n to tail of L
               result.Add(n);

                // for each node m with an edge e from n to m do
                foreach (var e in edges.Where(e => e.Item1.Equals(n)).ToList())
                {
                    var m = e.Item2;

                    // remove edge e from the graph
                    edges.Remove(e);

                    // if m has no other incoming edges then
                    if (edges.All(me => me.Item2.Equals(m) == false))
                    {
                        // insert m into S
                        allStartNodes.Add(m);
                    }
                }
            }

            // if graph has edges then
            if (edges.Any())
            {
                // return error (graph has at least one cycle)
                return null;
            }
            else
            {
                // return L (a topologically sorted order)
                return result;
            }
        }
    }
}
