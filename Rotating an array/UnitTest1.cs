using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Array9;

namespace TestForArray9
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[,] n = new int[3, 3]{ {1, 2, 3},
                                      {4, 5, 6},
                                      {7, 8, 9} };
            int[,] n1 = new int[3,3]{ {1, 4, 3},
                                      {8, 5, 2},
                                      {7, 6, 9} };
            Program p = new Program();
            int[,] n2 = p.ArraySwap(n);
            CollectionAssert.AreEqual(n1, n2);
        }/*int[,] n1 = new int[5, 5]{ {1, 2, 3, 4, 5},
                                       {6, 7, 8, 9, 10}*/

        [TestMethod]
        public void TestMethod2()
        {
            int[,] n = new int[5, 5]{ {1, 2, 3, 4, 5},
                                      {6, 7, 8, 9, 10},
                                      {11, 12, 13, 14, 15},
                                      {16, 17, 18, 19, 20},
                                      {21, 22, 23, 24, 25}};
            int[,] n1 = new int[5, 5]{ {1, 16, 11, 6, 5},
                                      {22, 7, 12, 9, 2},
                                      {23, 18, 13, 8, 3},
                                      {24, 17, 14, 19, 4},
                                      {21, 20, 15, 10, 25}};
            Program p = new Program();
            int[,] n2 = p.ArraySwap(n);
            CollectionAssert.AreEqual(n1, n2);
        }

    }
}
