using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Multiple
{

    public class CriticalConnectionsClass
    {
        //time when discovered the vertex
        private int time = 0;
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            int[] low = new int[n];
            List<IList<int>> result = new List<IList<int>>();
            //we init the visited array to -1 for all vertices
            int[] visited = Enumerable.Repeat(-1, n).ToArray();

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            //the graph is connected two ways
            foreach (var list in connections)
            {
                if (!dict.ContainsKey(list[0]))
                {
                    dict.Add(list[0], new List<int>());
                }
                dict[list[0]].Add(list[1]);


                if (!dict.ContainsKey(list[1]))
                {
                    dict.Add(list[1], new List<int>());
                }
                dict[list[1]].Add(list[0]);

            }
            //iterate each non-visited node
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == -1)
                {
                    //DFS search current node and set the low link value.
                    DFS(i, low, visited, dict, result, i);
                }
            }
            return result;
        }

        private void DFS(int currentNodeId, int[] lowlinkValue, int[] visited, Dictionary<int, List<int>> dict, List<IList<int>> result, int pre)
        {
            //initially set the current node low link value same as id number. 
            visited[currentNodeId] = lowlinkValue[currentNodeId] = ++time; // discovered current node;
            for (int j = 0; j < dict[currentNodeId+1].Count; j++) //iterate all of the nodes connected to current node
            {
                //find the linked node 
                int linkedNode = dict[currentNodeId+1][j] - 1; // dict[u][j];
                if (linkedNode == pre)
                {
                    //if parent vertex ignore
                    continue;
                }

                if (visited[linkedNode] == -1) // if not visited
                {
                    DFS(linkedNode, lowlinkValue, visited, dict, result, currentNodeId);
                    lowlinkValue[currentNodeId] = Math.Min(lowlinkValue[currentNodeId], lowlinkValue[linkedNode]);
                    if (lowlinkValue[linkedNode] > visited[currentNodeId])
                    {
                        //u-v is critical there is no path for v to reach back to u or previous vertices of current node
                        result.Add(new List<int> { currentNodeId+1, linkedNode+1 });
                    }
                }
                else // if linked node was already visited put the minimum into low link vlaue for vertex current node
                {
                    lowlinkValue[currentNodeId] = Math.Min(lowlinkValue[currentNodeId], visited[linkedNode]);
                }
            }
        }
    }
}
