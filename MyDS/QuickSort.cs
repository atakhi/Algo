using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class QuickSort
    {
        public void Sort(int[] arr)
        {
            int l = 0;
            int h = arr.Length - 1;
            //QuicksortAB(arr, l, h);
            Quicksort(arr, l, h);
        }
        public void Quicksort(int[] arr, int l, int h)
        {
            if(l < h)
            {
                int j = Partition(arr, l, h);
                Quicksort(arr, l, j - 1);
                Quicksort(arr, j + 1, h);
            }
        }
        public int Partition(int[] arr, int l, int h)
        {
            int pivot = arr[h];

            // index of smaller element 
            int i = (l - 1);
            for (int j = l; j < h; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[h];
            arr[h] = temp1;

            return i + 1;
        }
        public void QuicksortAB(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int j = PartitionAB(arr, l, h);
                QuicksortAB(arr, l, j);
                QuicksortAB(arr, j + 1, h);
            }
        }
        public int PartitionAB(int[] arr, int l, int h)
        {
            int i = l, j = h;
            int pi = arr[l];
            do {
                do { i++; } while (i < arr.Length && arr[i] <= pi);
                do { j--; } while (j >=0 && arr[j] > pi);
                if (i < j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }

            } while (i < j);

            int t = arr[l];
            arr[l] = arr[j];
            arr[j] = t;

            return j;
        }
    }
}
