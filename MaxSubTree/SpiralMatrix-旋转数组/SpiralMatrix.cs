using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.SpiralMatrix
{
    public class SpiralMatrix
    {
        public void PrintSpiralMatrix_Top_Bottom_Right_Left(int[,] matrix, int m, int n)
        {
            int top = 0;
            int bottom = m - 1;
            int left = 0;
            int right = n - 1;

            List<int> printed = new List<int>();

            while (printed.Count < matrix.Length * matrix.GetLength(0))
            {
                int index = left;
                while (index <= right)
                {
                    //print(matrix[top, index]);
                    printed.Add(matrix[top, index]);
                    index++;
                }
                top++;

                index = top;
                while (index >= bottom)
                {
                    //print(matrix[index ,right]);
                    index++;
                }
                right--;

                index = right;
                while (index >= left)
                {
                    //print(bottom, index);
                    index--;
                }

                bottom--;


                index = bottom;
                while (index >= top)
                {
                    //print(index, left);
                    index--;
                }

                left++;
            }
        }
        /*
        m - ending row index         
        n - ending column index   
        Time Complexity: O(m*n).
        */
        public void PrintSpiralMatrix(int rows, int columns, int[,] a)
        {
            int rowIndex = 0, columnIndex = 0;
            /* rowIndex - starting row index 
            rows - ending row index 
            columIndex - starting column index 
            columns - ending column index             
            */

            //loop through all rows, all columns
            while (rowIndex < rows && columnIndex < columns)
            {
                // Print the first row  from the remaining rows 
                for (var i = columnIndex; i < columns; ++i)
                {
                    Console.Write(a[rowIndex, i] + " ");
                }
                //row + 1
                rowIndex++;

                // Print the last column from the 
                // remaining columns 
                for (var i = rowIndex; i < rows; ++i)
                {
                    Console.Write(a[i, columns - 1] + " ");
                }
                //column -1 
                columns--;

                // Print the last row from the remaining rows  
                if (rowIndex < rows)
                {
                    for (var i = columns - 1; i >= columnIndex; --i)
                    {
                        Console.Write(a[rows - 1, i] + " ");
                    }
                    rows--;
                }

                // Print the first column from  the remaining columns 
                if (columnIndex < columns)
                {
                    for (var i = rows - 1; i >= rowIndex; --i)
                    {
                        Console.Write(a[i, columnIndex] + " ");
                    }
                    columnIndex++;
                }
            }
        }

        public void PrintSpiralMatrix_Recursive(int[,] arr, int i, int j, int rows, int columns)
        {
            // If i or j lies outside the matrix 
            if (i >= rows || j >= columns)
            {
                return;
            }

            // Print First Row 
            for (int p = i; p < columns; p++)
            {
                Console.Write(arr[i, p] + " ");
            }

            // Print Last Column 
            for (int p = i + 1; p < rows; p++)
            {
                Console.Write(arr[p, columns - 1] + " ");
            }

            // Print Last Row, if Last and 
            // First Row are not same 
            if ((rows - 1) != i)
            {
                //from the second-last element, because last one alredy print by last column
                for (int p = columns - 2; p >= j; p--)
                {
                    Console.Write(arr[rows - 1, p] + " ");
                }
            }

            // Print First Column, if Last and 
            // First Column are not same 
            if ((columns - 1) != j)
            {
                for (int p = rows - 2; p > i; p--)
                {
                    Console.Write(arr[p, j] + " ");
                }
            }

            PrintSpiralMatrix_Recursive(arr, i + 1, j + 1, rows - 1, columns - 1);
        }
    }
}
