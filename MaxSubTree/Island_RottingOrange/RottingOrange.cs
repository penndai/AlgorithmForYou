using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Algorithm_Multiple
{
    //Zombie in Matrix
    class RottingOrange
    {
        public static int OrangesRotting(int[,] grid)
        {
            int rows = grid.GetLength(0);
            int columns = grid.GetLength(1);

            var freshOranges = new HashSet<int>();
            //iterate each orange in the grid
            //save the location of each fresh orange, 10 digit is x, digit is y
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var current = grid[i,j];
                    if (current == 0)
                    {                        
                        var key = i * 10 + j;
                        freshOranges.Add(key);
                    }
                }
            }
            //there is no fresh orange any more
            if (freshOranges.Count == 0)
                return 0;

            //rotting the fresh orange - starting.
            int time_spending = 0;
            while (freshOranges.Count > 0)
            {
                // check fresh orange left, right, up, down four neighbors
                // any of these directions contains rotting orange, set this fresh to rotting
                var foundOne = false;
                var newRotten = new HashSet<int>();
                foreach (var item in freshOranges)
                {
                    var row = item / 10;
                    var col = item - 10 * row;

                    if ((col - 1 >= 0 && grid[row,col - 1] == 1) ||   // left
                       (col + 1 < columns && grid[row,col + 1] == 1) ||  // right
                       (row - 1 >= 0 && grid[row - 1,col] == 1) ||  // up
                       (row + 1 < rows && grid[row + 1,col] == 1)     // down
                        )
                    {
                        newRotten.Add(item);

                        foundOne = true;
                    }
                }

                if (foundOne == false)
                {
                    return -1;
                }

                //update the fresh orange set, remove those already rotting ones.
                foreach (var item in newRotten)
                {
                    var row = item / 10;
                    var col = item - 10 * row;
                    grid[row,col] = 1;
                    freshOranges.Remove(item);
                }

                //for each rotting process, increase the time.
                time_spending++;
            }

            return time_spending;
        }
    }
}
