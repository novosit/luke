using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            var json = @"
                        {
    ""namespace"": ""Company.Accounting"",
    ""name"": ""Employee"",
    ""description"": ""Represents an employee"",	
    ""properties"": [    
        {
            ""name"": ""id"",
            ""type"": ""string""
        },
		{
            ""name"": ""name"",
            ""type"": ""string""
        },
		{
            ""name"": ""pastPositions"",
            ""type"": ""string"",
			""cardinality"": ""many""
        }
    ]
}";
            var output = parser.GenerateClass(json);

            Console.WriteLine(output);

            Console.ReadLine();

        }
    }
}
