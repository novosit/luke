using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator;

namespace CodeGenerator.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert json input: ");
            var json = Console.ReadLine();

            Parser parser = new Parser();
            var output = parser.GenerateClass(json);


            Console.WriteLine("\nThe result code was:\n\n ");
            Console.WriteLine(output);

            Console.ReadLine();

        }
    }
}
