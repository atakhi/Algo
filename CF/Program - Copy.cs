using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF
{
    class ProgramOld
    {
        static void main(string[] args)
        {
            ProblemA();
            //ProblemB();
        }
        static void ProblemA()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[n];
                HashSet<double> hs = new HashSet<double>();
                arr = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                Array.Sort(arr);
                for(int i = 0; i < arr.Length; i++)
                {
                    for(int j = 0; j < arr.Length; j++)
                    {
                        if(i != j)
                        {
                            double area = 0.5 * 1 * Math.Abs(arr[j] - arr[i]);
                            if (!hs.Contains(area))
                            {
                                hs.Add(area);
                            }
                        }
                    }
                }
                Console.WriteLine(hs.Count);
                t--;
            }
        }
        static void ProblemB()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[n];
                Dictionary<int, int> d = new Dictionary<int, int>();
                arr = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                foreach (int i in arr)
                {
                    if (!d.ContainsKey(i))
                    {
                        d.Add(i, 1);
                    }
                    else
                    {
                        int newVal = i + 1;
                        if (!d.ContainsKey(newVal))
                        {
                            d.Add(newVal, 1);
                        }
                    }
                }
                Console.WriteLine(d.Count);
                t--;
            }
        }
    }
}
