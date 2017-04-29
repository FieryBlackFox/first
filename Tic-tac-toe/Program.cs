using System;
using System.Collections.Generic;
using System.Linq;

namespace KrestikiNoliki
{

    public partial class Program
    {
        static public char[,] mass=new char[3,3];
        static public List<int[]> count=new List<int[]>();
        static public Dictionary<char, int> vin = new Dictionary<char, int>();//победы игроков или ничья

        public Program()
        { 
            mass=new char[3,3];
            count=new List<int[]>();
            vin = new Dictionary<char, int>();
        }

        static void Main(string[] args)
        {
            /*int X = 0, O = 0;
            bool b = true;*/
            Console.WriteLine("Введите матрицу 3 x 3 с проставленными ходами X - крестик, О - нолик,");
            Console.WriteLine("? - нет хода.   Игра начинается с хода крестика");
            char[,] m=new char[3,3];
            for (int i = 0; i < 3; i++)
            {
                string str = Console.ReadLine();
                m[i, 0] = str[0];
                m[i, 1] = str[2];
                m[i, 2] = str[4];
            }

            Program p = new Program();
            Console.WriteLine(p.ForUnitTest(m));
            
            Console.ReadKey();
        }
        public string ForUnitTest(char[,] m)
        {
            int X = 0, O = 0;
            bool b = true;

            vin['X'] = 0;//победа x, o и ничья соответственно
            vin['O'] = 0;
            vin['N'] = 0;
            //mass = m;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mass[i, j] = m[i, j];
                    if (mass[i, j] == '?')
                    {
                        count.Add(new int[2] { i, j });
                    }
                    else if (mass[i, j] == 'X')
                    {
                        X++;
                    }
                    else if (mass[i, j] == 'O')
                    {
                        O++;
                    }
                    else
                    {
                        b = false;
                    }
                }
            }
            if (count.Count() == 0)
            {
                if (Correct(X, O) == true)
                {
                    pobeda();
                }
                else
                {
                    b = false;
                }
            }
            else if (X == O)
            {
                recX(count.Count());//вызов рекурсии на проверку ходов для X
            }
            else if (X == O + 1)
            {
                recO(count.Count());//вызов рекурсии на проверку ходов для O
            }
            else
            {
                b = false;
            }
            if (b == true)
            {
                return ("X: " + vin['X'] + "; O: " + vin['O'] + "; Ничья: " + vin['N']);
            }
            else
            {
                return ("некорректный ввод!!");
            }
        }
    }
}






/*vin['X'] = 0;//победа x, o и ничья соответственно
            vin['O'] = 0;
            vin['N'] = 0;



            try
            {
                for (int i = 0; i < 3; i++)
                {
                    string str = Console.ReadLine();
                    mass[i, 0] = str[0];
                    mass[i, 1] = str[2];
                    mass[i, 2] = str[4];
                    for (int j = 0; j < 3; j++)
                    {
                        if (mass[i, j] == '?')
                        {
                            count.Add(new int[2] { i, j });
                        }
                        else if (mass[i, j] == 'X')
                        {
                            X++;
                        }
                        else if (mass[i, j] == 'O')
                        {
                            O++;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                }
            }
            catch
            {
                b = false;
            }
            if (count.Count() == 0)
            {
                if (Correct(X, O) == true)
                {
                    pobeda();
                }
                else
                {
                    b = false;
                }
            }
            else if(X == O)
            {
                recX(count.Count());//вызов рекурсии на проверку ходов для X
            }
            else if(X == O + 1)
            {
                recO(count.Count());//вызов рекурсии на проверку ходов для O
            }
            else
            {
                b = false;
            }
            if (b == true)
            {
                Console.WriteLine("Игрок X: " + vin['X']);
                Console.WriteLine("Игрок O: " + vin['O']);
                Console.WriteLine("Ничья : " + vin['N']);
            }
            else
            {
                Console.WriteLine("некорректный ввод!!");
            }*/