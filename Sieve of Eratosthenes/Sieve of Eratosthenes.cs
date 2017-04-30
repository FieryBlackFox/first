using System;

namespace GenerationOfSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int[] n = new int[N];

            for (int i = 2; i < N; i++)
            {
                if (n[i] == 0)
                {
                    for (int j = i + i; j < N; j += i)
                    {
                        n[j] = 2;
                    }

                    Console.Write(i + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
