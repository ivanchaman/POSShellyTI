
using Shelly.Abstractions.Settings;

namespace Shelly.GraphQLCore.Model
{
     public class ErrorSystem
     {
          [JsonProperty("id")]
          public string? Id { get; set; }
          [JsonProperty("subId")]
          public string? SubId { get; set; }
          [JsonProperty("type")]
          public int? Type { get; set; }
          [JsonProperty("headerDefinition")]
          public string? HeaderDefinition { get; set; }
          [JsonProperty("footherDefinition")]
          public string? FootherDefinition { get; set; }
          [JsonProperty("translationKey")]
          public string? TranslationKey { get; set; }
          [JsonProperty("defaultMessage")]
          public string? DefaultMessage { get; set; }
          [JsonProperty("stack")]
          public string? Stack { get; set; }
          public ErrorSystem()
          {

          }
          public ErrorSystem(IDataAccess dataAccess, string? error):this((DataAccess)dataAccess, error)
          {

          }
          public ErrorSystem(IDataAccess dataAccess, string? error, string? aditionaMessage) : this(dataAccess, error)
          {
               SubId = aditionaMessage;
          }
          public ErrorSystem(DataAccess dataAccess, string? error)
          {
               Shelly.ProviderData.Repository.Entity.ErrorSystem xsErrorSystem = new Shelly.ProviderData.Repository.Entity.ErrorSystem(new BaseSystem(dataAccess));
               xsErrorSystem.Load(error is null ? "" : error);
               Id = error;
               Type = xsErrorSystem.Type;
               HeaderDefinition = xsErrorSystem.HeaderDefinition;
               FootherDefinition = xsErrorSystem.FootherDefinition;
               TranslationKey = xsErrorSystem.TranslationKey;
               DefaultMessage = xsErrorSystem.DefaultMessage;
          }
     }
}
