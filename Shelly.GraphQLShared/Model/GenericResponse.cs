namespace Shelly.GraphQLShared.Model
{
     public class GenericResponse<T>
     {
          [JsonProperty("result")]
          public bool Result { get; set; }
          [JsonProperty("data")]
          public Dictionary<string, T> Data { get; set; }
          [JsonProperty("errors")]
          public List<ErrorResponse> Errors { get; set; }

          public T Response { get; set; }

     }
}
