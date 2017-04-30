using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using findTemplate;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string template = Console.ReadLine();
            SortedSet<Border> answer = str.SetOfFoundTemplates(template);
            for (int i = 0; i < answer.Count(); i++)
            {
                Console.WriteLine(answer.ElementAt(i).ToString());
            }
            if(answer.Count()==0)
            {
                Console.WriteLine("NO");
            }
            Console.ReadKey();
        }
        
    }
}
