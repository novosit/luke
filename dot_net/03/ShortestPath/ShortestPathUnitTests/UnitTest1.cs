using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ShortestPathUnitTests.Properties;
using Graph = ShortestPath.Graph;

namespace ShortestPathUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private static void Compare(String input, String expectedOutput)
        {
            var data = Graph.GetDataFromInput(input);

            var graph = new Graph(
                new List<String>((String[])data.GetType().GetProperty("nodes").GetValue(data)),
                (Dictionary<String, Dictionary<String, Int32>>)data.GetType().GetProperty("map").GetValue(data),
                data.GetType().GetProperty("start").GetValue(data).ToString(),
                data.GetType().GetProperty("end").GetValue(data).ToString()
            );

            Assert.AreEqual(graph.GetOutput(), expectedOutput);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Compare(
                Resources.input01,
                Resources.output01
                );
        }

        [TestMethod]
        public void TestMethod2()
        {
            Compare(
                Resources.input02,
                Resources.output02
                );
        }

        [TestMethod]
        public void TestMethod3()
        {
            Compare(
                Resources.input03,
                Resources.output03
                );
        }

        [TestMethod]
        public void TestMethod4()
        {
            Compare(
                Resources.input04,
                Resources.output04
                );
        }

    }
}
