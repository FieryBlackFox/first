using Microsoft.VisualStudio.TestTools.UnitTesting;
using KrestikiNoliki;

namespace TestKrestNol
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p = new Program();
            char[,] m = new char[3, 3]{ {'X', 'X', 'X'},
                                        {'O', 'O', 'O'},
                                        {'X', 'O', 'X'} };
            string res = p.ForUnitTest(m);
            Assert.AreEqual("некорректный ввод!!", res, false, "неверно!!");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Program p = new Program();
            char[,] m = new char[3, 3]{ {'X', 'O', 'X'},
                                        {'O', 'X', 'O'},
                                        {'O', 'X', 'O'} };
            string res = p.ForUnitTest(m);
            Assert.AreEqual("некорректный ввод!!", res, false, "неверно!!");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Program p = new Program();
            char[,] m = new char[3, 3]{ {'X', 'O', 'X'},
                                        {'O', 'O', 'X'},
                                        {'X', 'X', 'X'} };
            string res = p.ForUnitTest(m);
            Assert.AreEqual("некорректный ввод!!", res, false, "неверно!!");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Program p = new Program();
            char[,] m = new char[3, 3]{ {'A', 'X', 'X'},
                                        {'O', 'O', 'A'},
                                        {'X', 'O', 'X'} };
            string res = p.ForUnitTest(m);
            Assert.AreEqual("некорректный ввод!!", res, false, "неверно!!");
        }

        [TestMethod]
        public void TestMethod5()
        {
            Program p = new Program();
            char[,] m = new char[3, 3]{ {'X', 'O', 'X'},
                                        {'X', 'O', 'O'},
                                        {'?', '?', '?'} };
            string res = p.ForUnitTest(m);
            Assert.AreEqual("X: 2; O: 1; Ничья: 2", res, false, "неверно!!");
        }

        [TestMethod]
        public void TestMethod6()
        {
            Program p = new Program();
            char[,] m1 = new char[3, 3]{ {'X', '?', 'X'},
                                        {'O', 'X', '?'},
                                        {'O', '?', '?'} };
            string res = p.ForUnitTest(m1);
            Assert.AreEqual("X: 12; O: 2; Ничья: 4", res, false, "неверно!!");
        }

        [TestMethod]
        public void TestMethod7()
        {
            Program p = new Program();
            char[,] m = new char[3, 3]{ {'O', 'X', '?'},
                                        {'X', 'O', 'X'},
                                        {'?', 'O', '?'} };
            string res = p.ForUnitTest(m);
            Assert.AreEqual("X: 2; O: 2; Ничья: 2", res, false, "неверно!!");
        }
    }
}
