namespace Algorithm_Multiple.Sorting
{
    public class QuickSort
    {

        public void Quick_Sort(int[] array, int start, int end)
        {
            if (array.Length > 0 && start < end)
            {
                int j = Partition(array, start, end);
                if (j > 0)
                {
                    Quick_Sort(array, start, j);
                    Quick_Sort(array, j+1,end);
                }
            }
        }
        public int Partition(int[] array, int start, int end)
        {
            if (array.Length == 0) return -1;
            //pivot --> array[0]
            var pivot = array[start];

            var i = start+1;
            var j = end;
            while (i < j)
            {
                while (array[i] <= pivot) i++;
                while (array[j] >= pivot) j--;
                if(i<j)
                {
                    //swap
                    var tmp = array[i];
                    array[i] = array[j];
                    array[i] = tmp;
                }                
            }

            //swap pivot with array[j]
            array[0] = array[j];
            array[j] = pivot;

            return j;
        }

        
    }
}
