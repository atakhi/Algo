using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class EditDistance
    {
        public void EditDistanceRecursive(string s, string t)
        {
            int res = EditDistanceRecur(s,t,s.Length,t.Length);
            Console.WriteLine("Edit Distance " + res);
        }

        private int EditDistanceRecur(string s, string t, int n, int m)
        {
            if (m == 0)
                return n;
            if (n == 0)
                return m;
            if (s[n - 1] == t[m - 1])
            {
                return EditDistanceRecur(s, t, n - 1, m - 1);
            }
            else
            {
                return 1 +
                    GetMin(
                        EditDistanceRecur(s, t, n, m - 1), // insert 
                        EditDistanceRecur(s, t, n - 1, m), //delete
                        EditDistanceRecur(s, t, n - 1, m - 1)); //replace
            }

        }
        public void EditDistanceDP(string s, string t)
        {
            int res = CalculateEditDistanceDP(s, t, s.Length, t.Length);
            Console.WriteLine("Edit Distance " + res);
        }
        private int CalculateEditDistanceDP(string s, string t, int n, int m)
        {
            int[,] dp = new int[n + 1, m + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 1 + GetMin(
                                dp[i, j - 1],
                                dp[i - 1, j],
                                dp[i - 1, j - 1]
                            );
                    }
                }
            }
            return dp[n, m];
        }
        private int GetMin(int x, int y, int z)
        {
            if (x <= y && x <= z)
                return x;
            if (y <= x && y <= z)
                return y;
            else
                return z;
        }
    }
}
