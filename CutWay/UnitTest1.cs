using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;
using CutWay;

namespace TestForCutWay
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string way = "ABCDE";
            AdjacentGraph G = new AdjacentGraph();
            G += new Edge("AB");
            G += new Edge("AC");
            G += new Edge("AN");
            G += new Edge("BC");
            G += new Edge("CD");
            G += new Edge("DE");
            G += new Edge("EM");
            Program P = new Program();
            P.Cut(G, way);
            AdjacentGraph Answer = new AdjacentGraph();
            Answer += new Edge("AC");
            Answer += new Edge("AN");
            Answer += new Edge("EM");
            bool b = Answer.Equals(G);
            Assert.AreEqual<bool>(true, b);
        }

        [TestMethod]
        public void TestMethod2()
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
            Program P = new Program();
            P.Cut(G, way);
            AdjacentGraph Answer = new AdjacentGraph();
            Answer += new Edge("AB");
            Answer += new Edge("AE");
            Answer += new Edge("EM");
            bool b = Answer.Equals(G);
            Assert.AreEqual<bool>(true, b);
        }
    }
}
