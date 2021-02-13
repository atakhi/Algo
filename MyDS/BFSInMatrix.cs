using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class BFSInMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int steps = 0;
            Queue<Point> q = new Queue<Point>();

            Point p = new Point(0, 0);
            q.Enqueue(p);


            int[] dr = { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] dc = { 1, 0, -1, 1, -1, 1, 0, -1 };

            int m = grid.Length;
            if (grid[0][0] == 1 || grid[m - 1][m - 1] == 1)
                return -1;
            bool[,] visited = new bool[m, m];
            visited[0, 0] = true;
            while (q.Any())
            {
                //Queue<Point> nq = new Queue<Point>();
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    Point curr = q.Dequeue();
                    if (curr.x == m - 1 && curr.y == m - 1)
                    {
                        return steps + 1;
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        //var(newro, newco) = ();
                        Point np = new Point(curr.x + dr[j], curr.y + dc[j]);
                        if (outside(np.x, np.y, grid) || visited[np.x, np.y] || grid[np.x][np.y] == 1)
                            continue;
                        q.Enqueue(np);
                        visited[np.x, np.y] = true;
                    }

                }
                steps++;
            }
            return -1;
        }
        bool outside(int ro, int co, int[][] grid)
        {
            return ro < 0 || ro >= grid.Length || co < 0 || co >= grid[ro].Length;
        }
    }
    public class Point
    {
        public int x;
        public int y;
        public Point(int n, int m)
        {
            x = n;
            y = m;
        }
    }
}
