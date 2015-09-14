using System;
using System.Collections.Generic;

namespace ShortestPath
{
    public class Graph
    {
        private String start;
        private String end;
        private IDictionary<String, Int32> distances;
        private IDictionary<String, String> previous;

        public static object GetDataFromInput(String input)
        {
            String[] lines = input.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            var nodes = lines[0].Split(' ');
            var start = lines[1][0];
            var end = lines[1][2];

            Dictionary<String, Dictionary<String, Int32>> map = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 3; i < lines.Length; i++)
            {
                if (lines[i] == "") continue;
                var fields = lines[i].Split(' ');
                if (!map.ContainsKey(fields[0]))
                    map[fields[0]] = new Dictionary<string, int>();
                map[fields[0]].Add(fields[1], Convert.ToInt32(fields[2]));
            }

            return new 
            {
                nodes = nodes,
                start = start,
                end = end,
                map = map,
            };
        }

        public Graph(IList<String> nodes, IDictionary<String, Dictionary<String, Int32>> map, String start, String end)
        {
            
            this.start = start;
            this.end = end;

            this.distances = new Dictionary<string, int>();
            this.previous = new Dictionary<string, string>();
            foreach (var node in nodes)
            {
                this.distances.Add(node, Int32.MaxValue);
                this.previous.Add(node, null);
            }
            this.distances[this.start] = 0;

            while (nodes.Count > 0)
            {
                var closest = popClosestVertex(ref nodes);

                if (closest == null || closest == end)
                    break;

                foreach (var neighbor in map[closest])
                {
                    if ( distances[neighbor.Key] > distances[closest] + map[closest][neighbor.Key])
                    {
                        distances[neighbor.Key] = distances[closest] + map[closest][neighbor.Key];
                        previous[neighbor.Key] = closest;
                    }
                }
            }
        }

        private String popClosestVertex(ref IList<String> nodes)
        {
            var min = Int32.MaxValue;
            String closest = null;
            foreach (var node in nodes)
            {
                if (distances[node] < min)
                {
                    min = distances[node];
                    closest = node;
                }
            }
            nodes.Remove(closest);
            return closest;
        }

        public IList<String> ShortestPath()
        {
            var next = this.end;
            var path = new List<String>() { next };

            if (this.previous[next] == null)
                return new List<String>();

            while ( next != this.start )
            {
                next = this.previous[next];
                path.Add(next);
            }
            path.Reverse();
            return path;
        }

        public Int32 PathCost()
        {
            return this.distances[this.end];
        }

        public String GetOutput()
        {
            return (this.ShortestPath().Count > 0) ?
                String.Join(" ", this.ShortestPath()) + "\r\n\r\n" + this.PathCost().ToString() :
                String.Format("No path was found from {0} to {1}.", this.start, this.end);
        }
    }
}
