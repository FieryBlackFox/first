using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perenos
{
    public partial class Program
    {
        private static int n = 0;
        private static string ch = "";
        private static string NotVoice = "BCDFGHJKLMNPQRSTVWXZbcdfghjklmnpqrstvwxz";
        private static string Voice = "AEIOUYaeiouy";

        public Program()
        {
            ch = "";
            n = 0;
        }

        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());//>=3
            int m = Convert.ToInt32(Console.ReadLine());
            string[] str;
            //bool b = true;

            //StringBuilder a = new StringBuilder("aaaa");
            //a[1] = '1';
            
            List<string> LiStr = new List<string>();

            for (int i = 0; i < m; i++)
            {
                str = Console.ReadLine().Split();
                for (int j = 0; j < str.Count(); j++)
                {
                    LiStr.Add(str[j]);
                }
            }
            Program p = new Program();
            string cha = p.MethodMyPerenos(LiStr, N);
            /*for (int i = 0; i < cha.Count(); i++)
            {
                //cha += Environment.NewLine;
                if (cha[i] != '&')
                {
                    Console.Write(cha[i]);
                }
                else 
                {
                    Console.WriteLine();
                }
            }*/
            Console.WriteLine(cha);

                Console.ReadKey();
        }

        public string MethodMyPerenos(List<string> LiStr, int N)
        {
            bool b = true;

            // 1. один проход для всех случаев, предусмотреть
            // 2. избавиться от "&": Environment.NewLine;
            // 3. инкапсулировать
            // 4. убрать put
            
            /*for (int j = 0; j < LiStr.Count(); j++)
            {
                if (((N == 1) && (LiStr[j].Length > 1)) || ((N == 2) && (LiStr[j].Length > 2)))
                {
                    b = false;
                    break;
                }
            }*/

           // if (b == true)
            //{
                for (int i = 0; i < LiStr.Count(); i++)
                {
                    if (perenos(LiStr[i], N) != true)
                    {
                        b = false;
                        break;
                    }
                }
           // }

            if (b == true)
            {
                if (ch[ch.Length - 1] == ' ')
                {
                    return ch.Substring(0, ch.Length - 1) + Environment.NewLine;
                }
                else
                {
                    return ch;
                }
            }
            else
            {
                return "Перенос не осуществляется!!";
            }
        }
    }

}
