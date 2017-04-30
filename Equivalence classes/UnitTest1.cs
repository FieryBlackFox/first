using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Merge;

namespace TestForMerge
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> str = new List<string>();
            str.Add("ABC");
            str.Add("BF");
            str.Add("ED");
            str.Add("FD");
            str.Add("MY");
            List<string> answer = new List<string>();
            answer.Add("ABCDEF");
            answer.Add("MY");
            Program P = new Program();
            str = P.MethodMerge(str);
            CollectionAssert.AreEqual(answer, str);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<string> str = new List<string>();
            str.Add("AB");
            str.Add("BC");
            str.Add("CD");
            str.Add("DE");
            str.Add("EF");
            List<string> answer = new List<string>();
            answer.Add("ABCDEF");
            Program P = new Program();
            str = P.MethodMerge(str);
            CollectionAssert.AreEqual(answer, str);
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<string> str = new List<string>();
            str.Add("A");
            str.Add("B");
            str.Add("CE");
            str.Add("DE");
            str.Add("CY");
            List<string> answer = new List<string>();
            answer.Add("A");
            answer.Add("B");
            answer.Add("CDEY");
            Program P = new Program();
            str = P.MethodMerge(str);
            CollectionAssert.AreEqual(answer, str);
        }

        [TestMethod]
        public void TestMethod4()
        {
            List<string> str = new List<string>();
            str.Add("B");
            str.Add("AB");
            str.Add("C");
            str.Add("AC");
            List<string> answer = new List<string>();
            answer.Add("ABC");
            Program P = new Program();
            str = P.MethodMerge(str);
            CollectionAssert.AreEqual(answer, str);
        }

        [TestMethod]
        public void TestMethod5()
        {
            List<string> str = new List<string>();
            str.Add("AM");
            str.Add("BFGH");
            str.Add("IM");
            str.Add("BI");
            str.Add("FM");
            str.Add("CE");
            str.Add("DE");
            str.Add("CO");
            List<string> answer = new List<string>();
            answer.Add("ABFGHIM");
            answer.Add("CDEO");
            Program P = new Program();
            str = P.MethodMerge(str);
            CollectionAssert.AreEqual(answer, str);
        }

        [TestMethod]
        public void TestMethod6()
        {
            List<string> str = new List<string>();
            str.Add("EF");
            str.Add("AB");            
            str.Add("BC");
            str.Add("CD");
            str.Add("DE");
            str.Add("FG");
            List<string> answer = new List<string>();
            answer.Add("ABCDEFG");
            Program P = new Program();
            str = P.MethodMerge(str);
            CollectionAssert.AreEqual(answer, str);
        }

    }
}
