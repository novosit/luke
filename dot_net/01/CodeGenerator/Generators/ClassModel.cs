using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeGenerator.Generators
{
    

    public class Property
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("mutable")]
        public bool? Mutable { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("cardinality")]
        public string Cardinality { get; set; }
        
    }

    public class ClassModel
    {

        public ClassModel()
        {
            Properties = new List<Property>();
        }

       [JsonProperty("namespace")]
        public string Namespace { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("mutable")]
        public bool Mutable { get; set; }
        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }
    }
}
