using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Graph;

namespace CutWay
{
    public class Program
    {
        static void Main(string[] args)
        {
            string way = "CBEFIM";
            AdjacentGraph G = new AdjacentGraph();
            G += new Edge("AB");
            G += new Edge("AE");
            G += new Edge("BE");
            G += new Edge("CB");
            G += new Edge("EF");
            G += new Edge("EM");
            G += new Edge("FI");
            G += new Edge("IM");
            G.PrintGrapf();
            Program P = new Program();
            Console.WriteLine("Way: " + way + '\n');
            try
            {
                P.Cut(G, way);
                G.PrintGrapf();
            }
            catch (TryCutNotExistEdgeExeption e)
            {
                Console.WriteLine(e.GetBaseException().Message);
            }

            Console.ReadKey();
        }


        public AdjacentGraph Cut(AdjacentGraph G, string way)
        {
            for (int i = 0; i < way.Length-1; i++)
            {
                G.CutEdge(new Edge(way[i].ToString() + way[i+1].ToString()));
            }
            return G;
        }
    }

   
}
