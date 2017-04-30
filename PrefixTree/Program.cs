using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prefixTree;

namespace ProgramForPrefixTree
{
    
    class Program
    {
        static void Main(string[] args)
        {
            PrefixTree T = new PrefixTree();
            T.AddValue("abracadabra");
            T.AddValue("abbar");
            T.AddValue("abce");
            T.AddValue("sort");
            T.AddValue("sortset");
            T.PrintAll();
            //Console.WriteLine(p.ContainsValue("abba"));
            //Console.WriteLine(p.ContainsValue("ababacab"));
            Console.ReadKey();
        }
    }
}
