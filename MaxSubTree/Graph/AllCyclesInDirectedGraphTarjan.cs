using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class AllCyclesInDirectedGraphTarjan
    {
        private HashSet<Vertex<int>> visited;
        private LinkedList<Vertex<int>> pointStack;
        private LinkedList<Vertex<int>> markedStack;
        private HashSet<Vertex<int>> markedSet;

        public AllCyclesInDirectedGraphTarjan()
        {
            reset();
        }

        private void reset()
        {
            visited = new HashSet<Vertex<int>>();
            pointStack = new LinkedList<Vertex<int>>();
            markedStack = new LinkedList<Vertex<int>>();
            markedSet = new HashSet<Vertex<int>>();
        }

        public List<List<Vertex<int>>> findAllSimpleCycles(Graph<int> graph)
        {
            reset();
            List<List<Vertex<int>>> result = new List<List<Vertex<int>>>();
            var allVertex = graph.getAllVertex();

            foreach (var vertex in allVertex)
            {
                findAllSimpleCycles(vertex, vertex, result);
                visited.Add(vertex);
                while (markedStack.Count > 0)
                {
                    var firstmarked = markedStack.First;
                    markedStack.RemoveFirst();
                    markedSet.Remove(firstmarked.Value);
                }
            }
            return result;
        }

        private bool findAllSimpleCycles(Vertex<int> start, Vertex<int> current, List<List<Vertex<int>>> result)
        {
            bool hasCycle = false;
            pointStack.AddFirst(current);
            markedSet.Add(current);
            markedStack.AddFirst(current);

            var neighbours = current.getAdjacentVertexes();
            foreach (var neighbour in neighbours)
            {
                if (visited.Contains(neighbour))
                {
                    continue;
                }
                else if (neighbour.equals(start))
                {
                    hasCycle = true;

                    pointStack.AddFirst(neighbour);
                    List<Vertex<int>> cycle = new List<Vertex<int>>();

                    LinkedList<Vertex<int>> copyList = new LinkedList<Vertex<int>>();
                    var start_copyList = pointStack.Last;
                    while (start_copyList != null)
                    {
                        copyList.AddLast(start_copyList.Value);

                        start_copyList = start_copyList.Previous;
                    }

                    foreach (var v in copyList)
                    {
                        cycle.Add(v);
                    }

                    pointStack.RemoveFirst();
                    result.Add(cycle);
                }
                else if (!markedSet.Contains(neighbour))
                {
                    hasCycle = findAllSimpleCycles(start, neighbour, result) || hasCycle;
                }
            }

            if (hasCycle)
            {
                while (!markedStack.First.Value.equals(current))
                {
                    var markedStackFirst = markedStack.First;
                    markedStack.RemoveFirst();
                    markedSet.Remove(markedStackFirst.Value);
                }

                var firsToRemove = markedStack.First;
                markedStack.RemoveFirst();
                markedSet.Remove(firsToRemove.Value);
            }

            pointStack.RemoveFirst();
            return hasCycle;
        }
    }
}
