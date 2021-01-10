using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemA();
        }
        static void ProblemA()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t > 0)
            {
                int[] a = Console.ReadLine().Split(' ').Select(z => Convert.ToInt32(z)).ToArray();

                int n = a[0];
                int x = a[1];

                List<int> arr = Console.ReadLine().Split(' ').Select(z => Convert.ToInt32(z)).ToList<int>();

                int count = 0;
                

                Console.WriteLine(count);
                t--;
            }
        }
        static void ProblemB()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t > 0)
            {
                int[] a = Console.ReadLine().Split(' ').Select(z => Convert.ToInt32(z)).ToArray();
                
                int n = a[0];
                int x = a[1];
                
                List<int> arr = Console.ReadLine().Split(' ').Select(z => Convert.ToInt32(z)).ToList<int>();

                int count = 0;
                
                Queue<int> st = new Queue<int>();

                foreach (int i in arr)
                    st.Enqueue(i);

                while (st.Count != 0)
                {
                    int item = st.Dequeue();
                    count += item;
                    if(item % x == 0)
                    {
                        int d = item / x;
                       for(int j = 0; j < x; j++)
                        {
                            st.Enqueue(d);
                        }

                    }else
                    {
                        break;
                    }
                }
                foreach(int i in st)
                {
                    count += i;
                }
                
                Console.WriteLine(count);
                t--;
            }
        }
    }
}
