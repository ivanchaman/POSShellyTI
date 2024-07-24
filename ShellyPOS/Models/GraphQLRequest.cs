using Newtonsoft.Json.Linq;

namespace ShellyPOS.Models
{
    public class GraphQLRequest
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        
    }
}
