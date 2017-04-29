using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroOneZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if(n < 11)
            {
                Console.WriteLine("NO");
            }
            for(int i = 10; i < n; i++)
            {
                BinGo(i);   
            }
            Console.ReadKey();
        }
        static public void BinGo(int n)
        {
            string str = "";
            bool ZeroOneZero = false;
            int i = 0;
            while (n != 0)
            {
                if (n % 2 == 0)
                {
                    str = "0" + str;
                    if ((i > 1) && (str[0] == '0') && (str[1] == '1') && (str[2] == '0'))
                    {
                        ZeroOneZero = true;
                    }
                }
                else
                {
                    str = "1" + str;
                }
                n /= 2;
                i++;
            }
            if (ZeroOneZero)
            {
                Console.WriteLine(str);
            }
        }
    }
}
