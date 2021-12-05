using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm_Multiple
{
    /// <summary>
    /// 寻找从左上到右下的最少cost的值和路径
    /// 
    /// </summary>
    class MinCostPath
    {
        
        private static T[][] CreateArray<T>(int rows, int cols)
        {
            T[][] array = new T[rows][];
            for (int i = 0; i < array.GetLength(0); i++)
                array[i] = new T[cols];

            return array;
        }

        public static int GetMinCostPath(int[][] cost, int m, int n)
        {
            List<int> xPath = new List<int>();
            List<int> yPath = new List<int>();
            int[][] temp = CreateArray<int>(m+1, n+1); 
            //initialise the first row -> sum(current, sum(previous))
            int sum = 0;
            for(int i=0; i <= n; i++){
                temp[0][i] = sum + cost[0][i];
                sum = temp[0][i];
               
            }
            //initialise the first column -> sum(currnet, sum(previous))
            sum = 0;
            for(int i=0; i <= m; i++){
                temp[i][0] = sum + cost[i][0];
                sum = temp[i][0];
                
            }
        
            for(int i=1; i <= m; i++){
                for(int j=1; j <= n; j++){
                    temp[i][j] = cost[i][j] + Math.Min(temp[i - 1][j], temp[i][j - 1]);
                    
                }
            }


            // find path
            var findpathx = m;
            var findpathy = n;

            while(findpathx != 0 || findpathy != 0)
            {
                var nodeValue = temp[findpathx][findpathy] - cost[findpathx][findpathy];

                if(findpathx >0 && temp[findpathx -1][findpathy] == nodeValue)
                {
                    findpathx = findpathx - 1;
                    xPath.Add(findpathx);
                    yPath.Add(findpathy);
                }
                else if(findpathy > 0 && temp[findpathx ][findpathy-1] == nodeValue)
                {
                    findpathy = findpathy - 1;
                    xPath.Add(findpathx);
                    yPath.Add(findpathy);
                }                
            }

            var max = int.MinValue;
           for(int i = 0; i < xPath.Count-1; i++)
            {
                max = Math.Max(max,cost[xPath[i]][yPath[i]]);
            }
            return temp[m][n];
        }        
    }
}
