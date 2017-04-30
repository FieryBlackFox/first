using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search7;

namespace TestSearch
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] str = { "0", "and", "1", "and", "2", "and", "3" };
            int N = 4;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            string[] str = { "0", "and", "not", "0"};
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] str = { "0", "and", "(", "not", "0", "or", "1", ")" };
            int N = 2;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] str = { "not", "not", "0", "and", "not", "not", "not", "0"};
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, false);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string[] str = { "not", "not", "(", "0", ")" };
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string[] str = { "not", "not", "(", "(", "0", ")", ")" };
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string[] str = { "not", "not", "(", "not", "(", "0", ")", ")" };
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod8()
        {
            string[] str = { "not", "not", "(", "(", "not", "(", "0", ")", ")", ")" };
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod9()
        {
            string[] str = { "not", "not", "(", "0", "or", "(", "not", "(", "0", ")", ")", ")" };
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod10()
        {
            string[] str = { "0", "and", "0", "and", "0", "and", "0", "and", "0", "and", "0", "and", "0", "and", "0"};
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod11()
        {
            string[] str = { "0", "and", "0", "and", "(", "not", "0", ")" , "and", "0", "and", "0", "and", "0", "and", "0", "and", "0" };
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, false);
        }

        [TestMethod]
        public void TestMethod12()
        {
            string[] str = { "(", "(", "(", "(", "(", "(", "(", "0", "and", "0", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")" };
            int N = 1;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod13()
        {
            string[] str = { "(", "(", "(", "(", "(", "(", "(", "0", "and", "1", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")", "and", "0", ")" };
            int N = 2;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

        [TestMethod]
        public void TestMethod14()
        {
            string[] str = { "(", "(", "(", "(", "(", "(", "(", "0", "and", "1", ")", "and", "2", ")", "and", "3", ")", "and", "4", ")", "and", "5", ")", "and", "6", ")", "and", "7", ")" };
            int N = 8;
            Program p = new Program();
            bool b = p.Search(str, N);
            Assert.AreEqual<bool>(b, true);
        }

    }


}
