using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingPaths
{
    public class Link
    {
        public string FirtsNode { get; set; }
        public string SecondNode { get; set; }
        public int Weight { get; set; }

        public Link(string firtsNode, string secondNode, int weight)
        {
            this.FirtsNode = firtsNode;
            this.SecondNode = secondNode;
            this.Weight = weight;
        }
    }
}
