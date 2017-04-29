using System.Collections.Generic;

namespace KrestikiNoliki
{
    public partial class Program
    {
        public static bool Correct(int X, int O)
        {
            List<char> lCh=new List<char>();
            for (int i = 0; i < 3; i++)
            { 
                if (mass[i, 0] == mass[i, 1] && mass[i, 1] == mass[i, 2])
                {
                    lCh.Add(mass[i,0]);
                }
                if (mass[0, i] == mass[1, i] && mass[1, i] == mass[2, i])
                {
                    lCh.Add(mass[0, i]);
                }
            }
            if ((mass[0, 0] == mass[1, 1] && mass[1, 1] == mass[2, 2]) || (mass[0, 2] == mass[1, 1] && mass[1, 1] == mass[2, 0]))
            {
                lCh.Add(mass[1, 1]);
            }
            if ((lCh.Contains('X') == true) && (lCh.Contains('O') == true))//если в выигрыше и крестик и нолик это неверно
            {
                return false;
            }
            else if ((X - 1 > O)||(X < O))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}   