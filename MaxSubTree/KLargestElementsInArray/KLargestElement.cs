using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple.KLargestElementsInArray
{
    public class KLargestElement
    {
        //method 1:
        // bubble find largest one
        // Time complexicity: O(k*N)

        //method 2:
        //make use c# or java sort method, and print top K
        //O(logN)

        //method 3: 
        //max heap 
        //build the max heap: O(N)
        //heapify : 1 heapify is O(LogN), so top K elemetns is O(LogN * K)

        //参考 BinaryHeap
        public void BinaryHeapMethod()
        {
            BinaryHeap_Generic<int> binaryHeap = new BinaryHeap_Generic<int>();
            binaryHeap.Add( 1);
            binaryHeap.Add( 2);
            binaryHeap.Add( 3);
            binaryHeap.Add( 4);


            //pop up K times
            binaryHeap.Poll();

            binaryHeap.Poll();
            binaryHeap.Poll();
        }
    }
}
