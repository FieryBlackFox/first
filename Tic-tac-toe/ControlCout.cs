using System;

namespace KrestikiNoliki
{
    public partial class Program
    {
        public static void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(mass[i, 0] + " " + mass[i, 1] + " " + mass[i, 2]);
            }
            Console.WriteLine();
        }
    }
}