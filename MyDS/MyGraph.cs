using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyGraph
    {
        private LinkedList<int>[] adjList;
        private int v;
        private int e;
        private int[] parents;
        private bool[] discovered;
        private bool[] processed;
        private int[] colors;
        private bool directed;
        private bool isBipartite = true;
        private int time;
        private int[] entryTime;
        private int[] exitTime;
        private int[] indegree;
        private bool finishedDFS;
        private List<int> topologicalSort = new List<int>();

        public MyGraph(int n, bool d, int ed=0)
        {
            v = n;
            e = ed;
            adjList = new LinkedList<int>[v];
            colors = new int[v];
            indegree = new int[v];

            for (int i = 0; i < v; i++)
            {
                adjList[i] = new LinkedList<int>();
                colors[i] = -1;
            }
            InitGraphSearch();
            directed = d;
        }
        private void InitGraphSearch()
        {
            parents = new int[v];
            discovered = new bool[v];
            processed = new bool[v];
            entryTime = new int[v];
            exitTime = new int[v];

            isBipartite = true;
            finishedDFS = false;
            
            for (int i = 0; i < v; i++)
            {
                parents[i] = -1;
            }
        }

        public void AddEdge(int x, int y)
        {
            adjList[x].AddLast(y);
            if(!directed)
                adjList[y].AddLast(x);
        }

        public void PrintGraph()
        {
            for(int i=0;i<adjList.Length;i++)
            {
                foreach(int val in adjList[i])
                {
                    Console.Write(val + "->");
                }
                Console.WriteLine();
            }
        }

        public void BFS(int start)
        {
            Queue<int> q = new Queue<int>();

            discovered[start] = true;
            q.Enqueue(start);

            while(q.Count != 0)
            {
                int currVertex = q.Dequeue();

                ProcessEarly(currVertex);
                foreach(int currEdge in adjList[currVertex])
                {
                    if(!processed[currEdge] || directed)
                    {
                        ProcessEdge(currVertex, currEdge);
                    }
                    if (!discovered[currEdge])
                    {
                        q.Enqueue(currEdge);
                        discovered[currEdge] = true;
                        parents[currEdge] = currVertex;
                    }
                }
                processed[currVertex] = true;
                ProcessLate(currVertex);
            }
            Console.WriteLine("total edges " + e);
        }

        public void ShortestPath(int u, int v)
        {
            InitGraphSearch();
            BFS(u);
            FindPath(u, v);
        }

        private void FindPath(int start, int end)
        {
            if(start == end || end == -1)
            {
                Console.Write(start);
            }else
            {
                FindPath(start, parents[end]);
                Console.Write(end);
            }
        }

        public void ConnectedComponents()
        {
            int c = 0;
            InitGraphSearch();
            for (int i = 0; i < v; i++)
            {
                if (!discovered[i])
                {
                    BFS(i);
                    c++;
                }
            }
            Console.WriteLine("connected compoenents " + c);
        }

        public void isTwoColoring()
        {
            InitGraphSearch();
            for(int i=0;i < v; i++)
            {
                if (!discovered[i])
                {
                    colors[i] = 1;
                    BFS(i);
                }
            }
            Console.WriteLine("Graph is bi colorable " + isBipartite);
        }

        public void DFS(int start)
        {
            if (finishedDFS)
                return;
            discovered[start] = true;
            ProcessEarly(start);
            time++;
            entryTime[start] = time;
            foreach(int v in adjList[start])
            {
                if (!discovered[v])
                {
                    parents[v] = start;
                    //ProcessEdgeDFS(start, v);
                    DFS(v);
                }
                if(!processed[v] || directed)
                {
                    ProcessEdgeDFS(start, v);
                }
                if (finishedDFS)
                    return;
            }
            processed[start] = true;
            ProcessLate(start);
            time++;
            exitTime[start] = time;
        }

        public void IsCycle()
        {
            InitGraphSearch();
            for(int i = 0; i < v; i++)
            {
                if(!discovered[i] && !finishedDFS)
                    DFS(i);
            }
            Console.WriteLine("is cycle " + finishedDFS);
        }
        public void PrintTopologicalSort()
        {
            //find if cycle in directed graph using dfs with edge classification
            //int edge_classification(int x, int y)
            //    {
            //        if (parent[y] == x) return (TREE);
            //        if (discovered[y] && !processed[y]) return (BACK);
            //        if (processed[y] && (entry_time[y] > entry_time[x])) return (FORWARD);
            //        if (processed[y] && (entry_time[y] < entry_time[x])) return (CROSS);
            //        printf("Warning: unclassified edge (%d,%d)\n", x, y);
            //    }
            //reverse topologicalSort list if no cycle
            InitGraphSearch();
            for (int i = 0; i < v; i++)
            {
                if (!discovered[i])
                    DFS(i);
            }
            Console.WriteLine();
            Console.WriteLine("Topo Sort");
            topologicalSort.Reverse();
            foreach(int x in topologicalSort)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        public void TopoSortKahnsBFS()
        {
            //find vertex with indegree 0
            for(int i = 0; i < v; i++)
            {
                foreach (int y in adjList[i])
                    indegree[y]++;
            }
            //add to q
            Queue<int> q = new Queue<int>();
            for(int i = 0; i < v; i++)
            {
                if (indegree[i] == 0)
                {
                    q.Enqueue(i);
                }
            }
            int count = 0;
            //pop from q
            //find adj vert reduce indegree
            //add new indegree 0 to q
            while (q.Any())
            {
                int w = q.Dequeue();
                topologicalSort.Add(w);
                foreach(int y in adjList[w])
                {
                    indegree[y]--;
                    if(indegree[y] == 0)
                    {
                        q.Enqueue(y);
                    }
                }
                count++;
            }
            if (count != v)
            {
                Console.WriteLine("cycle exists in graph");
            }
            foreach(int i in topologicalSort)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void StronglyConnectedComponents()
        {
            InitGraphSearch();
            for(int i = 0; i < v; i++)
            {
                if (!discovered[i])
                    DFS(i);
            }

            MyGraph gr = GetTranspose(v);

            for (int i = 0; i < discovered.Length; i++)
            {
                discovered[i] = false;
            }
            while (topologicalSort.Count > 0)
            {
                int x = topologicalSort[topologicalSort.Count - 1];
                topologicalSort.RemoveAt(topologicalSort.Count - 1);

                if (!discovered[x])
                {
                    DFSUtil(gr, x);
                    Console.WriteLine();
                }
                
            }
        }

        private void DFSUtil(MyGraph g, int start)
        {
            discovered[start] = true;
            Console.Write(start + " ");
            foreach(int y in g.adjList[start])
            {
                if (!discovered[y])
                    DFSUtil(g, y);
            }
        }

        private MyGraph GetTranspose(int n)
        {
            MyGraph g = new MyGraph(n, true);
            for (int v = 0; v < n; v++)
            {
                // Recur for all the vertices adjacent to this vertex 
                foreach(int y in adjList[v])
                {
                    g.AddEdge(y, v);
                }
            }
            return g;
        }

        private void ProcessEarly(int v)
        {
            Console.Write("early " + v);
        }
        private void ProcessLate(int v)
        {
            Console.Write("late " + v);
            topologicalSort.Add(v);
        }
        private void ProcessEdge(int u, int v)
        {
            Console.Write("edge " + u + " - " + v);
            //total edges
            e++;

            if(colors[u] == colors[v])
            {
                isBipartite = false;
                Console.WriteLine("Not bipartite");
            }else
            {
                colors[v] = 1 - colors[u];
            }
        }

        private void ProcessEdgeDFS(int u, int v)
        {
            Console.WriteLine("Edge " + u + " " + v);

            if (directed)
            {
                int ec = EdgeClassification(u, v);
                if (ec == 1)
                {
                    Console.WriteLine("cycle found");
                    //finishedDFS = true;
                    //FindPath(v, u);
                }
            }else
            {
                if (parents[u] != v)
                {
                    Console.WriteLine("cycle found");
                    finishedDFS = true;
                    FindPath(v, u);
                }
            }
        }
        private int EdgeClassification(int x, int y)
        {
            if (parents[y] == x) return (0);//TREE
            if (discovered[y] && !processed[y]) return (1);//BACK
            if (processed[y] && (entryTime[y] > entryTime[x])) return (2);//FORWARD
            if (processed[y] && (entryTime[y] < entryTime[x])) return (3);//CROSS
            Console.WriteLine("Warning: unclassified edge (%d,%d)\n", x, y);
            return -1;
        }
    }
}
