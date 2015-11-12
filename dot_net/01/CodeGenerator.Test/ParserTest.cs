using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using CodeGenerator;

namespace CodeGenerator.Test
{
    [TestFixture]
    class ParserTest
    {
        private  string exampleFilesPath
        {
            get
            {
                var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return Path.Combine(path, "examples");
            }
        }

        [Test]
        public void EmtyTest()
        { 
            Parser parser = new Parser();
            Assert.AreEqual("Invalid input!", parser.GenerateClass(""));
        }

        [Test]
        public void SimpleClassWithoutPorperty()
        {
            Parser parser = new Parser();
            string json = GetInputJson("SimpleClassWithoutPorperty.json");

            string expectedOput = GetExpectedClass("SimpleClassWithoutPorperty.cs")
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            string output = parser.GenerateClass(json)
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            Console.WriteLine("Input: \n{0}", json);

            Console.WriteLine("\n\nExpected: \n{0}", expectedOput);
            Console.WriteLine("\n\nOutput: \n{0}", output);

            Assert.AreEqual(expectedOput, output);
        }

        [Test]
        public void SimpleClassWithOneProperty()
        {
            Parser parser = new Parser();
            string json = GetInputJson("SimpleClassWithOnePorperty.json");
            string expectedOput = GetExpectedClass("SimpleClassWithOnePorperty.cs")
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            string output = parser.GenerateClass(json)
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            Console.WriteLine("Input: \n{0}", json);

            Console.WriteLine("\n\nExpected: \n{0}", expectedOput);
            Console.WriteLine("\n\nOutput: \n{0}", output);

            Assert.AreEqual(expectedOput, output);
        }

        [Test]
        public void NonMutableClassWitOnePorperty()
        {
            Parser parser = new Parser();
            string json = GetInputJson("NonMutableClassWithOnePorperty.json");
            string expectedOput = GetExpectedClass("NonMutableClassWithOnePorperty.cs")
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            string output = parser.GenerateClass(json)
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            Console.WriteLine("Input: \n{0}", json);

            Console.WriteLine("\n\nExpected: \n{0}", expectedOput);
            Console.WriteLine("\n\nOutput: \n{0}", output);

            Assert.AreEqual(expectedOput, output);
        }

        [Test]
        public void SimpleClassWithNonMutablePorperties()
        {
            Parser parser = new Parser();
            string json = GetInputJson("SimpleClassWithNonMutablePorperties.json");
            string expectedOput = GetExpectedClass("SimpleClassWithNonMutablePorperties.cs")
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            string output = parser.GenerateClass(json)
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            Console.WriteLine("Input: \n{0}", json);

            Console.WriteLine("\n\nExpected: \n{0}", expectedOput);
            Console.WriteLine("\n\nOutput: \n{0}", output);

            Assert.AreEqual(expectedOput, output);
        }

        [Test]
        public void SimpleClassWithCollectionPorperty()
        {
            Parser parser = new Parser();
            string json = GetInputJson("SimpleClassWithCollectionPorperty.json");
            string expectedOput = GetExpectedClass("SimpleClassWithCollectionPorperty.cs")
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            string output = parser.GenerateClass(json)
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            Console.WriteLine("Input: \n{0}", json);

            Console.WriteLine("\n\nExpected: \n{0}", expectedOput);
            Console.WriteLine("\n\nOutput: \n{0}", output);

            Assert.AreEqual(expectedOput, output);
        }

        [Test]
        public void NonMutableClassWithCollectionPorperty()
        {
            Parser parser = new Parser();
            string json = GetInputJson("NonMutableClassWithCollectionPorperty.json");
            string expectedOput = GetExpectedClass("NonMutableClassWithCollectionPorperty.cs")
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            string output = parser.GenerateClass(json)
                .Replace('\r'.ToString(), "")
                .Replace('\t'.ToString(), "")
                .Replace('\n'.ToString(), "");

            Console.WriteLine("Input: \n{0}", json);

            Console.WriteLine("\n\nExpected: \n{0}", expectedOput);
            Console.WriteLine("\n\nOutput: \n{0}", output);

            Assert.AreEqual(expectedOput, output);
        }

        
        private string GetExpectedClass(string file)
        {

            file = Path.Combine(exampleFilesPath, "outputs", file);

            Console.WriteLine(file);
            if (!File.Exists(file))
                return "";

            return File.ReadAllText(file);
        }

        private string GetInputJson(string file)
        {
            file = Path.Combine(exampleFilesPath, "inputs",file);
            Console.WriteLine(file);
            if (!File.Exists(file))
                return "";

            return File.ReadAllText(file);
        }
        

    }
}
