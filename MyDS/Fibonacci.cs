using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class Fibonacci
    {
        long[] arr;
        public void Recrusive(int n) {
            for(int i=0;i<n;i++)
            Console.Write(PrintNFib(i) + " ");
        }

        public void RecursiveMemoization(int n) {
            arr = new long[n];
            for (int i = 0; i < n; i++)
                Console.Write(PrintNFibMem(i) + " ");
        }

        public void FibDP(int n) {
            arr = new long[n];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i < n; i++) {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            for(int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        private long PrintNFibMem(int n) {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (arr[n] != 0)
                return arr[n];
            arr[n] = PrintNFibMem(n - 1) + PrintNFibMem(n - 2);
            return arr[n];
        }
        private long PrintNFib(int n) {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return PrintNFib(n - 1) + PrintNFib(n - 2);
        }

        public void BinomialCoefficients(int n, int k)
        {
            int[,] arr = new int[n+1,k+1];

            for(int i = 0; i <= n; i++)
            {
                arr[i,0] = 1;
            }
            for(int j = 0; j <= k; j++)
            {
                arr[j,j] = 1;
            }

            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= k; j++)
                {
                    arr[i, j] = arr[i - 1,j - 1] + arr[i - 1,j];
                }
            }


            for(int i = 0; i <= n; i++)
            {
                for(int j = 0; j <= k; j++)
                {
                    Console.Write(arr[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(arr[n, k]);
        }
    }
}
