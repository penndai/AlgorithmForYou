using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.最短路径
{
    public class FloydWarshallAllPairShortestPath
    {
        public const int cst = 9999;
        public static void FloydWarshall(int[,] graph, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];
            int[,] path = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                {
                    distance[i, j] = graph[i, j];
                    if (distance[i, j] != cst && i != j)
                    {
                        path[i, j] = i;
                    }
                    else
                    {
                        path[i, j] = -1;
                    }
                }

            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] == cst || distance[k, j] == cst)
                        {
                            continue;
                        }

                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                            path[i, j] = path[k, j];
                        }
                    }
                }
            }

            //Print(distance, verticesCount);
        }
    }
}
