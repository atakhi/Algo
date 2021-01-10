using System;
using System.Collections.Generic;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {

            //buyZeros();[]

            //DuplicateZeros(arr);
            //int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            //int val = 2;
            //Console.WriteLine(RemoveElement(nums, val));
            //calculateBoxes();
            calculateRBS();
            Console.ReadKey();
        }
        static void calculateRBS()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                Stack<string> st1 = new Stack<string>();
                Stack<string> st2 = new Stack<string>();
                int count = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if(s[j] == '(')
                    {
                        st1.Push("(");
                    }
                    if (st1.Count > 0)
                    {
                        if (s[j] == ')')
                        {
                            st1.Pop();
                            count++;
                        }
                    }
                    if (s[j] == '[')
                    {
                        st2.Push("[");
                    }
                    if (st2.Count > 0)
                    {
                        if (s[j] == ']')
                        {
                            st2.Pop();
                            count++;
                        }
                    }
                }
                Console.WriteLine(count);
            }
        }
        static void calculateBoxes()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < num; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] blocks = Console.ReadLine().Split(' ');
                int min = int.MaxValue;
                int total = 0;
                for(int j = 0; j < blocks.Length; j++)
                {
                    total += Convert.ToInt32(blocks[j]);
                }
                for (int j = 0; j < blocks.Length; j++)
                {
                    int b = Convert.ToInt32(blocks[j]);
                    if (b == 0)
                        continue;
                    int rem = total % b;
                    if (rem < min)
                    {
                        min = rem;
                    }
                }
                Console.WriteLine(min);
            }
        }
        static int RemoveElement(int[] nums, int val)
        {
            int length = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[length] = nums[i];
                    length++;
                }
            }

            return length;
        }
        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for(int i = 0; i < nums2.Length; i++)
            {
                nums1[m + i] = nums2[i];
            }
            Array.Sort(nums1);
        }
        static void DuplicateZeros(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == 0 && i!=arr.Length-1)
                {
                    int ind = i + 1;
                    for(int j = arr.Length - 1; j >= ind; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                    arr[ind] = 0;
                    i++;
                }
            }
        }
        static void buyZeros()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            for (int j = 0; j < num; j++)
            {
                string[] inp = Console.ReadLine().Split(' ');
                int n = 0;
                int c0 = 0;
                int c1 = 0;
                int h = 0;
                n = Convert.ToInt32(inp[0]);
                c0 = Convert.ToInt32(inp[1]);
                c1 = Convert.ToInt32(inp[2]);
                h = Convert.ToInt32(inp[3]);

                string pattern = Console.ReadLine();

                int count0 = 0;
                int count1 = 0;

                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i] == '1')
                    {
                        count1++;
                    }
                    else
                    {
                        count0++;
                    }
                }

                int originalCost = count1 * c1 + count0 * c0;
                int costConvertTo0 = count1 * h + n * c0;
                int costConvertTo1 = count0 * h + n * c1;

                int[] res = { originalCost, costConvertTo0, costConvertTo1 };
                Array.Sort(res);
                Console.WriteLine(res[0]);
            }
        }

        static void PrintArr(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i] + " ");
            }
        }
    }
}
