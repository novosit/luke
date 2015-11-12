using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingPaths.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWeighting Paths\n");
            Console.WriteLine("Insert values: ");

            List<string> lines = new List<string>();
            var line = "";
            int whiteLines = 0;
            while (whiteLines < 2)
            {
                line = Console.ReadLine().Trim();
                
                if (line == "")
                {
                    whiteLines++;
                    continue;
                }   
                
                lines.Add(line);
            }

            try
            {
                CalculateLeastWeigtPath(lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
         

            Console.WriteLine();
            Console.WriteLine("done!");

            Console.ReadLine();
        }

        private static void CalculateLeastWeigtPath(List<string> lines)
        {
            string[] nodes = lines[0].Split(' ');
            List<Link> nodesLinks = new List<Link>();

            if (lines.Count < 3)
            {
                Console.WriteLine("Invalid links");
                return;
            }

            for (int i = 2; i <= lines.Count - 1; i++)
            {
                if (lines[i].Trim() == "")
                {
                    break;
                }

                var linkValues = lines[i].Split(' ');
                if (linkValues.Length != 3)
                {
                    Console.WriteLine("Invalid links");
                    return;
                }

                Link newLink = new Link(linkValues[0], linkValues[1], int.Parse(linkValues[2]));
                nodesLinks.Add(newLink);
            }

            string[] targetPath = lines[1].Split(' ');
            if (targetPath.Length != 2)
            {
                Console.WriteLine("Invalid target Path");
                return;
            }

            PathsManager manager = new PathsManager(nodes, nodesLinks);
            PathResult result = manager.GetLeastWeightedPath(targetPath[0], targetPath[1]);

            if (result.Message != "")
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(string.Join(" ", result.Path));
            }

            Console.WriteLine(result.TotalWeights);
        }
    }
}
