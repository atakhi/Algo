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

            //prepare LPS table to find same prefix and suffix in pattern - PREPROCESS pattern
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
            //ABABCABAB lps1=0 lps2=1 lps3=2 lps4=0 lps5=1 lps6=2 lps7=3 lps8=4
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

        public void RabinKarp(string text, string pat) {
            int n = text.Length;
            int m = pat.Length;
            text = text.ToLower();
            pat = pat.ToLower();

            int hashCodePat = GetHashValue(pat);

            for (int i = 0; i <= n - m; i++) {
                string curr = text.Substring(i, m);
                int currHashCode = GetHashValue(curr);
                int j = 0;
                if (hashCodePat == currHashCode) {
                    for (j=0;j<pat.Length;j++) {
                        if (curr[j] != pat[j])
                            break;
                    }
                    if (j == m) {
                        Console.WriteLine("pattern found at " + i);
                    }

                }
            }
        }
        private int GetHashValue(string pat) {
            //chars allowed a-z = 26 % 2^31
            //dba
            int h = 0;

            char[] arr = pat.ToCharArray();
            int j = 0;
            double hv = 0.0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                hv += arr[i] * Math.Pow(26,j);
                j++;
            }
            h = (int)(hv % Math.Pow(2, 31));

            return h;
        }
    }
}
