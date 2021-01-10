using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyMaxHeap
    {
        public int[] heap;
        public int len;

        public MyMaxHeap()
        {
            heap = new int[5];
        }

        public void Insert(int data)
        {
            int i = len;
            heap[len] = data;
            len++;
            CheckParents(i);

        }
        private void CheckParents(int i)
        {
            
            while(i != 0 && heap[i] > heap[GetParent(i)])
            {
                Swap(i, GetParent(i));
                i = GetParent(i);
            }
        }
        public void Swap(int l, int r)
        {
            int temp = heap[l];
            heap[l] = heap[r];
            heap[r] = temp;
        }
        public int GetParent(int i)
        {
            return (i - 1) / 2;
        }
        public int RightChild(int i)
        {
            return (2 * i) + 2;
        }
        public int LeftChild(int i)
        {
            return (2 * i) + 1;
        }
        public void Delete()
        {
            int item = heap[0];
            int i = 0;
            heap[i] = heap[len - 1];
            len--;
            CheckDescendants(len, i);
        }
        public void CheckDescendants(int n, int i)
        {
            int largest = i;
            int left = LeftChild(i);
            int right = RightChild(i);
            if (left < n && heap[largest] < heap[left])
            {
                largest = left;
            }
            if (right < n && heap[largest] < heap[right])
            {
                largest = right;
            }
            if(largest != i)
            {
                Swap(largest, i);
                CheckDescendants(n,largest);
            }
        }
        public void Print()
        {
            for(int i = 0; i < len; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine();
        }
        public void Sort(int[] arr)
        {
            int n = arr.Length;
            for(int i= n / 2 - 1; i >= 0; i--)
            {
                heapify(arr, n, i);
            }
            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // call max heapify on the reduced heap
                heapify(arr, i, 0);
            }
        }
        public void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int l = LeftChild(i);
            int r = RightChild(i);

            if (l < n && arr[l] > arr[largest])
                largest = l;
            if (r < n && arr[r] > arr[largest])
                largest = r;
            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                heapify(arr, n, largest);
            }
        }
    }
}
