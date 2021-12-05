using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class NumberOfIslands
    {
        public int Review_IslandNumber(char[,] grid)
        {
            int result = 0;
            if (grid == null || grid.Length == 0) return result;

            //loop through all location
            for(int row_index = 0; row_index < grid.GetLength(0); row_index++)
            {                
                for(int column_index = 0; column_index < grid.GetLength(1); column_index++)
                {
                    if(grid[row_index, column_index] == '1')//island
                    {
                        // check the neighbor of current location
                        // if neighbor is island, set to water
                        review_dfs(row_index, column_index, grid);

                        result++;
                    }
                }
            }

            return result;
        }

        private void review_dfs(int rowIndex, int columnIndex, char[,] grid)
        {
            if(rowIndex<0 || columnIndex <0 || 
                rowIndex >= grid.GetLength(0) || 
                columnIndex >= grid.GetLength(1) || 
                grid[rowIndex, columnIndex] == '0')
            {
                return;
            }

            grid[rowIndex, columnIndex] = '0';
            review_dfs(rowIndex-1, columnIndex, grid);
            review_dfs(rowIndex + 1, columnIndex, grid);
            review_dfs(rowIndex, columnIndex +1, grid);
            review_dfs(rowIndex, columnIndex - 1, grid);
        }
        /// <summary>
        /// for each island, visit its neighbour land, using dfs until there is no island, 
        /// mark all visited island as water - 0, 
        /// at the end of this searching, found 1 island.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int IslandsNumber(char[,] grid)
        {
            if(grid == null || grid.Length == 0)
            {
                return 0;
            }

            int islandsNumber = 0;
            for(int i=0; i< grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    if(grid[i,j] == '1')
                    {
                        islandsNumber += dfs(grid, i, j);
                    }
                }
            }

            return islandsNumber;
        }

        //deep find search
        private static int dfs(char[,] grid, int i, int j)
        {
            // if i and j are out of bound or grid i,j represent water or 
            // grid i,j  is already visited
            if (i<0 || i>= grid.GetLength(0) || j<0 || j>=grid.GetLength(1) || 
                grid[i,j] == '0')
            {
                return 0;
            }

            // set the island to water, mark this point visited. 
            grid[i,j] = '0';

            // check neighbours up,down,left and right in matrix. 
            //Method will mark neighbours visited if grid[i][j] are one i.e. 
            //they are also part of this island.
            dfs(grid, i+1, j);
            dfs(grid, i - 1, j);
            dfs(grid, i, j+1);
            dfs(grid, i, j-1);

            return 1;
        }
    }
}
