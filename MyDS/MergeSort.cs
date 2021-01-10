using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MergeSort
    {
        public void Sort(int[] arr)
        {
            int l = 0;
            int h = arr.Length - 1;
            Mergesort(arr, l, h);
        }
        public void Mergesort(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int mid = (l + h) / 2;
                Mergesort(arr, l, mid);
                Mergesort(arr, mid + 1, h);
                Merge(arr, l, mid, h);
            }
        }
        public void Merge(int[] arr, int l, int m, int h)
        {
            Console.WriteLine(l + " " + m + " " + h + " ");
            int s1 = m - l + 1;
            int s2 = h - m;
            int[] arr1 = new int[s1];
            int[] arr2 = new int[s2];
            int i;
            int j;
            for (i=0; i < s1; i++)
            {
                arr1[i] = arr[i + l];
            }
            for (j=0; j < s2; j++)
            {
                arr2[j] = arr[m + j + 1];
            }
            i = 0;j = 0;
            int k = l;

            while(i < s1 && j < s2)
            {
                if (arr1[i] <= arr2[j])
                {
                    arr[k] = arr1[i];
                    //k++;
                    i++;
                }else
                {
                    arr[k] = arr2[j];
                    //k++;
                    j++;
                }
                k++;
            }

            while(i < s1)
            {
                arr[k] = arr1[i];
                i++;
                k++;
            }
            while (j < s2)
            {
                arr[k] = arr2[j];
                j++;
                k++;
            }
        }
    }
}
