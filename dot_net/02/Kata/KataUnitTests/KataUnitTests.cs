using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novosit;
using System;

namespace KataUnitTests
{
    [TestClass]
    public class KataUnitTests
    {
        private static void Compare(String input, int expected = 0)
        {
            Assert.AreEqual(expected, Novosit.Kata.Add(input) );
        }

        [TestMethod]
        public void Test1()
        {
            Compare("", 0);
        }

        [TestMethod]
        public void Test2()
        {
            Compare("1", 1);
        }

        [TestMethod]
        public void Test3()
        {
            Compare("1,2", 3);
        }

        [TestMethod]
        public void Test4()
        {
            Compare("1,2,1,1,1,1", 7);
        }

        [TestMethod]
        public void Test5()
        {
            Compare("1\r\n2\r\n1\r\n1\r\n1,1", 7);
        }

        [TestMethod]
        public void Test6()
        {
            Compare("1,2,\n", 3);
        }

        [TestMethod]
        public void Test7()
        {
            Compare("1,2\r\n1,1\r\n1,1\r\n", 7);
        }

        [TestMethod]
        public void Test8()
        {
            Compare("//;\n1;2", 3);
        }

        [TestMethod]
        public void Test9()
        {
            Compare("//;\n1;2,1\r\n1,1;1", 7);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "negatives not allowed {-1}")]
        public void Test10()
        {
            Compare("1,-1");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "negatives not allowed {-1,-2,-4}")]
        public void Test11()
        {
            Compare("-1,1,-2,3,-4");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "negatives not allowed {-1,-2,-4,-7,-9}")]
        public void Test12()
        {
            Compare("-1,1,-2,\r\n3,-4\n6\n-7,-9");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "negatives not allowed {-1,-2,-4}")]
        public void Test13()
        {
            Compare("//x\n-1,1x-2,3,-4\r\nx");
        }
    }
}
