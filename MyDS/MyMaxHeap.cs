using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyMaxHeap<T> where T : IComparable<T>
    {
        private List<T> heap;
        private int len;
        private IComparer<T> _heapComparer = Comparer<T>.Default;

        public MyMaxHeap()
        {
            heap = new List<T>();
        }
        public MyMaxHeap(int cap, IComparer<T> comparer)
        {
            heap = new List<T>(cap);
            _heapComparer = comparer ?? Comparer<T>.Default;
        }

        public void Insert(T data)
        {
            int i = len;
            heap.Add(data);
            len++;
            CheckParents(i);

        }
        private void CheckParents(int i)
        {
            
            while(i != 0 && _heapComparer.Compare( heap[i], heap[GetParent(i)]) > 0)
            {
                Swap(i, GetParent(i));
                i = GetParent(i);
            }
        }
        private void Swap(int l, int r)
        {
            T temp = heap[l];
            heap[l] = heap[r];
            heap[r] = temp;
        }
        private int GetParent(int i)
        {
            return (i - 1) / 2;
        }
        private int RightChild(int i)
        {
            return (2 * i) + 2;
        }
        private int LeftChild(int i)
        {
            return (2 * i) + 1;
        }
        public void Delete()
        {
            T item = heap[0];
            int i = 0;
            heap[i] = heap[len - 1];
            len--;
            CheckDescendants(len, i);
        }
        private void CheckDescendants(int n, int i)
        {
            int largest = i;
            int left = LeftChild(i);
            int right = RightChild(i);
            if (left < n && _heapComparer.Compare(heap[largest], heap[left])<0)
            {
                largest = left;
            }
            if (right < n && _heapComparer.Compare(heap[largest], heap[right])<0)
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
        public void Sort(T[] arr)
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
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // call max heapify on the reduced heap
                heapify(arr, i, 0);
            }
        }
        public void heapify(T[] arr, int n, int i)
        {
            int largest = i;
            int l = LeftChild(i);
            int r = RightChild(i);

            if (l < n && _heapComparer.Compare(arr[l], arr[largest]) > 0)
                largest = l;
            if (r < n && _heapComparer.Compare(arr[r], arr[largest]) > 0)
                largest = r;
            if (largest != i)
            {
                T temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                heapify(arr, n, largest);
            }
        }

    }
    public class MyIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }
}
