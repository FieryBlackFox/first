using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Array9
{
    public class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[N, N];
            string[] str;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split();
                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = Convert.ToInt32(str[j]);
                }
            }
            Program p = new Program();
            arr = p.ArraySwap(arr);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
        public int[,] ArraySwap(int[,] arr)
        {
            int N1 = (int)Math.Sqrt(arr.Length);
            int[,] array1 = new int[N1, N1];
            for (int i = N1 - 1; i >= 0; i--)
            {
                for (int j = 0; j < N1; j++)
                {
                    if (N1 - 1 - i == j)
                    {
                        array1[j, N1 - 1 - i] = arr[N1 - 1 - i, j];
                    }
                    else if (i == j)
                    {
                        array1[N1 - 1 - j, i] = arr[N1 - 1 - j, i];
                    }
                    else
                    {
                        array1[j, i] = arr[N1 - 1 - i, j];
                    }
                }
                
            }
            return array1;
        }
    }
}