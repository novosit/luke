using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingPaths.Test
{
    [TestFixture]
    public class PathsManagerTest
    {
        [Test]
        public void EmtyNodesTest()
        {
            try
            {
                string[] node = { };
                List<Link> links = new List<Link>();
                PathsManager manager = new PathsManager(node, links);
                throw new Exception("done!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The specified Nodes list  is invalid!", ex.Message);
            }            
        }

        [Test]
        public void EmtyLinksTest()
        {
            try
            {
                string[] node = {"A","B" };
                List<Link> links = new List<Link>();
                PathsManager manager = new PathsManager(node, links);
                throw new Exception("done!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The specified NodesLinks list is invalid!", ex.Message);
            }
        }

        [Test]
        public void InvalidTargetPathTest()
        {
            string[] node = "A B C D E F G H".Split(' ');
            var links = new List<Link>() { 
                new Link("A", "B", 10),
                new Link("A", "C", 15),
                new Link("C", "H", 20),
                new Link("B", "H", 15)               
            };

            PathsManager manager = new PathsManager(node, links);
            var result = manager.GetLeastWeightedPath("A", "K");
            Assert.AreEqual("The specified target path is not valid!", result.Message);
        }

        [Test]
        public void NotSolucionTest()
        {
            string[] node = "A B C D E F G H".Split(' ');
            var links = new List<Link>() { 
                new Link("A", "B", 10),
                new Link("A", "C", 15),
                new Link("C", "H", 20),
                new Link("B", "H", 15)               
            };

            PathsManager manager = new PathsManager(node, links);
            var result = manager.GetLeastWeightedPath("A", "D");
            Assert.AreEqual("There is no solution for specifieds nodes!", result.Message);
        }

        [Test]
        public void TestA()
        {
            string[] node = "A B C D E F G H".Split(' ');
            var links = new List<Link>() { 
                new Link("A", "B", 10),
                new Link("A", "C", 15),
                new Link("C", "H", 20),
                new Link("B", "H", 15)
            };   
         
            PathsManager manager = new PathsManager(node, links);
            var expectedResut = new PathResult(new List<string> {"A", "B", "H" }, 25);
            var result = manager.GetLeastWeightedPath("A","H");
           
            Assert.AreEqual(true, expectedResut.Equals(result));
        }

        [Test]
        public void TestB()
        {
            string[] node = "A B C D E F G H".Split(' ');
            var links = new List<Link>() { 
                new Link("A", "B", 10),
                new Link("A", "C", 15),
                new Link("C", "H", 20),
                new Link("B", "H", 15),
                new Link("C", "D", 5),
                new Link("D", "G", 25),                
            };

            PathsManager manager = new PathsManager(node, links);
            var expectedResut = new PathResult(new List<string> { "A", "C", "D"}, 20);
            var result = manager.GetLeastWeightedPath("A", "D");

            Assert.AreEqual(true, expectedResut.Equals(result));
        }

    }
}
