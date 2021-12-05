using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.LeetPlayround
{
    class MinCosttoConnectAllNodes
    {
        public static  void PrintoutMinCostConnectAllCodes()
        {
            //int[][] edges = new int[3][];
            //edges[0] = new int[2] { 1, 4 };
            //edges[1] = new int[2] { 4, 5 };
            //edges[2] = new int[2] { 2, 3 };
            //int[][] newedges = new int[4][];
            //newedges[0] = new int[3] { 1, 2, 5 };
            //newedges[1] = new int[3] { 1, 3, 10 };
            //newedges[2] = new int[3] { 1, 6, 2 };
            //newedges[3] = new int[3] { 5, 6, 5 };

            int[][] edges = new int[3][];
            int[][] newedges = new int[9][];
            newedges[0] = new int[3] { 1, 2, 3 };
            newedges[1] = new int[3] { 2, 3, 1 };
            newedges[2] = new int[3] { 3, 1, 1 };
            newedges[3] = new int[3] { 1, 4, 1 };

            newedges[4] = new int[3] { 2, 4, 3 };
            newedges[5] = new int[3] { 4, 5, 6 };
            newedges[6] = new int[3] { 5, 6, 2 };
            newedges[7] = new int[3] { 3, 5, 5 };

            newedges[8] = new int[3] { 3, 6, 4 };

            int n = 6;
            int minCost = 0;

            //prepare the graph
            Graph graph = new Graph(n);
            Dictionary<int, Edge> parent = new Dictionary<int, Edge>();

            //prepare the already existing edges without weight in the graph
            for (int i = 0; i < edges.Length; i++)
            {                
                if(edges[i] !=null)
                    graph.AddEdge(edges[i][0], edges[i][1], 0);
            }

            //prepare the broken edges with weight in the graph
            for (int i = 0; i < newedges.Length; i++)
            {
                graph.AddEdge(newedges[i][0], newedges[i][1], newedges[i][2]);
            }

            BinaryHeap minHeap = new BinaryHeap(n + 1);
            minHeap.Insert(1, 0);
            for (int i = 2; i <= n; i++)
            {
                minHeap.Insert(i, int.MaxValue);
            }

            // extract the first root node in the binary heap tree
            int v = minHeap.ExtractMin();
            while (!minHeap.IsEmpty())
            {
                List<Edge> edgeList = graph.adjList[v];
                foreach (Edge e in edgeList)
                {
                    //find all edges related the current vertex
                    //decrease the weight if any found edge greater than the current edge weight
                    if ((minHeap.Contains(e.des)) && (minHeap.GetValue(e.des) > e.weight))
                    {
                        //decrease the value of adjacent vertex to this edge weight
                        minHeap.Decreasekey(e.des, e.weight);

                        //add vertex -> edge mapping in the graph
                        parent[e.des] = e;
                    }
                }
                v = minHeap.ExtractMin();
                Edge minedge = parent[v];
                Console.WriteLine(minedge.ToString());
                minCost += minedge.weight;
            }
            Console.WriteLine(minCost);
        }
        
        public class Graph
        {
            public int vertices;
            public List<Edge>[] adjList;
            public Graph(int n)
            {
                this.adjList = new List<Edge>[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    adjList[i] = new List<Edge>();
                }
                this.vertices = n;
            }

            public void AddEdge(int src, int des, int w)
            {
                adjList[src].Add(new Edge(src, des, w));
                adjList[des].Add(new Edge(des, src, w));
            }
        };
        public class Edge
        {
            public int src;
            public int des;
            public int weight;
            public Edge(int src, int des, int weight)
            {
                this.src = src;
                this.des = des;
                this.weight = weight;
            }
            public override string ToString()
            {
                return $"{src}-->{des} weight:{weight}";
            }
        }
    }    
}
