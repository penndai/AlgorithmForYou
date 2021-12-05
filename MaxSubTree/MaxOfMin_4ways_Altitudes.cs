using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class MaxOfMin_4ways_Altitudes
    {
        public static int GetMaxOfMin_4Ways(int[,] grid)
        {
            int[,] dp = new int[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < dp.GetLength(0); i++) //rows
            {
                for (int j = 0; j < dp.GetLength(1); j++) //columns
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i,j] = grid[i,j];
                        continue;
                    }
                    int top = i > 0 ? dp[i - 1,j] : int.MinValue;
                    int left = j > 0 ? dp[i,j - 1] : int.MinValue;
                    dp[i,j] = Math.Max(Math.Min(top, grid[i,j]), Math.Min(left, grid[i,j]));
                }
            }
            return dp[dp.GetLength(0) - 1,dp.GetLength(1) - 1];
        }
    }
}
