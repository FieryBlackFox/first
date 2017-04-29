using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perenos;

namespace TestForPerenos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p = new Program();
            List<string> text = new List<string>{"abaababab", "bababaab", "baab", "bab"};
            string answer = p.MethodMyPerenos(text, 4);
            //string TrueAnswer = "aba-&aba-&bab&ba-&ba-&baab&baab&bab&";
            string TrueAnswer = "aba-" + Environment.NewLine + "aba-" + Environment.NewLine + "bab" + Environment.NewLine + "ba-" + Environment.NewLine + "ba-" + Environment.NewLine + "baab" + Environment.NewLine + "baab" + Environment.NewLine + "bab" + Environment.NewLine;
            Assert.AreEqual(TrueAnswer, answer, false, "Неверно!!");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Program p = new Program();
            List<string> text = new List<string> { "abaababab", "bababaab", "baab", "bab" };
            string answer = p.MethodMyPerenos(text, 6);
            //string TrueAnswer = "aba-&ababab&baba-&baab&baab&bab&";
            string TrueAnswer = "aba-" + Environment.NewLine + "ababab" + Environment.NewLine + "baba-" + Environment.NewLine + "baab" + Environment.NewLine + "baab" + Environment.NewLine + "bab" + Environment.NewLine;
            Assert.AreEqual(TrueAnswer, answer, false, "Неверно!!");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Program p = new Program();
            List<string> text = new List<string> { "abaababab", "bababaab", "baab", "bab" };
            string answer = p.MethodMyPerenos(text, 8);
            //string TrueAnswer = "abaaba-&bab ba-&babaab&baab&bab ";
            string TrueAnswer = "abaaba-" + Environment.NewLine + "bab ba-" + Environment.NewLine + "babaab" + Environment.NewLine + "baab" + Environment.NewLine + "bab" + Environment.NewLine; 
            Assert.AreEqual(TrueAnswer, answer, false, "Неверно!!");
        }
    }
}
