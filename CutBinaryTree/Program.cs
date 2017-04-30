using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree B = new BinaryTree();
            B.AddNode(7);
            B.AddNode(10);
            B.AddNode(6);
            B.PrintTree();
            BinaryTree B1 = new BinaryTree();
            B1.AddNode(6);
            B.cutBinaryTree(B1);
            B.PrintTree();
            Console.ReadKey();

        }
    }
}
