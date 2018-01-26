using System;
using System.Collections.Generic;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            String line, input = "";
            while ((line = Console.ReadLine()) != null)
            {
                input += line + "\r\n";
            }
            var data = Graph.GetDataFromInput(input);
            
            var graph = new Graph(
                new List<String>((String[])data.GetType().GetProperty("nodes").GetValue(data)),
                (Dictionary < String, Dictionary < String, Int32 >>)data.GetType().GetProperty("map").GetValue(data),
                data.GetType().GetProperty("start").GetValue(data).ToString(),
                data.GetType().GetProperty("end").GetValue(data).ToString()
            );

            Console.WriteLine(graph.GetOutput());

            Console.Read();
        }
    }
}
