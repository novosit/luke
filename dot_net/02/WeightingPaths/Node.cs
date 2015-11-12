using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingPaths
{
    internal class Node
    {
        public string Name { get; set; }
        public List<NodeRelation> Relations { get; set; }

        public Node(string name)
        {
            this.Name = name;
            this.Relations = new List<NodeRelation>();
        }
    }

    internal class NodeRelation
    {
        public Node TargetNode { get; set; }
        public int Weitgh { get; set; }

        public NodeRelation(Node targetNode, int weitgh)
        {
            this.TargetNode = targetNode;
            this.Weitgh = weitgh;
        }
    }
}
