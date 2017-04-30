using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prefixTree;

namespace TestForPrefixTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PrefixTree T = new PrefixTree();
            T.AddValue("abracadabra");
            T.AddValue("abbar");
            T.AddValue("abce");
            T.AddValue("sort");
            T.AddValue("sortset");
            List<string> res = new List<string>();
            T.AllToList(ref res);
            List<string> trueAnswer = new List<string>();
            trueAnswer.Add("abbar");
            trueAnswer.Add("abce");
            trueAnswer.Add("abracadabra");
            trueAnswer.Add("sortset");
            trueAnswer.Add("sort");
            CollectionAssert.AreEqual(res, trueAnswer);
        }

        [TestMethod]
        public void TestMethod2()
        {
            PrefixTree T = new PrefixTree();
            T.AddValue("abracadabra");
            T.AddValue("abbar");
            T.AddValue("abce");
            T.AddValue("sort");
            T.AddValue("sortset");
            T.Remove("sort");
            T.Remove("abce");
            List<string> res = new List<string>();
            T.AllToList(ref res);
            List<string> trueAnswer = new List<string>();
            trueAnswer.Add("abbar");
            trueAnswer.Add("abracadabra");
            trueAnswer.Add("sortset");
            CollectionAssert.AreEqual(res, trueAnswer);
        }

        [TestMethod]
        public void TestMethod3()
        {
            PrefixTree T = new PrefixTree();
            T.AddValue("abracadabra");
            T.AddValue("abbar");
            T.AddValue("abce");
            T.AddValue("sort");
            T.AddValue("sortset");
            bool b = T.ContainsValue("sortset");
            Assert.AreEqual(b, true);
        }

        [TestMethod]
        public void TestMethod4()
        {
            PrefixTree T = new PrefixTree();
            T.AddValue("abracadabra");
            T.AddValue("abbar");
            T.AddValue("abce");
            T.AddValue("sort");
            T.AddValue("sortset");
            bool b = T.ContainsValue("set");
            Assert.AreEqual(b, false);
        }

        [TestMethod]
        public void TestMethod5()
        {
            PrefixTree T = new PrefixTree();
            T.AddValue("abracadabra");
            T.AddValue("abbar");
            T.AddValue("abce");
            T.AddValue("sort");
            T.AddValue("sortset");
            T.Remove("abbar");
            bool b = T.ContainsValue("abbar");
            Assert.AreEqual(b, false);
        }
    }
}
