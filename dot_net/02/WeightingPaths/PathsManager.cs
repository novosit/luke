using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingPaths
{
    public class PathsManager
    {
        private string[] _nodes;
        private List<Link> _nodesLinks;
        private List<PathResult> _posiblePaths;
        private PathResult _currentPath;

        public PathsManager(string[] nodes, List<Link> nodesLinks)
        {
            if (nodes.Length == 0)
            {
                throw new Exception("The specified Nodes list  is invalid!");
            }

            if (nodesLinks.Count == 0)
            {
                throw new Exception("The specified NodesLinks list is invalid!");
            }

            this._nodes = nodes;
            this._nodesLinks = nodesLinks;
            this._posiblePaths = new List<PathResult>();
            this._currentPath = new PathResult();
        }

        public PathResult GetLeastWeightedPath(string startNodeName, string endNodeName)
        {
            if (!TargetPathIsValid(startNodeName, endNodeName))
            {
                return new PathResult("The specified target path is not valid!");
            }

            if (!NodeHasRelations(startNodeName) || !NodeHasRelations(endNodeName))
            {
                return new PathResult("There is no solution for specifieds nodes!");
            }

            var nodesTree = BuildNodesTree(_nodesLinks, endNodeName);
            CalculatePosiblePaths(nodesTree, startNodeName, endNodeName);
            if (_posiblePaths.Count() == 0)
            {
                return new PathResult("There is no solution for specifieds nodes!");
            }

            return GetLeastWeightedPath(_posiblePaths);
        }

        private PathResult GetLeastWeightedPath(List<PathResult> posiblePaths)
        {
            int leastWeiths = posiblePaths.Min(path => path.TotalWeights);
            PathResult result = posiblePaths.FirstOrDefault(path => path.TotalWeights == leastWeiths);

            result.Path = result.Path.OrderByDescending(node => result.Path.IndexOf(node)).ToList();

            return result;
        }

        private bool NodeHasRelations(string nodeName)
        {
            var relation = _nodesLinks
                .FirstOrDefault(node => node.FirtsNode == nodeName || node.SecondNode == nodeName);

            if (relation == null)
            {
                return false;
            }

            return true;
        }

        private bool TargetPathIsValid(string startNodeName, string endNodeName)
        {
            var starNode = _nodes.FirstOrDefault(node => node == startNodeName);
            if (starNode == null)
            {
                return false;
            }

            var endNode = _nodes.FirstOrDefault(node => node == endNodeName);
            if (endNode == null)
            {
                return false;
            }

            return true;
        }       

        private Node BuildNodesTree(List<Link> links, string rootNodeName)
        {
            Node rootNode = new Node(rootNodeName);
            rootNode.Relations = GetNodeRelations(links, rootNodeName);

            return rootNode;            
        }

        private List<NodeRelation> GetNodeRelations(List<Link> links, string nodeName)
        {
            var realations =  new List<NodeRelation>();

            var relateNodes = links.Where(link => link.SecondNode == nodeName).ToList();
            if (relateNodes == null)
            {
                return realations;
            }

            foreach (var link in relateNodes)
            {
                Node adjacentNode = new Node(link.FirtsNode);
                adjacentNode.Relations = GetNodeRelations(links, link.FirtsNode);
                NodeRelation relation = new NodeRelation(adjacentNode, link.Weight);
                realations.Add(relation);
            }

            return realations;
        }

        private void CalculatePosiblePaths(Node nodeTree, string startNodeName, string endNodeName)
        {
            foreach (var item in nodeTree.Relations)
            {
                if (_currentPath.Path.Count == 0)
                {
                    _currentPath.Path.Add(endNodeName);
                }

                _currentPath.Path.Add(item.TargetNode.Name);
                _currentPath.TotalWeights += item.Weitgh;

                if (item.TargetNode.Name == startNodeName)
                {
                    _posiblePaths.Add(_currentPath.Clone());
                    _currentPath.Clear();

                    continue;
                }

                CalculatePosiblePaths(item.TargetNode, startNodeName, endNodeName);
                _currentPath.Clone();
            }
        }
    }
}
