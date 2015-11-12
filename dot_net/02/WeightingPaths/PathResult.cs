using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingPaths
{
    public class PathResult
    {
        public string Message { get; private set; }
        public List<string> Path { get; internal set; }
        public int TotalWeights { get; internal set; }
        public bool IsValidPath { get; set; }

        public PathResult()
        {
            this.Message = "";
            this.Path = new List<string>();
            this.TotalWeights = 0;
        }

        public PathResult(string message)
        {
            this.Message = message;
            this.Path = new List<string>();
        }

        public PathResult(List<string> path, int weights)
        {
            this.Message= "";
            this.Path = path;
            this.TotalWeights = weights;
        }

        internal void Clear()
        {
            this.Message = "";
            this.Path.Clear();
            this.TotalWeights = 0;
        }

        internal PathResult Clone()
        {
            var clonedPath = new PathResult();
            clonedPath.IsValidPath = this.IsValidPath;
            clonedPath.TotalWeights = this.TotalWeights;
            clonedPath.Path = (this.Path.ToArray().Clone() as string[]).ToList();

            return clonedPath;
        }

        public bool Equals(PathResult anotherPath)
        {
            if (this.Message != anotherPath.Message)
            {
                return false;
            }

            if (this.TotalWeights != anotherPath.TotalWeights)
            {
                return false;
            }

            if (this.Path.Equals(anotherPath.Path))
            {
                return false;
            }

            return true;
        }
    }
}
