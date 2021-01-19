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

            for (int i = 0; i <= n-m; i++) {
                int j = 0;
                for (j = 0; j < m; j++) {
                    if (text[i + j] != pat[j])
                        break;
                }
                if (j == m)
                    Console.WriteLine("Pattern found at " + i);
            }            
        }

        public void KMPSearch(string text, string pattern) {
            int n = text.Length;
            int m = pattern.Length;

            //prepare LPS table to find repeating groups in pattern - PREPROCESS pattern
            int[] lps = new int[m];
            int j = 0;
            ComputeLPSArray(lps, m, pattern);
            //loop over text
            int i = 0;
            while (i < n) {
                if (pattern[j] == text[i]) {
                    i++;
                    j++;
                }
                if (j == m) {
                    Console.WriteLine("pattern found " + (i - j));
                    j = lps[j - 1];
                }
                // mismatch after j matches 
                else if (i < n && pattern[j] != text[i])
                {
                    // reduce j
                    if (j != 0)
                        j = lps[j - 1];
                    else //move i to next
                        i = i + 1;
                }
            }
        }

        private void ComputeLPSArray(int[] lps, int m, string pattern) {
            int i = 1;
            int j = 0;
            lps[0] = 0;
            //ababd lps[1] = 0, lps[2]=1, lps[3]=2, lps[4]=0
            //aaba lps[1]=1 lps[2]=0 lps[3]=1
            while (i < m) {
                if (pattern[j] == pattern[i]) {
                    j++;
                    lps[i] = j;
                    i++;
                }
                else
                {
                    if (j != 0) {
                        j = lps[j - 1];
                    }
                    else
                    {
                        lps[i] = j;
                        i++;
                    }
                }
            }
        }
    }
}
