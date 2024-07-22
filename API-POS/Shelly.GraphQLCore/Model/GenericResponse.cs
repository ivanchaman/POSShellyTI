using Newtonsoft.Json;
using Shelly.Abstractions.Interfaces;

namespace Shelly.GraphQLCore.Model
{
     public class GenericResponse
     {
          [JsonProperty("data")]
          public bool Result { get; set; }
          [JsonProperty("data")]
          public dynamic? Data { get; set; }
          [JsonProperty("errors")]
          public dynamic? Errors { get; set; }

          public GenericResponse()
          {

          }
          public GenericResponse(DataAccess dataAccess, string error) 
          {
             
               Result = false;
               Errors = new[] { new ErrorSystem(dataAccess, error) };
          }
          public GenericResponse(DataAccess dataAccess, string error, string additionalMessage)
          {

               Result = false;
               Errors = new[] { new ErrorSystem(dataAccess, error, additionalMessage) };
          }
          public override string ToString()
          {
               return JsonConvert.SerializeObject(this);
          }
     }
}
