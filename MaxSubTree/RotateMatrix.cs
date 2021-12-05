using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class RotateMatrix
    {
        // C# program to rotate a 
        // matrix by 90 degrees 
        // An Inplace function to 
        // rotate a N x N matrix 
        // by 90 degrees in anti- 
        // clockwise direction 
        public static void rotateMatrix(int N,
                                int[,] mat)
        {
            //i--> from 0 to N/2
            //j--> from i to N-1-i
            //[i,j] --> [j, N-1-i], --> [N-1-i, N-1-j] --> [N-1-j, i] --> [i,j]
            // Consider all 
            // squares one by one 
            for (int layer = 0; layer < N / 2; layer++)
            {
                // Consider elements 
                // in group of 4 in 
                // current square 
                for (int y = layer; y < N - layer - 1; y++)
                {
                    // store current cell 
                    // in temp variable 
                    int temp = mat[layer, y];

                    // move values from 
                    // right to top 
                    mat[layer, y] = mat[y, N - 1 - layer];

                    // move values from 
                    // bottom to right 
                    mat[y, N - 1 - layer] = mat[N - 1 - layer,
                                            N - 1 - y];

                    // move values from 
                    // left to bottom 
                    mat[N - 1 - layer,
                        N - 1 - y]
                        = mat[N - 1 - y, layer];

                    // assign temp to left 
                    mat[N - 1 - y, layer] = temp;
                }
            }
        }

        // Function to print the matrix 
        public static void displayMatrix(int N,
                                int[,] mat)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + mat[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }       




    }
}
