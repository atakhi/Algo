using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class Backtracking
    {
        private bool finished;
        private void Backtrack(int[] a, int k, int n)
        {
            int[] c = new int[2];
            int ncandidate = 0;
            int i = 0;

            if (IsSolution(a, k, n))
            {
                ProcessSolution(a, k, n);
            }
            else
            {
                k = k + 1;
                ConstructCandidates(a, k, n,c, out ncandidate);
                for(i = 0; i < ncandidate; i++)
                {
                    a[k] = c[i];
                    Backtrack(a, k, n);
                    if (finished)
                        return;
                }
            }
        }

        private bool IsSolution(int[] a, int k, int n)
        {
            return k == n;
        }

        private void ProcessSolution(int[] a, int k, int n)
        {
            int i = 1;
            Console.Write("{");
            for (; i <= k; i++)
            {
                if(a[i] == 1)
                    Console.Write(i + " ");
            }
            Console.Write("}");
            Console.WriteLine();
        }

        private void ConstructCandidates(int[] a, int k, int n,int[] c, out int ncandidate)
        {
            c[0] = 1;
            c[1] = 0;
            ncandidate = 2;
        }

        public void SubsetsOfN(int n)
        {
            int[] a = new int[n+1];
            Backtrack(a, 0, n);
        }
        public void PermutationsOfN(int n)
        {
            
            int nLength = n.ToString().Length;
            int[] a = new int[nLength+1];
            BacktrackPerm(a, 0, n, nLength);
        }
        private void BacktrackPerm(int[] a, int k, int n, int nl)
        {
            int[] c = new int[nl];
            int ncandidates = 0;
            int i = 0;

            if (IsSolution(a, k, nl))
            {
                ProcessPermSolution(a, k, nl);
            }
            else
            {
                k = k + 1;
                ConstructCandidatesPerm(a, k, nl,c, out ncandidates);
                for(i = 0; i < ncandidates; i++)
                {
                    a[k] = c[i];
                    BacktrackPerm(a, k, n,nl);
                    if (finished)
                        return;
                }
                
            }
        }
        private void ConstructCandidatesPerm(int[] a, int k, int n,int[] c, out int nc)
        {
            bool[] inPerm = new bool[n+1];
            for(int i = 0; i < k; i++)
            {
                inPerm[a[i]] = true;
            }
            nc = 0;
            for(int i = 1; i <= n; i++)
            {
                if (!inPerm[i])
                {
                    c[nc] = i;
                    nc++;
                }
            }
        }
        private void ProcessPermSolution(int[] a, int k, int n)
        {
            for(int i = 1; i <= k; i++)
            {
                if (a[i] > 0)
                    Console.Write(a[i]);
            }
            Console.WriteLine();
        }


        public void LexicographicallySortVowelsOfN(int n) {
            //a [n+1]  c[n+1]
            // is solution k==n
            // process solution count++
            // construct candidates out of a,e,i,o,u
            int[] a = new int[6];
            BacktrackVowelSort(a, 0, 6);
        }

        private void BacktrackVowelSort(int[] a, int k, int n) {
            char[] candidates = new char[6];
            int numCandidates = 0;
            int i = 0;

            if (IsSolution(a, k, n)) {
                ProcessVowelSolution(a, k, n);
            }
            else
            {
                k = k + 1;
                ConstructCandidatesVowels(a, k, n,candidates, out numCandidates);
                for (i = 0; i < numCandidates; i++)
                {
                    a[k] = candidates[i];
                    BacktrackVowelSort(a, k, n);
                    if (finished)
                        return;
                }
            }
        }

        private void ProcessVowelSolution(int[] a, int k, int n) { 
            for(int i = 1; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        private void ConstructCandidatesVowels(int[] a, int k, int n, char[] c, out int nc) {
            nc = 0;
            char[] orig = {'.','a','e','i','o','u' };
            bool[] inPerm = new bool[n + 1];
            for (int i = 0; i < k; i++)
            {
                inPerm[a[i]] = true;
            }
            nc = 0;
            for (int i = 1; i <= n; i++)
            {
                if (!inPerm[i])
                {
                    c[nc] = orig[i];
                    nc++;
                }
            }
        }
    }
}
