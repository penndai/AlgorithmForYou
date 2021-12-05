using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    /*
Maximum Minimum Path
给一个int[][]的matirx，对于一条从左上到右下的path p_i，p_i中的最小值是m_i，求所有m_i中的最大值。只能往下或右
比如：
[8, 4, 7]
[6, 5, 9]
有3条path：
8-4-7-9 min: 4
8-4-5-9 min: 4
8-6-5-9 min: 5
return: 5. 
*/
    public class MinimumPathMaximum
    {
        private int maxScore;
        public int minSumPath(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            maxScore = int.MinValue;
            int min = int.MaxValue;
            dfs(grid, 0, 0, min);
            return maxScore;
        }

        // deep search first
        // search from 1st row, 1st column --> 2nd row 1st column --> last row last column
        // search again one column by column, record the max value in each path.

        private void dfs(int[][] grid, int i, int j, int min)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length)
                return;

            //the requirement maybe ignore the first and last node in the path
            if (i == 0 && j == 0 || i == grid.Length - 1 && j == grid[0].Length - 1) { }
            else
                min = Math.Min(min, grid[i][j]);

            if (i == grid.Length - 1 && j == grid[0].Length - 1)
                maxScore = Math.Max(maxScore, min);

            //search next row
            dfs(grid, i + 1, j, min);

            //search next column
            dfs(grid, i, j + 1, min);
        }

    }
}
