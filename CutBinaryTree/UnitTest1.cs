using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CutBinaryTree;

namespace TestForBinaryCut
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BinaryTree B = new BinaryTree();
            B.AddNode(7);
            B.AddNode(10);
            B.AddNode(5);
            B.AddNode(8);
            B.AddNode(11);
            B.AddNode(3);
            B.AddNode(6);
            BinaryTree B1 = new BinaryTree();
            B1.AddNode(6);
            B1.AddNode(8);
            B1.AddNode(11);
            B.cutBinaryTree(B1);
            List<int> listDate = new List<int>();
            List<int> listDateTrue = new List<int>();
            listDateTrue.Add(3);
            listDateTrue.Add(5);
            listDateTrue.Add(7);
            listDateTrue.Add(10);
            B.ListDates(listDate);
            CollectionAssert.AreEqual(listDateTrue, listDate);
        }

        [TestMethod]
        public void TestMethod2()
        {
            BinaryTree B = new BinaryTree();
            B.AddNode(7);
            B.AddNode(5);
            B.AddNode(8);
            B.AddNode(11);
            B.AddNode(6);
            BinaryTree B1 = new BinaryTree();
            B1.AddNode(6);
            B1.AddNode(11);
            B.cutBinaryTree(B1);
            List<int> listDate = new List<int>();
            List<int> listDateTrue = new List<int>();
            listDateTrue.Add(5);
            listDateTrue.Add(7);
            listDateTrue.Add(8);
            B.ListDates(listDate);
            CollectionAssert.AreEqual(listDateTrue, listDate);
        }

        [TestMethod]
        public void TestMethod3()
        {
            BinaryTree B = new BinaryTree();
            B.AddNode(7);
            B.AddNode(10);
            BinaryTree B1 = new BinaryTree();
            B1.AddNode(6);
            B.cutBinaryTree(B1);
            List<int> listDate = new List<int>();
            List<int> listDateTrue = new List<int>();
            listDateTrue.Add(7);
            listDateTrue.Add(10);
            B.ListDates(listDate);
            CollectionAssert.AreEqual(listDateTrue, listDate);
        }


    }
}
