using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class Kruskals
    {
        private int v;
        private int e;
        private Edge[] edges;
        private int[] parents;
        private Subset[] subsets;
        private int ce;
        public Kruskals(int ve, int ed)
        {
            v = ve;
            e = ed;
            edges = new Edge[e];
            parents = new int[v];
            subsets = new Subset[v];

            for (int i = 0; i < e; i++)
                edges[i] = new Edge();
            parents = new int[v];
        }

        public void AddEdge(int u, int v, int we=0)
        {
            edges[ce] = new Edge();
            edges[ce].src = u;
            edges[ce].dest = v;
            edges[ce].weight = we;
            ce++;
        }

        private int Find(int i)
        {
            if (parents[i] == -1)
                return i;
            return Find(parents[i]);
        }
        private void Union(int x, int y)
        {
            int xs = Find(x);
            int ys = Find(y);

            parents[xs] = ys;
        }

        public void IsCycle()
        {
            bool iscycle = false;
            for (int i = 0; i < v; i++)
                parents[i] = -1;
            for (int i = 0; i < e; i++)
            {
                int x = Find(edges[i].src);
                int y = Find(edges[i].dest);

                if (x == y)
                {
                    iscycle = true;
                    break;
                }
                else
                {
                    Union(x, y);
                }
            }
            Console.WriteLine("Is cycle " + iscycle);
        }

        public void IsCycleByRank()
        {
            bool iscycle = false;
            for (int i = 0; i < v; i++)
            {
                subsets[i] = new Subset();
                subsets[i].parent = i;
                subsets[i].rank = 0;
            }
            for (int i = 0; i < e; i++)
            {
                int x = FindByRank(edges[i].src);
                int y = FindByRank(edges[i].dest);

                if (x == y)
                {
                    iscycle = true;
                    break;
                }
                else
                {
                    UnionByRank(x, y);
                }
            }
            Console.WriteLine("Is cycle " + iscycle);

        }
        private int FindByRank(int i)
        {
            if (subsets[i].parent != i)
                subsets[i].parent = FindByRank(subsets[i].parent);
            return subsets[i].parent;
        }
        private void UnionByRank(int i, int j)
        {
            int xroot = FindByRank(i);
            int yroot = FindByRank(j);

            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[yroot].rank < subsets[xroot].rank)
                subsets[yroot].parent = xroot;
            else
            {
                subsets[xroot].parent = yroot;
                subsets[yroot].rank++;
            }
        }

        public void MST()
        {
            int i = 0;
            Edge[] result = new Edge[e];
            for (i = 0; i < e; i++)
                result[i] = new Edge();
            for (i = 0; i < v; i++)
                parents[i] = -1;
            Array.Sort(edges);
            int ed = 0;
            i = 0;
            while(ed < v - 1)
            {
                Edge next_edge = new Edge();
                next_edge = edges[i++];

                int x = Find(next_edge.src);
                int y = Find(next_edge.dest);

                // If including this edge does't cause cycle,
                // include it in result and increment the index
                // of result for next edge
                if (x != y)
                {
                    result[ed++] = next_edge;
                    Union(x, y);
                }
            }
            int minimumCost = 0;
            for (i = 0; i < e; ++i)
                {
                    Console.WriteLine(result[i].src + " -- "
                                      + result[i].dest
                                      + " == " + result[i].weight);
                    minimumCost += result[i].weight;
            }

            Console.WriteLine("Minimum Cost Spanning Tree"
                              + minimumCost);
        }
    }
    public class Edge : IComparable<Edge>
    {
        public int src;
        public int dest;
        public int weight;
        public int CompareTo(Edge obj)
        {
            return this.weight - obj.weight;
        }
    }
    public class Subset
    {
        public int parent;
        public int rank;
    }
}
