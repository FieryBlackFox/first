using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using findTemplate;

namespace TestForFindTempl
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = "ababa";
            string template = "a";
            SortedSet<Border> s = str.SetOfFoundTemplates(template);
            SortedSet<Border> answer = new SortedSet<Border>();
            answer.Add(new Border(0, 0));
            answer.Add(new Border(2, 2));
            answer.Add(new Border(4, 4));
            CollectionAssert.AreEqual(s, answer);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string str = "ababa";
            string template = "*a";
            SortedSet<Border> s = str.SetOfFoundTemplates(template);
            SortedSet<Border> answer = new SortedSet<Border>();
            answer.Add(new Border(0, 0));
            answer.Add(new Border(0, 2));
            answer.Add(new Border(0, 4));
            answer.Add(new Border(1, 2));
            answer.Add(new Border(1, 4));
            answer.Add(new Border(2, 2));
            answer.Add(new Border(2, 4));
            answer.Add(new Border(3, 4));
            answer.Add(new Border(4, 4));
            CollectionAssert.AreEqual(s, answer);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string str = "ababa";
            string template = "*a*";
            SortedSet<Border> s = str.SetOfFoundTemplates(template);
            SortedSet<Border> answer = new SortedSet<Border>();
            answer.Add(new Border(0, 0));
            answer.Add(new Border(0, 1));
            answer.Add(new Border(0, 2));
            answer.Add(new Border(0, 3));
            answer.Add(new Border(0, 4));
            answer.Add(new Border(1, 2));
            answer.Add(new Border(1, 3));
            answer.Add(new Border(1, 4));
            answer.Add(new Border(2, 2));
            answer.Add(new Border(2, 3));
            answer.Add(new Border(2, 4));
            answer.Add(new Border(3, 4));
            answer.Add(new Border(4, 4));
            CollectionAssert.AreEqual(s, answer);
        }
    }
}
