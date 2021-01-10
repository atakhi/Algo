using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyWGraph
    {
        private LinkedList<WEdgeNode>[] adjList;
        private int v;
        private int e;
        private int[] parents;
        private bool[] discovered;
        private bool directed;
        public MyWGraph(int n, bool d)
        {
            v = n;
            directed = d;
            adjList = new LinkedList<WEdgeNode>[v];
            parents = new int[v];
            discovered = new bool[v];

            for(int i = 0; i < n; i++)
            {
                adjList[i] = new LinkedList<WEdgeNode>();
            }
        }

        public void AddEdge(int u, int v, int w)
        {
            adjList[u].AddLast(new WEdgeNode(v,w));
            if (!directed)
                adjList[v].AddFirst(new WEdgeNode(u, w));
        }
        public void PrimsMST(int start)
        {
            bool[] intree = new bool[v];
            int[] distance = new int[v];
            int currv;
            for(int i=0;i<v;i++)
            {
                distance[i] = int.MaxValue;
                parents[i] = -1;
            }
            //select any vertex add to ms tree
            distance[start] = 0;
            currv = start;
            //while non tree vertices
            while (!intree[currv])
            {
                intree[currv] = true;
                foreach(WEdgeNode p in adjList[currv])
                {
                    // update weights foreach edge from maxInt to current weight
                    int y = p.y;
                    int weight = p.w;
                    if(distance[y] > weight && !intree[y])
                    {
                        distance[y] = weight;
                        parents[y] = currv;
                    }
                }
                //select edge with min weight from tree to non tree
                currv = 1;
                int dist = int.MaxValue;
                for(int i = 0; i < v; i++)
                {
                    if(!intree[i] && dist > distance[i])
                    {
                        dist = distance[i];
                        currv = i;
                    }
                }
            }

            PrintMST();
        }

        public void PrimsMST_Heap(int start)
        {
            bool[] intree = new bool[v];
            //int[] distance = new int[v];
            HeapNode[] nodes = new HeapNode[v];
            //int currv;
            for (int i = 0; i < v; i++)
            {
                //distance[i] = int.MaxValue;
                parents[i] = -1;
                nodes[i] = new HeapNode();
                nodes[i].weight = int.MaxValue;
            }
            //select any vertex add to ms tree
            ///distance[start] = 0;
            nodes[start].weight = 0;
            //currv = start;

            SortedSet<HeapNode> pq = new SortedSet<HeapNode>(new comparator());

            for (int i = 0; i < v; i++)
                pq.Add(nodes[i]);

            //while non tree vertices
            while (pq.Any())
            {
                //select edge with min weight from tree to non tree
                HeapNode min = pq.First();
                pq.Remove(min);
                int currv = min.vertex;
                intree[currv] = true;
                foreach (WEdgeNode p in adjList[currv])
                {
                    // update weights foreach edge from maxInt to current weight
                    int y = p.y;
                    int weight = p.w;
                    if (nodes[y].weight > weight && !intree[y])
                    {                        
                        parents[y] = currv;
                        pq.Remove(nodes[y]);
                        nodes[y].weight = weight;
                        nodes[y].vertex = y;
                        pq.Add(nodes[y]);
                    }
                }
            }
            PrintMST();
        }
        public void PrintMST()
        {

            for (int i = 1; i < v; i++)
            {
                Console.WriteLine(parents[i] + " - " + i);
            }

            //Console.WriteLine("Edge \tWeight");
            //for (int i = 1; i < v; i++)
            //{
            //    int w = -1;
            //    LinkedList<WEdgeNode> li = adjList[parents[i]];
            //    int count = 0;
            //    foreach (var item in li)
            //    {
            //        if (item.y == i)
            //        {
            //            w = item.w;
            //            break;
            //        }
            //        count++;
            //    }
            //    Console.WriteLine(parents[i] + " - " + i + "\t" + w);
            //}
        }

        public void DijkstraMSP(int start)
        {
            bool[] intree = new bool[v];
            int[] parents = new int[v];
            int[] distance = new int[v];
            int currv = start;
            int dist = int.MaxValue;

            for(int i = 0; i < v; i++)
            {
                parents[i] = -1;
                distance[i] = int.MaxValue;
            }

            distance[start] = 0;

            while (!intree[currv])
            {
                intree[currv] = true;
                //update weights for all adj nodes
                foreach(WEdgeNode p in adjList[currv])
                {
                    int y = p.y;
                    int weight = p.w;

                    if(!intree[y] && distance[y] > (weight + distance[currv]))
                    {
                        distance[y] = weight + distance[currv];
                        parents[y] = currv;
                    }
                }

                currv = 1;
                dist = int.MaxValue;
                //select min weight edge from graph not in tree
                for(int i = 0; i < v; i++)
                {
                    if(!intree[i] && dist > distance[i])
                    {
                        dist = distance[i];
                        currv = i;
                    }
                }
            }
            for (int i = 0; i < v; i++)
            {
                Console.Write("\n" + start + " -> ");
                Console.Write(i + " \t\t ");
                Console.Write(distance[i] + "\t\t");
                if (i != start)
                    FindPath(start, i, parents);
                Console.WriteLine();
            }
        }
        private void FindPath(int start, int end, int[] parents)
        {
            if (start == end || end == -1)
            {
                Console.Write(start + " ");
            }
            else
            {
                FindPath(start, parents[end], parents);
                Console.Write(end + " ");
            }
        }
    }

    public class HeapNode
    {
        public int vertex;
        public int weight;
    }
    public class comparator : IComparer<HeapNode>
    {
        public int Compare(HeapNode x, HeapNode y)
        {
            return x.weight - y.weight;
        }
    }

    internal class WEdgeNode
    {
        public int y;
        public int w;
        public WEdgeNode(int ys, int ws)
        {
            y = ys;
            w = ws;
        }
    }
    public class FloydWarshall
    {
        public void AllPairsShortestPath(int[,] graph,int v)
        {
            int[,] dist = new int[v, v];
            int i, j, k;
            //init dist for 0 vertices
            for (i = 0; i < v; i++)
            {
                for (j = 0; j < v; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }


            for (k = 0; k < v; k++)
            {
                for(i = 0; i < v; i++)
                {
                    for(j = 0; j < v; j++)
                    {
                        int through_k = dist[i, k] + dist[k, j];
                        if(dist[i, k] == int.MaxValue || dist[k, j] == int.MaxValue)
                        {
                            Console.WriteLine("foud");
                            continue;
                        }
                        if(through_k < dist[i, j])
                        {
                            dist[i, j] = through_k;
                        }
                    }
                }
            }

            //print
            for (i = 0; i < v; ++i)
            {
                for (j = 0; j < v; ++j)
                {
                    if (dist[i, j] == int.MaxValue)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write(dist[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
