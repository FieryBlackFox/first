using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merge
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> str = new List<string>();
            string st;
            Program p = new Program();

            int n;
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                st = Console.ReadLine();
                str.Add(st);
            }

            str = p.MethodMerge(str);
            for (int i = 0; i < str.Count(); i++)
            {
                Console.WriteLine(str[i]);

            }
            Console.ReadKey();
        }

        public string Merge(string str1, string str2)
        {
            int i = 0;
            SortedSet<char> ch = new SortedSet<char>();
            while (i < str1.Length)
            {
                ch.Add(str1[i]);
                i++;
            }
            i = 0;
            while (i < str2.Length)
            {
                ch.Add(str2[i]);
                i++;
            }
            return new string(ch.ToArray());
        }

        public bool Possible(string str1, string str2)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                if (str2.Contains(str1[i])) return true;
            }
            return false;
        }


        public List<string> MethodMerge(List<string> str)
        {
            int StartSize = 0;
            while (StartSize != str.Count)
            {
                StartSize = str.Count();
                for (int j = 0; j < str.Count(); j++)
                {
                    for (int i = 0; i < str.Count(); i++)
                    {
                        if ((j < str.Count) && (i != j) && (Possible(str[i], str[j]) == true))
                        {
                            str[j] = Merge(str[i], str[j]);
                            str.RemoveAt(i);
                        }
                    }
                }
            }
            return str;
        }
    }
}