using System;
using System.Collections.Generic;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2,2,3,1
    };
            ThirdMax(nums);
            Console.ReadKey();
        }
        static int ThirdMax(int[] nums)
        {
            
            Array.Sort(nums);
            Array.Reverse(nums);
            int count = 0;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] != nums[i - 1])
                {
                    count++;
                }
            }
            if(nums.Length > 2)
            {

                return nums[2 + (count -1)];
            }
            else if(nums.Length == 2)
            {
                return nums[1] > nums[0] ? nums[1] : nums[0];
            }else
            {
                return nums[0];
            }
        }
        static int[] SortArrayByParity(int[] A)
        {
            int[] res = new int[A.Length];
            int t = 0;
            for(int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    res[t] = A[i];
                    t++;
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 != 0)
                {
                    res[t] = A[i];
                    t++;
                }
            }
            return res;
        }
        static void MoveZeroes(int[] nums)
        {
            int mv = 0;
            for (int i = 0; i < nums.Length - mv; i++)
            {
                if (nums[i] == 0)
                {
                    mv++;
                    for (int j = i; j < nums.Length - 1; j++)
                    {
                        nums[j] = nums[j+1];
                    }
                }
            }
            for(int i = 0; i < mv; i++)
            {
                nums[nums.Length - i - 1] = 0;
            }
        }
        static int[] ReplaceElements(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int currElement = arr[i];
                int max = int.MinValue;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (max < arr[j])
                    {
                        max = arr[j];
                    }
                }
                if (max != int.MinValue)
                {
                    int temp = arr[i];
                    arr[i] = max;
                }
            }
            arr[arr.Length - 1] = -1;
            return arr;
        }
        static bool ValidMountainArray(int[] arr)
        {
            if (arr.Length >= 3)
            {
                bool isMount = false;
                int j = 0;
                for(int i = 0; i < arr.Length - 1; i++)
                {
                    if(arr[i] < arr[i+1])
                    {

                    }else
                    {
                        j = i;
                    }
                }
                //for (int i = 1; i < arr.Length - 1; i++)
                //{
                    for (int i = 0; i < j; i++)
                    {
                        if (arr[i] < arr[j])
                        {
                            isMount = true;
                        }
                        else
                        {
                            isMount = false;
                        }
                    }
                    for (int k = j + 1; k <= arr.Length -1; k++)
                    {
                        if (arr[k] < arr[j])
                        {
                            isMount = true;
                        }
                        else
                        {
                            isMount = false;
                        }
                    }
                    if (isMount)
                    {
                        return true;
                    }
                //}

                return false;
            }
            return false;
        }
        static void calculateBoxes()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] blocks = Console.ReadLine().Split(' ');
                int min = int.MaxValue;
                int total = 0;
                for (int j = 0; j < blocks.Length; j++)
                {
                    total += Convert.ToInt32(blocks[j]);
                }
                for (int j = 0; j < blocks.Length; j++)
                {
                    int b = Convert.ToInt32(blocks[j]);
                    if (b == 0)
                        continue;
                    int rem = total % b;
                    if (rem == 0)
                        continue;
                    if (rem < min)
                    {
                        min = rem;
                    }
                }
                Console.WriteLine(min == int.MaxValue ? 0 : min);
            }
        }
        static int RemoveDuplicates(int[] nums)
        {
            int duplicates = 0;
            for (int i = 0; i < nums.Length - 1 - duplicates; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    duplicates++;
                    int temp = nums[i + 1];
                    for(int j = i + 1; j < nums.Length -1; j++)
                    {
                        nums[j] = nums[j+1];
                    }
                    nums[nums.Length - 1] = temp;
                    --i;
                }
            }
            return nums.Length - duplicates;
        }
    }
}
