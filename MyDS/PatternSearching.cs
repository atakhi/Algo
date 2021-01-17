using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class PatternSearching
    {
        public void NaivePatternSearch(string text, string pat) {
            int n = text.Length;
            int m = pat.Length;

            for (int i = 0; i < n-m; i++) {
                int j = 0;
                for (j = 0; j < m; j++) {
                    if (text[i + j] != pat[j])
                        break;
                }
                if (j == m)
                    Console.WriteLine("Pattern found at " + i);
            }            
        }
    }
}
