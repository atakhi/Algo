using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyArray<T>
    {
        public T[] arr;
        public int length;

        public MyArray(int size){
            arr = new T[size];
            length = 0;
        }
        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public virtual  void Add(T item) {
            if (length == arr.Length - 1) {
                arr = IncreaseLength(arr,2*arr.Length);
            }
            arr[length] = item;
            length++;
        }

        private T[] IncreaseLength(T[] arr, int size) {
            T[] newArr = new T[size];
            for (int i=0;i<arr.Length;i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }

        public void PrintElements() {
            for (int i = 0; i < length; i++)
                Console.WriteLine(arr[i] + " ");
        }
    }
}
